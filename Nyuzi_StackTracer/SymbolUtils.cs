using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {
    class SymbolUtils {
        public static bool CheckSymCorrectness(UInt32 offset,FuncRecord sym) {
            return (sym.offset <= offset) && (offset < sym.offset + sym.length);
        }
        public static string GenerateSymbolDisp(UInt32 offset,FuncRecord sym) {

            Int64 deviation = ((Int64) offset - (Int64) sym.offset);
            if (sym.symbol_name.Equals("") && (sym.length == UInt32.MaxValue) && (sym.offset == 0)) {
                return "0x"+ offset.ToString("x8");
            } else {
                return sym.symbol_name + ((deviation == 0) ? "" : ((deviation > 0) ? "+" + deviation.ToString() : deviation.ToString()));
            }

        }
    }
}
