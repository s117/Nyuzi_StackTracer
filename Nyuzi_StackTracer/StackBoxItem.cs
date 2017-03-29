using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {
    public class StackBoxItem : BoxItem {
        string disp_string;
        string info_string;
        bool correctness;
        public StackBoxItem(string disp_string, string info_string, bool correctness) {
            this.disp_string = disp_string;
            this.info_string = info_string;
            this.correctness = correctness;
        }
        public StackBoxItem(UInt32 entry, UInt32 return_address,ObjdumpSymtabParser symtbl) {
            FuncRecord entry_record = symtbl.QueryFuncSymByOffset(entry);
            FuncRecord return_record = symtbl.QueryFuncSymByOffset(return_address);
            FuncRecord pc_record = symtbl.QueryFuncSymByOffset(return_address - 4);
            correctness = true;
            disp_string = SymbolUtils.GenerateSymbolDisp(return_address - 4,pc_record);
            info_string = "To " + SymbolUtils.GenerateSymbolDisp(entry,entry_record);
        }
        public override bool GetCorrectness() {
            return correctness;
        }

        public override string GetInfo() {
            return info_string;
        }

        public override string ToString() {
            return disp_string;
        }
    }
}
