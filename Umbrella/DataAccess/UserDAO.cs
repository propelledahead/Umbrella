using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.Models.User.RequestModels;
using Umbrella.Models.User.ResponseModels;
using System.Collections;
using System.Data.SqlClient;
using Umbrella.DataAccess;


namespace Umbrella.DataAccess {
    public class UserDAO {
        MSSQLHelper oMSSQLHelper = new MSSQLHelper();

        public UserDAO() { }

        public List<user_read_response> UserRead() {
            string _SQL = "SELECT * FROM users";
            SqlDataReader _oSqlDataReader = oMSSQLHelper.Query(_SQL);
            List<user_read_response> _oModel = _oSqlDataReader.map_data_reader_to_object_list<user_read_response>();

            // approach 2
            // logic here to map _oSqlDataReader to _oUserResponseModel
            //while (_oSqlDataReader.Read()) {
            // string _dataType = _oSqlDataReader.GetDataTypeName(_oSqlDataReader.GetOrdinal("id"));
            // var _id = _oSqlDataReader.GetValue(_oSqlDataReader.GetOrdinal("id")); // (Guid)_oSqlDataReader.GetValue(0);
            //  _oUserResponseModel.id = _id;
            //}
            return _oModel;
        }

    }
}
