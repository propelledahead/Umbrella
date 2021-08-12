using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.BusinessServices.Repositories;
using Umbrella.Models.User; // for receiving and response models


namespace Umbrella.Authorities
{
    public class UserAuthority
    {
        private UserRepository _UserRepository = null;

        public UserAuthority(UserRepository oUserRepository) {
            this._UserRepository = oUserRepository;
        }

        public bool UserCreate(user_read_request oModel) {
            bool _result = false;
            if (oModel == null) {
                throw new ArgumentNullException("oModel", "UserRequestModel must be populated.");
            }
            _result = this._UserRepository.UserCreate(oModel);
            return _result;
        }

    }
}
