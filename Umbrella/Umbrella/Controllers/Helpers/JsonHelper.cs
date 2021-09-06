using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Umbrella.Controllers.Helpers {
    public static class JsonHelper {
        public static Object parse_json_to_object(Type ClassModelType, System.IO.Stream InputStream) {
            //object _result = Activator.CreateInstance(ClassModelType);
            object _result = Activator.CreateInstance(ClassModelType.Assembly.FullName, ClassModelType.Name);
            try {
                string _json_request = "";
                using (System.IO.Stream _oRequestStream = InputStream) {
                    _oRequestStream.Seek(0, System.IO.SeekOrigin.Begin);
                    _json_request = new System.IO.StreamReader(_oRequestStream).ReadToEnd();
                }
                if (!String.IsNullOrEmpty(_json_request)) {
                    _result = Newtonsoft.Json.JsonConvert.DeserializeObject(_json_request, ClassModelType);
                }
            } catch { }
            return _result;               
        }
        //public json_helper() {}
    }
}