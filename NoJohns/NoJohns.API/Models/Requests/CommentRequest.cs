using NoJohns.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoJohns.API.Models.Requests
{

    class CommentRequest : BaseRequest <Comments>
    {
        public int? ClientId { get; set; }
        public string Comment { get; set; }
        public bool ClientType { get; set; }
        public override IEnumerable<Comments> FilterRequest(IEnumerable<Comments> enumerable)
        {
            if (ClientId.HasValue)
                enumerable = enumerable.Where(client => client.ClientId == ClientId);
            if (!String.IsNullOrWhiteSpace(Comment))
                enumerable = enumerable.Where(client => String.Equals(client.Comment, Comment, StringComparison.InvariantCultureIgnoreCase));
            return enumerable;
        }
    }
}
