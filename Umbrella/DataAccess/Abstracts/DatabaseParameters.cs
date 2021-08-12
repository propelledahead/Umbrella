using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella.DataAccess {
    public class DatabaseParameters {

        //public enum ParamDataType {
        //      StringType = 1
        //    , IntType = 2
        //}

        private string _param_name = "";
        private object _param_value;
        private string _param_prefix = "@";
        private string _param_suffix = "";
        // private ParamDataType _ParamDataType = ParamDataType.StringType;

        public string ParamName {
            get { return this._param_name; }
            set {
                if (!String.IsNullOrEmpty(value) && value.Length > 0) {
                    this._param_name = value;
                }
            }
        }
        public string ParamNameEncapsulated {
            get { return (this._param_prefix + this._param_name + this._param_suffix); }
        }
        public object ParamValue {
            get { return this._param_value; }
            set { this._param_value = value; }
        }
        public string ParamPrefix {
            get { return this._param_prefix; }
            set { this._param_prefix = value; }
        }
        public string ParamSuffix {
            get { return this._param_suffix; }
            set { this._param_suffix = value; }
        }

        public DatabaseParameters(
              string myParamName
            , object myParamValue
        //  , ParamDataType myParamDataType = ParamDataType.StringType
        ) {
            System.Text.RegularExpressions.Regex oRegex = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            if (!String.IsNullOrEmpty(myParamName) && myParamName.Length > 0 && oRegex.IsMatch(myParamName)) {
                this._param_name = myParamName;
                this._param_value = myParamValue;
                //    this._ParamDataType = myParamDataType;
            } else {
                throw new ArgumentException("Parameter 'myParamName' may not be null or empty.", "myParamName");
            }
        }
    }
}