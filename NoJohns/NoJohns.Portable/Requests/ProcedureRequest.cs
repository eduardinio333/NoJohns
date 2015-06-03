using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoJohns.Portable.Requests
{
    class ProcedureRequest : BaseRequest <Procedures>
    {
        int? Type { get; set; }

        public override IEnumerable<Procedures> FilterRequest(IEnumerable<Procedures> enumerable)
        {
            if (Type.HasValue)
                enumerable = enumerable.Where(c => c.TypesId == Type);

            return enumerable;
        }
    }
}
