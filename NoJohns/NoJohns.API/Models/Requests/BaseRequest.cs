using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoJohns.API.Models.Requests
{
    public abstract class BaseRequest
    {
        public string ToRequestString()
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
            return System.Convert.ToBase64String(plainTextBytes);            
        }

        public static T ToRequest<T>(string request)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(request);
            var text = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            return JsonConvert.DeserializeObject<T>(text);
        }
    }

    public abstract class BaseRequest<T> : BaseRequest
    {        
        public abstract IEnumerable<T> FilterRequest(IEnumerable<T> enumerable);
    }
}
