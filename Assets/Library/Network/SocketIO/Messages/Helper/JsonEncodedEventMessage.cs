using System;
using System.Collections.Generic;
using System.Linq;
using LitJson;

//using SimpleJson.Reflection;

namespace SocketIO.Messages
{
    public class JsonEncodedEventMessage
    {
         public string Name { get; set; }

         public object[] Arguments { get; set; }

        public JsonEncodedEventMessage()
        {
        }
        
		public JsonEncodedEventMessage(string name, object payload) : this(name, new[]{payload})
        {

        }
        
		public JsonEncodedEventMessage(string name, object[] payloads)
        {
            this.Name = name;
            this.Arguments = payloads;
        }

        public T GetFirstArgAs<T>()
        {
            try
            {
                var firstArg = this.Arguments.FirstOrDefault();
                if (firstArg != null)
                    return JsonMapper.ToObject<T>(firstArg.ToString());
            }
            catch (Exception)
            {
                // add error logging here
                throw;
            }
            return default(T);
        }

        public IEnumerable<T> GetArgsAs<T>()
        {
            List<T> items = new List<T>();
            foreach (var i in this.Arguments)
            {
                items.Add(JsonMapper.ToObject<T>(i.ToString()));
            }
            return items.AsEnumerable();
        }

        public string ToJsonString()
        {
            return JsonMapper.ToJson(this);
        }

        public static JsonEncodedEventMessage Deserialize(string jsonString)
        {
            return JsonMapper.ToObject<JsonEncodedEventMessage>(jsonString);
        }
    }
}
