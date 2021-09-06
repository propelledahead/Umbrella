using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.Models;
using Umbrella.Models.User; // for receiving and response models
using Umbrella.BusinessLayer; // for business services BLLs
using Umbrella.Controllers.Helpers; // for json parser
using System.Reflection; // for controller helpers (json parser)
using System.Text.Json;


namespace Umbrella.Controllers {

    public class UserAPIController : Controller {


        public ActionResult users_all_read() {
            // Create a business logic instance and process request using business logic
            UserService _business_service = new UserService();
            List<user_read_response> _response = _business_service.users_all_read();
            return Json(new JSONWrapper(_response));
        }

        public ActionResult user_read() {
            // Parse/Map Request Stream (JSON) into a strongly typed Model Object
            user_read_request _request = (user_read_request)JsonHelper.parse_json_to_object(
                Assembly.GetExecutingAssembly().GetType("user_read_request")
                , Request.Body
            );
            // Create a business logic instance and process request using business logic
            UserService _business_service = new UserService();
            List<user_read_response> _response = _business_service.user_read(_request); 
            return Json(new JSONWrapper(_response));
        }


        public ActionResult SpeedTest() {
            return Json(new SpeedTestResponse());
        }




    }

}