using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella.DataLayer.Helpers {
    public class DatabaseParameterList {

        private List<DatabaseParameters> _oParams = new List<DatabaseParameters>();
        private string _param_prefix = "@";
        private string _param_suffix = "";

        public List<DatabaseParameters> Params {
            get { return this._oParams; }
        }
        public string ParamPrefix {
            get { return this._param_prefix; }
            set {
                this._param_prefix = value;
                if (this._oParams.Count > 0) {
                    for (int a = 0; a < this._oParams.Count; a++) {
                        this._oParams[a].ParamPrefix = this._param_prefix;
                    }
                }
            }
        }
        public string ParamSuffix {
            get { return this._param_suffix; }
            set {
                this._param_suffix = value;
                if (this._oParams.Count > 0) {
                    for (int a = 0; a < this._oParams.Count; a++) {
                        this._oParams[a].ParamSuffix = this._param_suffix;
                    }
                }
            }
        }

        public void Add(
            string ParamName
            , object ParamValue
        //  , DatabaseParameters.ParamDataType ParamType = DatabaseParameters.ParamDataType.StringType
        ) {
            this._oParams.Add(
                new DatabaseParameters(ParamName, ParamValue)
            );
            //this._oParams.Add(
            //    new DatabaseParameters(ParamName, ParamValue, ParamType)
            //);
        }
        public void Remove(string ParamName) {

        }
        public DatabaseParameterList() {

        }
    }
}