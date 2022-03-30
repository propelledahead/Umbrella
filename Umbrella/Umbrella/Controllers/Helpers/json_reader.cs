using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Umbrella.Controllers.Helpers {
    public static class json_reader {
        public static Object parse_json_to_object(Object ClassInstance, System.IO.Stream RequestBody) {
            var _result = ClassInstance;
            try {
                if (RequestBody != null) {
                    using (var _reader = new System.IO.StreamReader(
                            RequestBody,
                            encoding: System.Text.Encoding.UTF8,
                            detectEncodingFromByteOrderMarks: false,
                            bufferSize: 1024,
                            leaveOpen: true
                        )
                    ) {
                        string _raw_request = _reader.ReadToEnd();
                        if (!String.IsNullOrEmpty(_raw_request)) {
                            _result = Newtonsoft.Json.JsonConvert.DeserializeObject(_raw_request, ClassInstance.GetType());
                        }
                    }
                }
            } catch { }
            return _result;
        }
        //public json_helper() {}
    }
}