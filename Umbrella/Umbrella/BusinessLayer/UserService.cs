using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbrella.Models.User;// for receiving and response models
using Umbrella.DataLayer;
using Umbrella.Controllers.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Umbrella.DataLayer.Helpers;

namespace Umbrella.BusinessLayer {
    /// <summary>
    /// Business Layer Object for Users
    ///  Note: This is where when the app gets to a signifigant size we should replace this placeholder layer with IoC & DI
    /// </summary>

    public class UserService {

        public DataAccessLayerInterface _DataAccessLayerService;

        public UserService(DataAccessLayerInterface MyDataAccessLayerService) { 
            this._DataAccessLayerService = MyDataAccessLayerService;
        }

        public Tuple<List<user_read_response>, json_envelope_paged_metadata> user_search(user_read_request oModel) {
            List<user_read_response> _result = new List<user_read_response>();
            json_envelope_paged_metadata _meta = new json_envelope_paged_metadata();
            _meta.results_per_page = 5;
            _meta.total_pages = 9000;
            try {
                // some sort of validation test here
                //var services = this.HttpContext.RequestServices;
                //var log = (ILog)services.GetService(typeof(ILog));

                


                UserDAL _DAO = new UserDAL(this._DataAccessLayerService);
                _result = _DAO.user_details_read(oModel);
                _DAO.Disconnect();
            } catch { }
            //return _result;
            return Tuple.Create<List<user_read_response>, json_envelope_paged_metadata>(_result, _meta);
        }
        public List<user_read_response> user_read(user_read_request oModel) {
            List<user_read_response> _result = new List<user_read_response>();
            try {
                // some sort of validation test here
                UserDAL _DAO = new UserDAL(this._DataAccessLayerService);
                _result = _DAO.user_details_read(oModel);
                _DAO.Disconnect();
            } catch { }
            return _result;
        }
        public List<user_read_response> users_all_read() {
            List<user_read_response> _result = new List<user_read_response>();
            try {
                // some sort of validation test here
                UserDAL _DAO = new UserDAL(this._DataAccessLayerService);
                _result = _DAO.users_all_read();
                _DAO.Disconnect();
            } catch { }
            return _result;
        }

        public string thing_read() {
            string _result ="";
            try {
                // some sort of validation test here
                UserDAL _DAO = new UserDAL(this._DataAccessLayerService);
                _result = _DAO.thing_read();
                _DAO.Disconnect();
            } catch { }
            return _result;
        }

    }
}