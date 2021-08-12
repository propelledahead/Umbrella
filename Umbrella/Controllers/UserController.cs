﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbrella.Models.User; // for receiving and response models
using Umbrella.BusinessServices.Repositories; // for business services
using Umbrella.ControllersHelpers; // for json parser
using System.Reflection; // for controller helpers (json parser)
using Umbrella.Authorities;

namespace Umbrella.Controllers {
    public class UserController : Controller {

        public ActionResult Index() {
            return View();
        }

        public ActionResult api_call() {
            // Parse/Map Request Stream (JSON) into a strongly typed Model Object
            user_read_request _request = (user_read_request)json_helper.parse_json_to_object(
                Assembly.GetExecutingAssembly().GetType("user_read_request")
                , Request.InputStream
            );
            // Create a business logic instance and process request using business logic
            UserAuthority _business_service = new UserAuthority();
            List<user_read_response> _response = _business_service.UserCreate(_request);
            return Json(_response, JsonRequestBehavior.AllowGet);
        }





    }

}