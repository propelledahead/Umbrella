using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Umbrella.DataLayer.Helpers {
    public interface DataAccessLayerInterface {


        SqlConnection OpenConnectionGet();

        string get_thing();

    }

    class DataAccessLayerService : DataAccessLayerInterface {

        private SqlConnection _SqlConnection;
        private string _ConnectionString = "";
        private string _something = "";

        public SqlConnection OpenConnectionGet() {
            return this._SqlConnection;
        }


        public string get_thing() {

            string _result = "rocks";
            if (!string.IsNullOrEmpty(this._something)) {
                _result = this._something;
            }
            return _result;
        }

        public DataAccessLayerService() { 
        
        }
        public DataAccessLayerService(string MyThing) {
            this._something = MyThing;
        }

    }


}
