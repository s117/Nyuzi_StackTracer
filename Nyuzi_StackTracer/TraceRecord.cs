using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {
    public class TraceRecord {
        public enum inst_type_t {
            CALL,
            RETURN
        };

        public inst_type_t type;
        public Int32 thread_id;
        public UInt32 pc;
        public string pc_orig;
        public bool pc_valid;
        public UInt32 target;
        public string target_orig;
        public bool target_valid;
        public UInt32 time;
    }
}
