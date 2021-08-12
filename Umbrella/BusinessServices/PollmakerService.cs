using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbrella.Models.Pollmaker;// for receiving and response models

namespace Umbrella.BusinessServices {

    public class PollmakerService {

        public PollmakerService() { }

        public List<pollread_read_response> api_call(pollread_read_request oModel) {
            List<pollread_read_response> _result = new List<pollread_read_response>();
            try {
                // some sort of validation test here

            } catch { }
            return _result;
        }


    }
}