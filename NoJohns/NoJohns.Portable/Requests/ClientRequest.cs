using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoJohns.Portable.Requests
{
    public class ClientRequest : BaseRequest<Clients>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }


        public override IEnumerable<Clients> FilterRequest(IEnumerable<Clients> enumerable)
        {
            if (Id.HasValue)
                enumerable = enumerable.Where(client => client.Id == Id);

            if (!String.IsNullOrWhiteSpace(Name))
                enumerable = enumerable.Where(client => String.Equals(client.fName, Name, StringComparison.CurrentCultureIgnoreCase));

            if (!String.IsNullOrWhiteSpace(Username))
                enumerable = enumerable.Where(client => String.Equals(client.Username, Username, StringComparison.CurrentCultureIgnoreCase));

            return enumerable;
        }
    }
}
