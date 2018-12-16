using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnideskSDK {
    class OmnideskException : Exception {
        public OmnideskException(string message) : base(message) { }
    }
}
