using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.Models.User {
    public class user_read_response {
        private Guid _id = Guid.Empty;
        private string _name_first = "";
        private string _name_last = "";
        private string _email_address = "";
        private int _user_status = 0;
        private DateTime _record_created = DateTime.MinValue;
        private DateTime _record_updated = DateTime.MinValue;
        private bool _record_status = false;

        public Guid id {
            get { return this._id; }
            set { this._id = value; }
        }
        public string name_first {
            get { return this._name_first; }
            set { this._name_first = value; }
        }
        public string name_last {
            get { return this._name_last; }
            set { this._name_last = value; }
        }
        public string email_address {
            get { return this._email_address; }
            set { this._email_address = value; }
        }
        public int user_status {
            get { return this._user_status; }
            set { this._user_status = value; }
        }
        public DateTime record_created {
            get { return this._record_created; }
            set { this._record_created = value; }
        }
        public DateTime record_updated {
            get { return this._record_updated; }
            set { this._record_updated = value; }
        }
        public bool record_status {
            get { return this._record_status; }
            set { this._record_status = value; }
        }

        public user_read_response() { }
    }
}
