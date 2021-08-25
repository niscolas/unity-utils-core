using System.Collections;
using System.Collections.Generic;
using niscolas.UnityExtensions;

namespace BestLostNFound
{
    public abstract class PluralDataWrapper<T> : List<T>
    {
        public PluralDataWrapper(IEnumerable<T> content) : base(content) { }

        public PluralDataWrapper(params T[] content) : base(content) { }
    }
}
