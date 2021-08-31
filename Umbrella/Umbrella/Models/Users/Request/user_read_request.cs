using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.Models.User {
    public class user_read_request
    {
        private Guid _user_guid = Guid.Parse("00000000-0000-0000-0000-000000000000");
        private string _name_first = "";
        private string _name_last = "";

        public Guid user_guid {
            get { return this._user_guid; }
            set { this._user_guid = value; }
        }
        public string name_first {
            get { return this._name_first; }
            set { this._name_first = value; }
        }
        public string name_last {
            get { return this._name_last; }
            set { this._name_last = value; }
        }

        public user_read_request() { }
    }
}
