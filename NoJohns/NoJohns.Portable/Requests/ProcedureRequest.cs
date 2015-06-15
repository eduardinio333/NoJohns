using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoJohns.Portable.Requests
{
    public class ProcedureRequest : BaseRequest <Procedures>
    {
        public int? Type { get; set; }
        public bool? Status { get; set; }
        public int? Price { get; set; }
        public override IEnumerable<Procedures> FilterRequest(IEnumerable<Procedures> enumerable)
        {
            
            if (Type.HasValue)
                enumerable = enumerable.Where(c => c.TypesId == Type);
            if (Status.HasValue)
                enumerable = enumerable.Where(c => Boolean.Equals(c.Status, Status));
            if (Price.HasValue)
                enumerable = enumerable.Where(c => c.Price == Price);

            return enumerable;
        }
    }
}
