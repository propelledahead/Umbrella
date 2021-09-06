using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.Models.User {
    public class user_read_response {
        private Guid _id = Guid.Empty;
        private string _user_name = "";
        private string _name_first = "";
        private string _name_last = "";
        private string _email_address = "";
        private int _user_status = 0;
        private DateTime _record_created = DateTime.Parse("1900-01-01 01:00:00");
        private DateTime _record_updated = DateTime.Parse("1900-01-01 01:00:00");
        private int _record_status = 0;

        public Guid id {
            get { return this._id; }
            set {

                    this._id = value;

            }
        }
        public string user_name {
            get { return this._user_name; }
            set { this._user_name = value; }
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
        public string record_created {
            get { return this._record_created.ToString("yyyy-MM-dd HH:mm:ss"); }
            set {
                if (!String.IsNullOrEmpty(value)) {
                    this._record_created = DateTime.Parse(value);
                }
            }
        }
        public string record_updated {
            get { return this._record_updated.ToString("yyyy-MM-dd HH:mm:ss"); }
            set {
                if (!String.IsNullOrEmpty(value)) {
                    this._record_updated = DateTime.Parse(value);
                }
            }
        }
        public int record_status {
            get { return this._record_status; }
            set { this._record_status = value; }
        }

        public user_read_response() { }
    }
}
