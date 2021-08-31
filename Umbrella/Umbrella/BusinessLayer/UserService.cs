using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbrella.Models.User;// for receiving and response models
using Umbrella.DataLayer;

namespace Umbrella.BusinessLayer {
    /// <summary>
    ///  Note: This is where when the app gets to a signifigant size we should replace this placeholder layer with IoC & DI
    ///  
    /// </summary>

    public class UserService {

        public UserService() { }

        public List<user_read_response> users_get(user_read_request oModel) {
            List<user_read_response> _result = new List<user_read_response>();
            try {
                // some sort of validation test here
                UserDAO _DAO = new UserDAO();
                _result = _DAO.user_details_read(oModel);
            } catch { }
            return _result;
        }


    }
}