﻿using System;
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
        private MSSQLHelper oMSSQLHelper = new MSSQLHelper();
        public DataAccessLayerInterface _DataAccessLayerService;

        #endregion
        #region Constructors
        public UserDAL(DataAccessLayerInterface MyDataAccessLayerService) {


            //var _MyDataAccessLayerService = (DataAccessLayerService)ServiceProvider.GetService(typeof(DataAccessLayerService));



            this._DataAccessLayerService = MyDataAccessLayerService;
        }
        #endregion

        #region Class Helpers
        public void Disconnect() {
            this.oMSSQLHelper.Disconnect();
        }

        #endregion

        #region Database Calls

        public List<user_read_response> users_all_read() {
            string _query = "SELECT * FROM fw_user";
            SqlDataReader _oSqlDataReader = oMSSQLHelper.Query(_query);
            List<user_read_response> _result = _oSqlDataReader.map_data_reader_to_object_list<user_read_response>();
            return _result;
        }

        public List<user_read_response> user_details_read(user_read_request oModel) {
            Hashtable _parameters = new Hashtable();
            string _query = "SELECT * FROM fw_user WHERE id = @id";
            _parameters.Add("id", oModel.user_guid);
            SqlDataReader _oSqlDataReader = oMSSQLHelper.Query(_query, _parameters);
            List<user_read_response> _result = _oSqlDataReader.map_data_reader_to_object_list<user_read_response>();
            return _result;
        }

        public string thing_read() {
            string _result = this._DataAccessLayerService.get_thing();
            return _result;
        }
        #endregion

    }
}
