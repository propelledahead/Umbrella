using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Umbrella.Models.User; // for receiving and response models
using Microsoft.Data.SqlClient;
using Umbrella.Models.Framework;
using Microsoft.Extensions.Configuration;
using Umbrella.DataLayer.Helpers;

namespace Umbrella.DataLayer {
    public class UserDAO {

        #region Constructors
        private MSSQLHelper oMSSQLHelper;
        private MSSQLConnectionCredential oMSSQLConnectionCredential = new MSSQLConnectionCredential();
        private SecureConfiguration oSecureConfiguration = new SecureConfiguration();
        public UserDAO() {
            SecureConfiguration _SecureConfiguration = new SecureConfiguration();
            IConfiguration _Configuration = Configuration;
            _Configuration.GetSection("SecureConfiguration").Bind(this.oSecureConfiguration, c => c.BindNonPublicProperties = true);
            if(oSecureConfiguration.DBConnectionCredentials.Count > 0) {
                this.oMSSQLConnectionCredential = new MSSQLConnectionCredential(
                    oSecureConfiguration.DBConnectionCredentials[0].ServerIP
                    , oSecureConfiguration.DBConnectionCredentials[0].ServerName
                    , oSecureConfiguration.DBConnectionCredentials[0].DatabaseName
                    , oSecureConfiguration.DBConnectionCredentials[0].UserName
                    , oSecureConfiguration.DBConnectionCredentials[0].Password
                    , true
                );
            }
            this.oMSSQLHelper = new MSSQLHelper(this.oMSSQLConnectionCredential.ToConnectionString(true));
        }
        public IConfiguration Configuration { get; }
        #endregion

        #region Database Calls

        public List<user_read_response> users_read() {
            string _SQL = "SELECT * FROM users";
            SqlDataReader _oSqlDataReader = oMSSQLHelper.Query(_SQL);
            List<user_read_response> _result = _oSqlDataReader.map_data_reader_to_object_list<user_read_response>();

            // approach 2
            // logic here to map _oSqlDataReader to _oUserResponseModel
            //while (_oSqlDataReader.Read()) {
            // string _dataType = _oSqlDataReader.GetDataTypeName(_oSqlDataReader.GetOrdinal("id"));
            // var _id = _oSqlDataReader.GetValue(_oSqlDataReader.GetOrdinal("id")); // (Guid)_oSqlDataReader.GetValue(0);
            //  _oUserResponseModel.id = _id;
            //}
            return _result;
        }

        public List<user_read_response> user_details_read(user_read_request oModel) {
            Hashtable _parameters = new Hashtable();

            string _query = "SELECT * FROM users WHERE id = @id";
            _parameters.Add("id", oModel.user_guid);

            SqlDataReader _oSqlDataReader = oMSSQLHelper.Query(_query, _parameters);
            List<user_read_response> _result = _oSqlDataReader.map_data_reader_to_object_list<user_read_response>();
            return _result;
        }


        #endregion

    }
}
