using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Umbrella.Controllers.Helpers {
    public class JSONWrapper {

        private object _body = "";
        private JSONWrapperMetadata _meta = new JSONWrapperMetadata();

        public object body {
            get { return this._body; }
            set { if (value != null) { this._body = value; } }
        }
        public JSONWrapperMetadata meta {
            get { return this._meta;  }
            set { if (value != null) { this._meta = value; } }
        }

        public JSONWrapper(object JsonBody) {
            this.body = JsonBody;
        }
        public JSONWrapper(object JsonBody, string ServiceEndPoint) {
            this.body = JsonBody;
            this.meta.endpoint = ServiceEndPoint;
        }
    }
    public class JSONWrapperMetadata {

        private string _endpoint = "";
        private string _info= "";
        private int _code = 1;
        private DateTime _called = DateTime.UtcNow; //.AddMinutes(1);

        public string called {
            get { return this._called.ToString("yyyy-MM-dd HH:mm:ss"); }
            set {
                if (value != null) {
                    try {

                        this._called = DateTime.Parse(value);
                    } catch { }
                }
            }
        }
        public int code {
            get { return this._code; }
            set { this._code = value; }
        }
        public string endpoint {
            get { return this._endpoint; }
            set { this._endpoint = value; }
        }
        public string info {
            get { return this._info; }
            set { this._info = value; }
        }
        public JSONWrapperMetadata() { }
    }

    public class JSONPagedWrapper {

        private object _body = "";
        private JSONPagedWrapperMetadata _meta = new JSONPagedWrapperMetadata();

        public object body {
            get { return this._body; }
            set { if (value != null) { this._body = value; } }
        }
        public JSONPagedWrapperMetadata meta {
            get { return this._meta; }
            set { if (value != null) { this._meta = value; } }
        }

        public JSONPagedWrapper(object JsonBody) {
            this.body = JsonBody;
        }
        public JSONPagedWrapper(object JsonBody, string ServiceEndPoint) {
            this.body = JsonBody;
            this.meta.endpoint = ServiceEndPoint;
        }
        public JSONPagedWrapper(object JsonBody, JSONPagedWrapperMetadata JsonMetaData,  string ServiceEndPoint) {
            this.body = JsonBody;
            this.meta = JsonMetaData;
            this.meta.endpoint = ServiceEndPoint;
        }
    }
    public class JSONPagedWrapperMetadata {

        private string _endpoint = "";
        private string _info = "";
        private int _code = 1;
        private int _current_page = 1;
        private int _total_pages = 1;
        private int _results_per_page = 1;
        private DateTime _called = DateTime.UtcNow; //.AddMinutes(1);

        public string called {
            get { return this._called.ToString("yyyy-MM-dd HH:mm:ss"); }
            set {
                if (value != null) {
                    try {

                        this._called = DateTime.Parse(value);
                    } catch { }
                }
            }
        }
        public int code {
            get { return this._code; }
            set { this._code = value; }
        }
        public string endpoint {
            get { return this._endpoint; }
            set { this._endpoint = value; }
        }
        public string info {
            get { return this._info; }
            set { this._info = value; }
        }
        public int current_page {
            get { return this._current_page; }
            set { this._current_page = value; }
        }
        public int total_pages {
            get { return this._total_pages; }
            set { this._total_pages = value; }
        }
        public int results_per_page{
            get { return this._results_per_page; }
            set { this._results_per_page = value; }
        }
        public JSONPagedWrapperMetadata() { }
    }
}
