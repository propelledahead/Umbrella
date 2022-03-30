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
using Microsoft.Extensions.DependencyInjection;
using Umbrella.DataLayer.Helpers;

namespace Umbrella.Controllers {

    public class UserAPIController : Controller {


        public ActionResult users_all_read() {
            // api endpoint without any request model
            UserBLL _business_layer = new UserBLL(HttpContext.RequestServices.GetRequiredService<data_access_layer_interface>());
            List<user_read_response> _response = _business_layer.users_all_read();
            return Json(new json_envelope_simple(_response));
        }


        public ActionResult user_read() {
            // api endpoint with or without a request model
            user_read_request _request = new user_read_request();
            if (Request.Body != null) { _request = (user_read_request)json_reader.parse_json_to_object(new user_read_request(), Request.Body); }
            UserBLL _business_layer = new UserBLL(HttpContext.RequestServices.GetRequiredService<data_access_layer_interface>());
            List<user_read_response> _response = _business_layer.user_read(_request); 
            return Json(new json_envelope_simple(_response, "/UserAPI/user_read"));
        }

        public ActionResult user_search() {
            // api endpoint with or without a request model
            user_read_request _request = new user_read_request();
            if (Request.Body != null) { _request = (user_read_request)json_reader.parse_json_to_object(new user_read_request(), Request.Body); }
            UserBLL _business_layer = new UserBLL(HttpContext.RequestServices.GetRequiredService<data_access_layer_interface>());
            Tuple< List<user_read_response>, json_envelope_paged_metadata> _service_response = _business_layer.user_search(_request);
            return Json(new json_envelope_paged(_service_response.Item1, _service_response.Item2, "/UserAPI/user_search"));
        }


        public ActionResult SpeedTest() {
            return Json(new SpeedTestResponse());
        }




    }

}