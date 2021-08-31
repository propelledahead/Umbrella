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
using Umbrella.ControllersHelpers; // for json parser
using System.Reflection; // for controller helpers (json parser)
using System.Text.Json;

namespace Umbrella.Controllers {

    public class UserAPIController : Controller {


        public ActionResult users_get() {
            // Parse/Map Request Stream (JSON) into a strongly typed Model Object
            user_read_request _request = (user_read_request)JsonHelper.parse_json_to_object(
                Assembly.GetExecutingAssembly().GetType("user_read_request")
                , Request.Body
            );
            // Create a business logic instance and process request using business logic
            UserService _business_service = new UserService();
            List<user_read_response> _response = _business_service.users_get(_request);
            return Json(_response, new Newtonsoft.Json.JsonSerializerSettings());
        }



        public ActionResult SpeedTest() {
            return Json(new SpeedTestResponse());
        }




    }

}