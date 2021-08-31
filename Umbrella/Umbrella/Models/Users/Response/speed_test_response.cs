using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.Models.User {
    public class SpeedTestResponse {

        private Guid _id = Guid.NewGuid();

        public string id {
            get { return this._id.ToString(); }
            set { this._id = Guid.Parse(value); }
        }

        public SpeedTestResponse() { }
    }

}
