using System;
using System.Collections.Generic;


namespace R5T.Kallithea.Default
{
    public class Context : IContext
    {
        protected Dictionary<string, object> KeyValuePairs { get; } = new Dictionary<string, object>();


        public void Add(string key, object value)
        {
            var alreadyExists = this.Exists(key);
            if (alreadyExists)
            {
                throw new Exception($"Unable to add key '{key}' since key already exists with value: {this.KeyValuePairs[key].ToString()}");
            }

            this.Set(key, value);
        }

        public bool Exists(string key)
        {
            var output = this.KeyValuePairs.ContainsKey(key);
            return output;
        }

        public object Get(string key)
        {
            var value = this.KeyValuePairs[key];
            return value;
        }

        public bool Remove(string key)
        {
            var output = this.KeyValuePairs.Remove(key);
            return output;
        }

        public void Set(string key, object value)
        {
            this.KeyValuePairs[key] = value;
        }
    }
}
