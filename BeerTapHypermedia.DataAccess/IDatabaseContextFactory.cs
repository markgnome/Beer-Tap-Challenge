using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapHypermedia.DataAccess
{
    public interface IDatabaseContextFactory<out T> where T : BeerTapContext
    {
        T CreateContext();
    }
}
