using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {
    class NTracerException : Exception {
        string reason;
        public NTracerException(string reason) {
            this.reason = reason;
        }

        public string GetReason() { return reason; }
    }
}
