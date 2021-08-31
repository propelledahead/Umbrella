using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.DataLayer.Helpers;

namespace Umbrella.Models.Framework {
    public class SecureConfiguration {

        private List<MSSQLConnectionCredential> _DBConnectionCredentials = new List<MSSQLConnectionCredential>();

        public List<MSSQLConnectionCredential>  DBConnectionCredentials {
            get { return this._DBConnectionCredentials; }
            set { this._DBConnectionCredentials = value; }
        }

        public SecureConfiguration() { }
    }


}
