using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Umbrella.DataLayer.Helpers {
    public interface DataAccessLayerInterface {


        //SqlConnection OpenConnectionGet();

        string we_eat();

    }

    public class DataAccessLayerService : DataAccessLayerInterface {

        //private SqlConnection _SqlConnection;
        //private string _ConnectionString = "";
        private string _food = "";

        //public SqlConnection OpenConnectionGet() {
        //    return this._SqlConnection;
        //}


        public string we_eat() {
            string _result = "rocks";
            if (!string.IsNullOrEmpty(this._food)) {
                _result = this._food;
            }
            return _result;
        }

        public DataAccessLayerService() { 
        
        }
        public DataAccessLayerService(string MyFood) {
            this._food = MyFood;
        }

    }


}
