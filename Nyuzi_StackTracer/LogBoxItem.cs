using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {
    public class LogBoxItem : BoxItem {
        string disp_string;
        string info_string;
        bool correctness;
        int stack_record_idx;
        Int32 thread_id;

        public int Stack_record_idx {
            get {
                return stack_record_idx;
            }

            set {
                stack_record_idx = value;
            }
        }

        public Int32 GetThreadID() { return thread_id; }

        public LogBoxItem(List<TraceRecord> records,int idx,ObjdumpSymtabParser symtab) {
            TraceRecord content = records[idx];
            stack_record_idx = idx;
            thread_id = content.thread_id;

            correctness = (content.pc_valid && content.target_valid);

            FuncRecord pc_sym, target_sym;
            pc_sym = symtab.QueryFuncSymByOffset(content.pc);
            target_sym = symtab.QueryFuncSymByOffset(content.target);
            disp_string = "[" + idx + "] " + "Thread-" + content.thread_id + " " + content.type.ToString();

            if (content.pc_valid) {
                disp_string += " <" + SymbolUtils.GenerateSymbolDisp(content.pc,pc_sym) + ">";
                if (!SymbolUtils.CheckSymCorrectness(content.pc,pc_sym)) {
                    correctness = false;
                }
            } else {
                disp_string += "0x" + content.pc_orig;
            }

            disp_string += " -->";

            if (content.target_valid) {
                disp_string += " <" + SymbolUtils.GenerateSymbolDisp(content.target,target_sym) + ">";
                if (!SymbolUtils.CheckSymCorrectness(content.target,target_sym)) {
                    correctness = false;
                }
            } else {
                disp_string += " 0x" + content.target_orig;
            }

            info_string = content.time + "/T " + content.type.ToString() + " 0x" + content.pc_orig + " ->" + " 0x" + content.target_orig;
            if (!content.pc_valid || !content.target_valid) {
                info_string += " # error address.";
            } else if (!correctness) {
                info_string += " # abnormal address.";
            }
        }

        public override bool GetCorrectness() { return correctness; }
        public override string ToString() { return disp_string; }
        public override string GetInfo() { return info_string; }
    }
}
