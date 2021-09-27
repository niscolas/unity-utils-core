using System.Collections.Generic;

namespace BestLostNFound
{
    public abstract class PluralDataWrapper<T> : List<T>
    {
        public PluralDataWrapper(IEnumerable<T> content) : base(content) { }

        public PluralDataWrapper(params T[] content) : base(content) { }
    }
}