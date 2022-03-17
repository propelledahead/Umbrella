using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections;
using Microsoft.Extensions.Configuration;
using Umbrella.Abstracts;

namespace Umbrella.DataLayer.Helpers {
    public class MSSQLHelper {

        #region Globals
        private SqlConnection _SqlConnection;
        //private MSSQLConnectionCredential _SqlConnectionStringBuilder;
        private string _parameter_prefix = "@";
        private string _parameter_suffix = " ";
        private string _cached_connection_string = "";


        #endregion

        #region Public Methods
        public bool IsConnected() {
            bool _result = false;
            if (this._SqlConnection != null && this._SqlConnection.State == System.Data.ConnectionState.Open) {
                _result = true;
            }
            return _result;
        }
        public void Connect() {
            if (!this.IsConnected()) {
                try {
                    if (String.IsNullOrEmpty(this._cached_connection_string)) {
                        this._cached_connection_string = AppSettings.Configuration.GetValue<string>("ConnectionStrings:DefaultDNS");
                        //    this._cached_connection_string = this._SqlConnectionStringBuilder.ToConnectionString();
                    }
                    this._SqlConnection = new SqlConnection(this._cached_connection_string);
                    this._SqlConnection.Open();
                } catch {
                    this._cached_connection_string = "";
                }
                if (!this.IsConnected()) {
                    try {
                        if (String.IsNullOrEmpty(this._cached_connection_string)) {
                            this._cached_connection_string = AppSettings.Configuration.GetValue<string>("ConnectionStrings:DefaultIP");
                            //    this._SqlConnectionStringBuilder.PreferUsingServerIPAddress = false;
                            //    this._cached_connection_string = this._SqlConnectionStringBuilder.ToConnectionString();
                        }
                        this._SqlConnection = new SqlConnection(this._cached_connection_string);
                        this._SqlConnection.Open();
                    } catch {
                        this._cached_connection_string = "";
                    }
                }
            }
        }
        public void Disconnect() {
            // try {
            if (this._SqlConnection != null) {
                this._SqlConnection.Close();
            }
            //} catch { }
        }
        public SqlDataReader Query(string SQL) {
            SqlDataReader _SqlDataReader = null;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            this.Connect();
            if (this.IsConnected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                _SqlDataReader = _SqlCommand.ExecuteReader();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _SqlDataReader;
        }
        public SqlDataReader Query(string SQL, Hashtable ParametersList) {
            SqlDataReader _SqlDataReader = null;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            if (ParametersList.Count <= 0) {
                throw new ArgumentException("Parameter 'ParametersList' may not be null or empty.", "ParametersList");
            }
            this.Connect();
            if (this.IsConnected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                foreach (string ParamName in ParametersList.Keys) {
                    if (!String.IsNullOrEmpty(ParamName) && !String.IsNullOrEmpty(ParamName.Trim())) {
                        _SqlCommand.Parameters.AddWithValue(
                            (this._parameter_prefix + ParamName + this._parameter_suffix)
                            , ParametersList[ParamName]
                        );
                    }
                }
                _SqlDataReader = _SqlCommand.ExecuteReader();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _SqlDataReader;
        }
        public SqlDataReader Query(string SQL, DatabaseParameterList oDatabaseParameterList) {
            SqlDataReader _SqlDataReader = null;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            if (oDatabaseParameterList.Params.Count <= 0) {
                throw new ArgumentException("Parameter 'ParametersList' may not be null or empty.", "ParametersList");
            }
            this.Connect();
            if (this.IsConnected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                foreach (DatabaseParameters oParameter in oDatabaseParameterList.Params) {
                    _SqlCommand.Parameters.AddWithValue(oParameter.ParamNameEncapsulated, oParameter.ParamValue);
                }
                _SqlDataReader = _SqlCommand.ExecuteReader();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _SqlDataReader;
        }
        public int Execute(string SQL) {
            int _rows_affected = 0;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            this.Connect();
            if (this.IsConnected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                _rows_affected = _SqlCommand.ExecuteNonQuery();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _rows_affected;
        }
        public int Execute(string SQL, Hashtable ParametersList) {
            int _rows_affected = 0;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            if (ParametersList.Count <= 0) {
                throw new ArgumentException("Parameter 'ParametersList' may not be null or empty.", "ParametersList");
            }
            this.Connect();
            if (this.IsConnected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                foreach (string ParamName in ParametersList.Keys) {
                    if (!String.IsNullOrEmpty(ParamName) && !String.IsNullOrEmpty(ParamName.Trim())) {
                        _SqlCommand.Parameters.AddWithValue(
                            (this._parameter_prefix + ParamName + this._parameter_suffix)
                            , ParametersList[ParamName]
                        );
                    }
                }
                _rows_affected = _SqlCommand.ExecuteNonQuery();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _rows_affected;
        }

        #endregion

        #region Private Methods
        //private void ConnectionStringInitialize() {
        //    this._cached_connection_string = AppSettings.Configuration.GetValue<string>("ConnectionStrings:Defult-DNS");


        //    //string _server_name = AppSettings.Configuration.GetValue<string>("ConnectionStrings:ServerName");
        //    //string _server_ip_address = AppSettings.Configuration.GetValue<string>("ConnectionStrings:ServerIPAddress");
        //    //string _database_name = AppSettings.Configuration.GetValue<string>("ConnectionStrings:DatabaseName");
        //    //string _user_name = AppSettings.Configuration.GetValue<string>("ConnectionStrings:UserName");
        //    //string _password = AppSettings.Configuration.GetValue<string>("ConnectionStrings:Password");
        //    //this._SqlConnectionStringBuilder = new MSSQLConnectionCredential(
        //    //      _server_ip_address
        //    //    , _server_name
        //    //    , _database_name
        //    //    , _user_name
        //    //    , _password
        //    //);

        //}

        #endregion

        #region Constructor
        public MSSQLHelper() {
           // this.ConnectionStringInitialize();
            this.Connect();
        }

        #endregion


    }

}
