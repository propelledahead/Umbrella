using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Umbrella.DataLayer.Helpers {
    public class database_parameters_list {
        private List<database_parameter_item> _parameters = new List<database_parameter_item>();
        private string _param_prefix = "@";
        private string _param_suffix = "";
        public List<database_parameter_item> parameters {
            get { return this._parameters; }
        }
        public string ParamPrefix {
            get { return this._param_prefix; }
            set {
                this._param_prefix = value;
                if (this._parameters.Count > 0) {
                    for (int a = 0; a < this._parameters.Count; a++) {
                        this._parameters[a].ParamPrefix = this._param_prefix;
                    }
                }
            }
        }
        public string ParamSuffix {
            get { return this._param_suffix; }
            set {
                this._param_suffix = value;
                if (this._parameters.Count > 0) {
                    for (int a = 0; a < this._parameters.Count; a++) {
                        this._parameters[a].ParamSuffix = this._param_suffix;
                    }
                }
            }
        }
        public void add_parameter(string ParamName, object ParamValue) {
            if (!String.IsNullOrEmpty(ParamName) && !String.IsNullOrEmpty(ParamName.Trim())) {
                if (this.is_parameter_present(ParamName) == false) {
                    this._parameters.Add(
                        new database_parameter_item(ParamName, ParamValue)
                    );
                } else {
                    throw new ApplicationException("Database Parameter name must be unique");
                }
            } else {
                throw new ApplicationException("Database Parameter name must have a non-blank value");
            }
        }
        public void add_null_parameter(string ParamName) {
            if (!String.IsNullOrEmpty(ParamName) && !String.IsNullOrEmpty(ParamName.Trim())) {
                if (this.is_parameter_present(ParamName) == false) {
                    this._parameters.Add(
                        new database_parameter_item(ParamName.Trim(), DBNull.Value)
                    );
                } else { 
                    throw new ApplicationException("Database Parameter name must be unique");
                }
            } else {
                throw new ApplicationException("Database Parameter name must have a non-blank value");
            }
        }
        public bool is_parameter_present(string ParamName) {
            bool _result = false;
            for (int a = 0;  a < this._parameters.Count; a++) {
                if (String.Compare(this._parameters[a].ParamName, ParamName, true) == 0) {
                    _result = true;
                    break;
                }    
            }
            return _result;
        }
        public void Remove(string ParamName) {

        }
        public database_parameters_list() {

        }
    }
}