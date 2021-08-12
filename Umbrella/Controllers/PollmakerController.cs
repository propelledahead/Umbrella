using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbrella.Models.Pollmaker; // for receiving and response models
using Umbrella.BusinessServices; // for business services
using Umbrella.ControllersHelpers; // for json parser
using System.Reflection; // for controller helpers (json parser)

namespace Umbrella.Controllers {
    public class PollmakerController : Controller {

        public ActionResult Index() {
            return View();
        }

        public ActionResult api_call() {
            // Parse/Map Request Stream (JSON) into a strongly typed Model Object
            pollread_read_request _request = (pollread_read_request)json_helper.parse_json_to_object(
                Assembly.GetExecutingAssembly().GetType("pollread_read_request")
                , Request.InputStream
            );
            // Create a business logic instance and process request using business logic
            PollmakerService _business_service = new PollmakerService();
            List<pollread_read_response> _response = _business_service.api_call(_request);
            return Json(_response, JsonRequestBehavior.AllowGet);
        }





    }

}