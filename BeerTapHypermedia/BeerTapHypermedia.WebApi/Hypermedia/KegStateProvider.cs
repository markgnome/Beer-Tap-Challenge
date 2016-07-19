using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapHypermedia.Model;
using BeerTapHypermedia.Model.Enums;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermedia.WebApi.Hypermedia
{
    public class KegStateProvider : KegStateProvider<KegModel>
    {
    }

    public abstract class KegStateProvider<TKegResource> : ResourceStateProviderBase<TKegResource, KegState>
        where TKegResource : IStatefulResource<KegState>, IStatefulKeg
    {
        public override KegState GetFor(TKegResource resource)
        {
            return resource.KegState;
        }

        protected override IDictionary<KegState, IEnumerable<KegState>> GetTransitions()
        {
            return new Dictionary<KegState, IEnumerable<KegState>>
            {
                // from, to
                {
                   
                    KegState.Empty, new[]
                    {
                        KegState.Full
                    }

                },
                {
                    KegState.Full, new []
                    {
                        KegState.Reduced
                    }
                },
                {
                     KegState.Reduced, new []
                    {
                        KegState.Nearly
                    }
                },
                {
                     KegState.Nearly, new []
                    {
                        KegState.Empty
                    }
                }


            };


        }

        public override IEnumerable<KegState> All => EnumEx.GetValuesFor<KegState>();
    }
}
