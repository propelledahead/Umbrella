using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.Data.SqlClient;
using Umbrella.DataLayer.Helpers;
using Umbrella.Models.User; // for receiving and response models
using Microsoft.Extensions.DependencyInjection;

namespace Umbrella.DataLayer {
    public class UserDAL {

        #region Globals
        public data_access_layer_interface _data_access_layer_service;


        #endregion
        #region Constructors

        public UserDAL(data_access_layer_interface o_data_access_layer_service) {
            this._data_access_layer_service = o_data_access_layer_service;
        }
        
        #endregion
        #region Class Helpers
        
        public void database_disconnect() {
            this._data_access_layer_service.database_disconnect();
        }

        #endregion

        #region Database Calls

        public List<user_read_response> users_all_read() {
            string _query = "SELECT * FROM fw_user";
            SqlDataReader _oSqlDataReader = this._data_access_layer_service.database_query(_query);
            List<user_read_response> _result = _oSqlDataReader.map_data_reader_to_object_list<user_read_response>();
            return _result;
        }

        public List<user_read_response> user_details_read(user_read_request oModel) {
            database_parameters_list _parameters = new database_parameters_list();
            string _query = "SELECT * FROM fw_user WHERE id = @id";
            _parameters.add_parameter("id", oModel.user_guid);
            SqlDataReader _oSqlDataReader = this._data_access_layer_service.database_query(_query, _parameters);
            List<user_read_response> _result = _oSqlDataReader.map_data_reader_to_object_list<user_read_response>();
            return _result;
        }


        #endregion

    }
}
