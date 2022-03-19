using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; // database connector
using Umbrella.Abstracts; // get configuration
using Microsoft.Extensions.Configuration; // read app settings

namespace Umbrella.DataLayer.Helpers {
    public interface data_access_layer_interface {
        bool is_database_connected();
        void database_connect();
        void database_disconnect();
        SqlConnection database_connection_get();
        SqlDataReader database_query(string SQL);
        SqlDataReader database_query(string SQL, database_parameters_list o_database_parameters_list);
        int database_execute(string SQL);
        int database_execute(string SQL, database_parameters_list o_database_parameters_list);
    }

    public class data_access_layer_service : data_access_layer_interface {
        private SqlConnection _SqlConnection;
        private string _cached_connection_string = "";
        public bool is_database_connected() {
            bool _result = false;
            if (this._SqlConnection != null && this._SqlConnection.State == System.Data.ConnectionState.Open) {
                _result = true;
            }
            return _result;
        }
        public void database_connect() {
            if (!this.is_database_connected()) {
                try {
                    if (String.IsNullOrEmpty(this._cached_connection_string)) {
                        this._cached_connection_string = AppSettings.Configuration.GetValue<string>("ConnectionStrings:DefaultDNS");
                    }
                    this._SqlConnection = new SqlConnection(this._cached_connection_string);
                    this._SqlConnection.Open();
                } catch {
                    this._cached_connection_string = "";
                }
                if (!this.is_database_connected()) {
                    try {
                        if (String.IsNullOrEmpty(this._cached_connection_string)) {
                            this._cached_connection_string = AppSettings.Configuration.GetValue<string>("ConnectionStrings:DefaultIP");
                        }
                        this._SqlConnection = new SqlConnection(this._cached_connection_string);
                        this._SqlConnection.Open();
                    } catch {
                        this._cached_connection_string = "";
                    }
                }
            }
        }
        public void database_disconnect() {
             try {
                if (this._SqlConnection != null) {
                    this._SqlConnection.Close();
                }
            } catch { }
        }
        public SqlConnection database_connection_get() {
            return this._SqlConnection;
        }
        public SqlDataReader database_query(string SQL) {
            SqlDataReader _result = null;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            this.database_connect();
            if (this.is_database_connected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                _result = _SqlCommand.ExecuteReader();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _result;
        }
        public SqlDataReader database_query(string SQL, database_parameters_list o_database_parameters_list) {
            SqlDataReader _result = null;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            if (o_database_parameters_list.parameters.Count <= 0) {
                throw new ArgumentException("Parameter 'ParametersList' may not be null or empty.", "ParametersList");
            }
            this.database_connect();
            if (this.is_database_connected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                foreach (database_parameter_item _parameter in o_database_parameters_list.parameters) {
                    if (!String.IsNullOrEmpty(_parameter.ParamName) && !String.IsNullOrEmpty(_parameter.ParamName.Trim())) {
                        _SqlCommand.Parameters.AddWithValue(_parameter.ParamNameEncapsulated, _parameter.ParamValue);
                    }
                }
                _result = _SqlCommand.ExecuteReader();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _result;
        }
        public int database_execute(string SQL) {
            int _rows_affected = 0;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            this.database_connect();
            if (this.is_database_connected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                _rows_affected = _SqlCommand.ExecuteNonQuery();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _rows_affected;
        }
        public int database_execute(string SQL, database_parameters_list o_database_parameters_list) {
            int _rows_affected = 0;
            if (String.IsNullOrEmpty(SQL)) {
                throw new ArgumentException("Parameter 'SQL' may not be null or empty.", "SQL");
            }
            if (o_database_parameters_list.parameters.Count <= 0) {
                throw new ArgumentException("Parameter 'ParametersList' may not be null or empty.", "ParametersList");
            }
            this.database_connect();
            if (this.is_database_connected()) {
                SqlCommand _SqlCommand = new SqlCommand(SQL, this._SqlConnection);
                foreach (database_parameter_item _parameter in o_database_parameters_list.parameters) {
                    if (!String.IsNullOrEmpty(_parameter.ParamName) && !String.IsNullOrEmpty(_parameter.ParamName.Trim())) {
                        _SqlCommand.Parameters.AddWithValue(_parameter.ParamNameEncapsulated, _parameter.ParamValue);
                    }
                }
                _rows_affected = _SqlCommand.ExecuteNonQuery();
            } else {
                throw new ApplicationException("Unable to establish a connection to the database.");
            }
            return _rows_affected;
        }
        public data_access_layer_service() { 
        
        }
    }


}
