using System.Collections.Generic;

namespace jonny.AoC.Day2 {
    public interface IPairingStrategy<T>
    {
        IEnumerable<System.Tuple<T, T>> GetPairs(IEnumerable<T> collection);
    }
}