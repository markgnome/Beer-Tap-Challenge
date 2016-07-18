using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapHypermedia.DataAccess.Entities
{
    public class OfficeKeg : Office
    {
        public IEnumerable<Keg> Kegs { get; set; }
    }
}
