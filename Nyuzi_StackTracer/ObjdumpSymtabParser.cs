using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {
    public class FuncRecord : IEquatable<FuncRecord>, IComparable<FuncRecord> {
        public string file_name;
        public string symbol_name;
        public string section_name;
        public UInt32 offset;
        public UInt32 length;
        public bool isGlobal;

        bool IEquatable<FuncRecord>.Equals(FuncRecord other) {
            return (this.file_name.Equals(other.file_name) && this.section_name.Equals(other.section_name));
        }

        int IComparable<FuncRecord>.CompareTo(FuncRecord other) {
            if (this.offset != other.offset)
                return (Int32) ((Int64) this.offset - (Int64) other.offset);
            else {
                return (Int32) ((Int64) this.length - (Int64) other.length);
            }
        }
    };

    public class ObjdumpSymtabParser {
        private List<FuncRecord> record_list;
        private Regex recordline_regx = new Regex(@"^([0123456789abcdef]+?)\s(.{7})\s(\.[^\s]+?)\s+?([0123456789abcdef]+?)\s(.+?)$",RegexOptions.Singleline);
        private Regex infoline_regx = new Regex(@"^(.+?):\sfile format (.+?)$",RegexOptions.Singleline);
        private string elf_name = null;
        private string elf_format = null;
        public ObjdumpSymtabParser(string symtabfile) {
            if(symtabfile == null) { // no symbol loaded
                record_list = new List<FuncRecord>();
                FuncRecord null_record = new FuncRecord(); // make a dummy record
                null_record.file_name = "null";
                null_record.isGlobal = false;
                null_record.length = UInt32.MaxValue;
                null_record.offset = 0;
                null_record.section_name = "null";
                null_record.symbol_name = "";
                record_list.Add(null_record);
                return;
            }

            StreamReader sr = new StreamReader(symtabfile,Encoding.Default);
            String line;
            record_list = new List<FuncRecord>();
            while ((line = sr.ReadLine()) != null) {


                if (line.Equals(""))
                    continue;

                if ((elf_name == null) && (elf_format == null)) {
                    Match infoline_match_result = infoline_regx.Match(line);
                    if (infoline_match_result.Success) {
                        elf_name = infoline_match_result.Groups[1].Value;
                        elf_format = infoline_match_result.Groups[2].Value;
                        if (!elf_format.Equals("ELF32-nyuzi")) {
                            sr.Close();
                            sr.Dispose();
                            throw new NTracerException("Wrong elf file format: " + elf_format);
                        }
                    } else {
                        sr.Close();
                        sr.Dispose();
                        throw new NTracerException("Illegal symbol table dump, using '$ llvm-objdump [elf] -t > symtab' to generate.");
                    }
                } else {
                    Match match_result = recordline_regx.Match(line);
                    if (match_result.Success) {
                        if (!match_result.Groups[2].Value.Contains("F")) {
                            continue;
                        }
                        FuncRecord curr_line_record = new FuncRecord();
                        try {
                            curr_line_record.file_name = elf_name;
                            curr_line_record.offset = UInt32.Parse(match_result.Groups[1].Value,System.Globalization.NumberStyles.HexNumber);
                            curr_line_record.isGlobal = match_result.Groups[2].Value.Contains("g");
                            curr_line_record.section_name = match_result.Groups[3].Value;
                            curr_line_record.length = UInt32.Parse(match_result.Groups[4].Value,System.Globalization.NumberStyles.HexNumber);
                            curr_line_record.symbol_name = match_result.Groups[5].Value;
                        } catch (Exception ex) {
                            sr.Close();
                            sr.Dispose();
                            throw new NTracerException("Fail to parse symbol table line:" + line + "\nreason: " + ex.ToString());
                        }


                        record_list.Add(curr_line_record);
                    } else if (line.Equals("SYMBOL TABLE:")) {
                        continue;
                    } else if (line.Equals("00000000         *UND*\t\t 00000000 ")) {
                        continue;
                    } else {
                        sr.Close();
                        sr.Dispose();
                        throw new NTracerException("Invalid symbol table dump line: " + line);
                    }
                }
            }
            sr.Close();
            sr.Dispose();
            record_list.Sort();
            if (record_list[0].symbol_name.Equals("_start")&&(record_list[0].length == 0)) {
                record_list[0].length = record_list[1].offset-record_list[0].offset;
            }
        }
        public FuncRecord QueryFuncSymByOffset(UInt32 offset) {
            FuncRecord nearest_func = record_list[0];

            foreach (FuncRecord rec in record_list) {
                if (offset < rec.offset) { // offset is too low or it isn't in a function but still in the range of the record
                    return nearest_func;
                } else if (offset < rec.offset + rec.length) { // in this function
                    return rec;
                } else { // offset may in next function
                    nearest_func = rec;
                }
            }
            return nearest_func; // offset is too high
        }
    }
}
