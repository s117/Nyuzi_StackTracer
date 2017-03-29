using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyuzi_StackTracer {
    public abstract class BoxItem {
        public abstract bool GetCorrectness();
        public override abstract string ToString();
        public abstract string GetInfo();
    }
}
