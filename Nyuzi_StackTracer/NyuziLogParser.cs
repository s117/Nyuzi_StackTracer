using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {

    class NyuziLogParser{
        private static Regex regx = new Regex(@"^\[\s*?(\d+)\]\s(\d+?)@0x([0123456789abcdefzx]{8})\s(\S+?)\sto\s0x([0123456789abcdefzx]{8})$",RegexOptions.Singleline);

        public static List<TraceRecord> Parse(string logfile) {
            StreamReader sr = new StreamReader(logfile,Encoding.Default);
            String line;
            List<TraceRecord> result = new List<TraceRecord>(20);
            while ((line = sr.ReadLine()) != null) {
                if (line.Equals(""))
                    continue;

                
                Match match_result = regx.Match(line);
                if (match_result.Success) {
                    try {
                        TraceRecord curr_line_record = new TraceRecord();
                        curr_line_record.pc_valid = false;
                        curr_line_record.target_valid = false;

                        curr_line_record.time = UInt32.Parse(match_result.Groups[1].Value);

                        curr_line_record.thread_id = Int32.Parse(match_result.Groups[2].Value);

                        curr_line_record.pc_orig = match_result.Groups[3].Value;
                        if (!(curr_line_record.pc_orig.Contains("x") || curr_line_record.pc_orig.Contains("z"))) {
                            curr_line_record.pc = UInt32.Parse(curr_line_record.pc_orig,System.Globalization.NumberStyles.HexNumber);
                            curr_line_record.pc_valid = true;
                        }


                        if (match_result.Groups[4].Value.Equals("call")) {
                            curr_line_record.type = TraceRecord.inst_type_t.CALL;
                        } else if (match_result.Groups[4].Value.Equals("retn")) {
                            curr_line_record.type = TraceRecord.inst_type_t.RETURN;
                        } else {
                            sr.Close();
                            sr.Dispose();
                            throw new NTracerException("Invalid type'" + match_result.Groups[4] + "' in log line: " + line);
                        }

                        curr_line_record.target_orig = match_result.Groups[5].Value;
                        if (!(curr_line_record.target_orig.Contains("x") || curr_line_record.target_orig.Contains("z"))) {
                            curr_line_record.target = UInt32.Parse(match_result.Groups[5].Value,System.Globalization.NumberStyles.HexNumber);
                            curr_line_record.target_valid = true;

                        }

                        result.Add(curr_line_record);
                    } catch (Exception ex) {
                        sr.Close();
                        sr.Dispose();
                        throw new NTracerException("Fail to parse symbol table line:" + line + "\nreason: " + ex.ToString());
                    }
                } else {
                    sr.Close();
                    sr.Dispose();
                    throw new NTracerException("Invalid log line: " + line);
                }
            }

            sr.Close();
            sr.Dispose();
            return result;
        }

    }
}
