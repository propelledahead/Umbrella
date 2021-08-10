using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;
using System.ComponentModel;

namespace Umbrella.DataAccess {
    public static class MSSQLDataReaderExtension
    {
        // Refer to FastMember (https://stackoverflow.com/questions/41040189/fastest-way-to-map-result-of-sqldatareader-to-object)
        public static List<T> map_data_reader_to_object_list<T>(this SqlDataReader oSqlDataReader) where T : new()
        {
            List<T> _results = null;
            var _entity = typeof(T);
            var _property_dictionary = new Dictionary<string, PropertyInfo>();
            try {
                if (oSqlDataReader != null && oSqlDataReader.HasRows) {
                    _results = new List<T>();
                    var _entity_properties = _entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    _property_dictionary = _entity_properties.ToDictionary(p => p.Name.ToUpper(), p => p);
                    while (oSqlDataReader.Read()) {
                        T newObject = new T();
                        for (int a = 0; a < oSqlDataReader.FieldCount; a++) {
                            if (_property_dictionary.ContainsKey(oSqlDataReader.GetName(a).ToUpper())) {
                                var _field = _property_dictionary[oSqlDataReader.GetName(a).ToUpper()];
                                if ((_field != null) && _field.CanWrite) {
                                    var Val = oSqlDataReader.GetValue(a);
                                    _field.SetValue(newObject, (Val == DBNull.Value) ? null : Val, null);
                                }
                            }
                        }
                        _results.Add(newObject);
                    }
                } else {
                    throw new ArgumentNullException("oSqlDataReader", "SqlDataReader must be populated.");
                }
            } catch {
                throw;
            }
            return _results;
        }
        public static List<T> map_data_reader_to_object<T>(this SqlDataReader oSqlDataReader) where T : new()
        {
            List<T> _results = null;
            var _entity = typeof(T);
            var _property_dictionary = new Dictionary<string, PropertyInfo>();
            try {
                if (oSqlDataReader != null && oSqlDataReader.HasRows) {
                    var Props = _entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    _property_dictionary = Props.ToDictionary(p => p.Name.ToUpper(), p => p);
                    oSqlDataReader.Read();
                    for (int Index = 0; Index < oSqlDataReader.FieldCount; Index++) {
                        if (_property_dictionary.ContainsKey(oSqlDataReader.GetName(Index).ToUpper())) {
                            var _field = _property_dictionary[oSqlDataReader.GetName(Index).ToUpper()];
                            if ((_field != null) && _field.CanWrite) {
                                var Val = oSqlDataReader.GetValue(Index);
                                _field.SetValue(_results, (Val == DBNull.Value) ? null : Val, null);
                            }
                        }
                    }
                } else {
                    throw new ArgumentNullException("oSqlDataReader", "SqlDataReader must be populated.");
                }
            } catch {
                throw;
            }
            return _results;
        }
    }


    public static class TypeConverterExtension {
        public static T ChangeType<T>(object value) {
            return (T) ChangeType(typeof(T), value);
        }
        public static object ChangeType(Type oDataType, object oDataValue) {
            object _result = new object();
            try {
                TypeConverter _oTypeConverter = TypeDescriptor.GetConverter(oDataType);
                _result = _oTypeConverter.ConvertFrom(oDataValue);
            } catch {
                throw new ArgumentException("MSSQLDataReaderExtension.ChangeType", "Error processing Data Type or Object Value.");
            }
            return _result;
        }
    }
}
