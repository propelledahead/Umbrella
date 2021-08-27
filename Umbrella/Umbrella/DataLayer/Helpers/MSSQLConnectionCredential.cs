using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.DataLayer.Helpers {
    public class MSSQLConnectionCredential {
        #region Globals
        private string _server_ip = "";
        private string _server_name = "";
        private string _database_name = "";
        private string _user_name = "";
        private string _password = "";
        private int _max_sessions = 1000;
        private int _port_number = 1433;
        private bool _prefer_server_ip_address = true;
        #endregion

        #region Getters and Setters

        public string ServerIP {
            get { return this._server_ip; }
            set { this._server_ip = value; }
        }
        public string ServerName {
            get { return this._server_name; }
            set { this._server_name = value; }
        }
        public string DatabaseName {
            get { return this._database_name; }
            set { this._database_name = value; }
        }
        public string UserName {
            get { return this._user_name; }
            set { this._user_name = value; }
        }
        public string Password {
            get { return this._password; }
            set { this._password = value; }
        }
        public int MaxSessions {
            get { return this._max_sessions; }
            set { this._max_sessions = value; }
        }
        public int PortNumber {
            get { return this._port_number; }
            set { this._port_number = value; }
        }
        public bool PreferUsingServerIPAddress {
            get { return this._prefer_server_ip_address; }
            set { this._prefer_server_ip_address = value; }
        }

        #endregion

        #region Methods

        public string ToConnectionString(bool UseServerName) {
            string _result = "";
            if (!String.IsNullOrEmpty(this._server_name)
                && !String.IsNullOrEmpty(this._database_name)
                && !String.IsNullOrEmpty(this._user_name)
                && !String.IsNullOrEmpty(this._password)

            ) {
                if (UseServerName && !String.IsNullOrEmpty(this._server_name)) {
                    _result = this.ConnectionStringBuildServerName();
                } else {
                    if (UseServerName && !String.IsNullOrEmpty(this._server_ip)) {
                        _result = this.ConnectionStringBuildServerIP();
                    } else {
                        _result = this.ConnectionStringBuildServerName();
                    }
                }
            }
            return _result;
        }

        private string ConnectionStringBuildServerName() {
            return "Server=" + this._server_name + "; Database=" + this._database_name + "; User ID=" + this._user_name + "; Password=" + this._password + "; Max Pool Size=" + this._max_sessions + ";";
        }
        private string ConnectionStringBuildServerIP() {
            return "Server=" + this._server_ip + "; Database=" + this._database_name + "; User ID=" + this._user_name + "; Password=" + this._password + "; Max Pool Size=" + this._max_sessions + ";";
        }

        #endregion

        #region Constructor

        public MSSQLConnectionCredential() { }

        public MSSQLConnectionCredential(string ServerIP, string ServerName, string DatabaseName, string UserName, string Password) {

            this.ServerIP = ServerIP;
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.UserName = UserName;
            this.Password = Password;

        }

        #endregion

    }
}
