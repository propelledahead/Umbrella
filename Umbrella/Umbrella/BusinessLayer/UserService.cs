using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbrella.Models.User;// for receiving and response models
using Umbrella.DataLayer;
using Umbrella.Controllers.Helpers;

namespace Umbrella.BusinessLayer {
    /// <summary>
    /// Business Layer Object for Users
    ///  Note: This is where when the app gets to a signifigant size we should replace this placeholder layer with IoC & DI
    /// </summary>

    public class UserService {

        public UserService() { }

        public Tuple<List<user_read_response>, JSONPagedWrapperMetadata> user_search(user_read_request oModel) {
            List<user_read_response> _result = new List<user_read_response>();
            JSONPagedWrapperMetadata _meta = new JSONPagedWrapperMetadata();
            _meta.results_per_page = 5;
            _meta.total_pages = 9000;
            try {
                // some sort of validation test here
                UserDAL _DAO = new UserDAL();
                _result = _DAO.user_details_read(oModel);
                _DAO.Disconnect();
            } catch { }
            //return _result;
            return Tuple.Create<List<user_read_response>, JSONPagedWrapperMetadata>(_result, _meta);
        }
        public List<user_read_response> user_read(user_read_request oModel) {
            List<user_read_response> _result = new List<user_read_response>();
            try {
                // some sort of validation test here
                UserDAL _DAO = new UserDAL();
                _result = _DAO.user_details_read(oModel);
                _DAO.Disconnect();
            } catch { }
            return _result;
        }
        public List<user_read_response> users_all_read() {
            List<user_read_response> _result = new List<user_read_response>();
            try {
                // some sort of validation test here
                UserDAL _DAO = new UserDAL();
                _result = _DAO.users_all_read();
                _DAO.Disconnect();
            } catch { }
            return _result;
        }

    }
}