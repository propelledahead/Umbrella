using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.ComponentModel;


namespace Umbrella.DataLayer.Helpers {
    public static class MSSQLDataReaderExtension {
        public static List<T> map_data_reader_to_object_list<T>(this SqlDataReader oSqlDataReader) where T : new() {
            List<T> _results = new List<T>();
            var _entity = typeof(T);
            var _property_dictionary = new Dictionary<string, PropertyInfo>();
            try {
                if (oSqlDataReader != null && oSqlDataReader.HasRows) {
                    var _entity_properties = _entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    _property_dictionary = _entity_properties.ToDictionary(p => p.Name.ToUpper(), p => p);
                    while (oSqlDataReader.Read()) {
                        T _row_object = new T();
                        foreach (PropertyInfo property in _entity_properties) {
                            try {
                                var _column_value = oSqlDataReader[property.Name];
                                if (_column_value != null && _column_value != DBNull.Value) {
                                    property.SetValue(_row_object, Convert.ChangeType(_column_value, property.PropertyType));
                                }
                            } catch { }
                        }
                        _results.Add(_row_object);
                    }
                }
            } catch { }
            return _results;
        }
    }
}
