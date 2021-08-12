using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbrella.Models.User; // for receiving and response models


namespace Umbrella.BusinessServices.Repositories {
    public abstract class UserRepository {
        public abstract bool UserCreate(user_read_request oUserRequestModel);
        public abstract user_read_response UserRead();
        public abstract bool UserUpdate(user_read_request oUserRequestModel);
        public abstract bool UserDelete(Guid oUserGuid);

    }
}
