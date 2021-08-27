using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Umbrella.Models.User; // for receiving and response models
using Microsoft.Data.SqlClient;



namespace Umbrella.DataLayer {
    public class UserDAO {
        MSSQLHelper oMSSQLHelper = new MSSQLHelper();

        public UserDAO() { }

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

    }
}
