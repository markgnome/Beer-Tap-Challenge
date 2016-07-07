using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapHypermedia.Model.Enums;

namespace BeerTapHypermedia.Model
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStatefulKeg
    {
        /// <summary>
        /// 
        /// </summary>
        KegState KegState { get; }
    }
}
