using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.Controllers.Helpers {
    public class JSONWrapper {

        private object _body = "";
        private JSONWrapperHeader _head = new JSONWrapperHeader();

        public object body {
            get { return this._body; }
            set { if (value != null) { this._body = value; } }
        }
        public JSONWrapperHeader head {
            get { return this._head;  }
            set { if (value != null) { this._head = value; } }
        }

        public JSONWrapper(object JsonBody) {
            this.body = JsonBody;
        }
    }
    public class JSONWrapperHeader {

        private DateTime _expires = DateTime.UtcNow.AddMinutes(1);

        public string expires {
            get { return this._expires.ToString("yyyy-MM-dd HH:mm:ss"); }
            set {
                if (value != null) {
                    try {

                        this._expires = DateTime.Parse(value);
                    } catch { }
                }
            }
        }

        public JSONWrapperHeader() { }
    }
}
