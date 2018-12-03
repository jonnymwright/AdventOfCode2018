using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day2 {
    public class NiavePairingStrategy<T> : IPairingStrategy<T>
    {
        public IEnumerable<System.Tuple<T, T>> GetPairs(IEnumerable<T> collection) {
            var array = collection.ToArray();
            for (int i = 0; i < array.Count(); i++)
            {
                for (int j = 0; j < i; j++) {
                    yield return new System.Tuple<T, T>(array[i], array[j]);
                }
            }
        }

        public IEnumerable<System.Tuple<T, T>> GetPairs(IEnumerable<T> first, IEnumerable<T> second) {
            var firstArray = first.ToArray();
            var secondArray = second.ToArray();
            for (int i = 0; i < first.Count(); i++)
            {
                for (int j = 0; j < second.Count(); j++) {
                    yield return new System.Tuple<T, T>(firstArray[i], secondArray[j]);
                }
            }
        }
    }
}