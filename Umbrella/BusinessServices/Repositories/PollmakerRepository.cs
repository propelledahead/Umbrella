using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbrella.Models.Pollmaker.RequestModels;
using Umbrella.Models.Pollmaker.ResponseModels;

namespace Umbrella.BusinessServices.Repositories {

    public abstract class PollmakerRepository {
        public abstract bool PollCreate(pollread_read_request oUserRequestModel);
        public abstract pollread_read_response PollRead(pollread_read_request oUserRequestModel);
        public abstract bool PollUpdate(pollread_read_request oUserRequestModel);
        public abstract bool PollDelete(Guid oUserGuid);


    }

    //public class PollmakerRepository {

    //    public PollmakerRepository() { }

    //    public List<pollread_read_response> api_call(pollread_read_request oModel) {
    //        List<pollread_read_response> _result = new List<pollread_read_response>();
    //        try {
    //            // some sort of test here

    //        } catch { }
    //        return _result;
    //    }


    //}
}