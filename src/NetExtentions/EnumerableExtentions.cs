﻿using System;
using System.Collections.Generic;

namespace NetExtentions
{
    public static class EnumerableExtentions
    {
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int? start)
        {
            return Slice(source, start, null, null);
        }

        public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int? start, int? stop)
        {
            return Slice(source, start, stop, null);
        }

        static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int? start, int? stop, int? step)
        {
            if (source == null) throw new ArgumentNullException("source");

            if (step == 0) throw new ArgumentException("Step cannot be zero.", "step");

            IList<T> sourceCollection = source as IList<T> ?? new List<T>(source);

            // nothing to slice
            if (sourceCollection.Count == 0) yield break;

            // set defaults for null arguments
            int stepCount = step ?? 1;
            int startIndex = start ?? ((stepCount > 0) ? 0 : sourceCollection.Count - 1);
            int stopIndex = stop ?? ((stepCount > 0) ? sourceCollection.Count : -1);

            // start from the end of the list if start is negitive
            if (start < 0) startIndex = sourceCollection.Count + startIndex;

            // end from the start of the list if stop is negitive
            if (stop < 0) stopIndex = sourceCollection.Count + stopIndex;

            // ensure indexes keep within collection bounds
            startIndex = Math.Max(startIndex, (stepCount > 0) ? 0 : Int32.MinValue);
            startIndex = Math.Min(startIndex, (stepCount > 0) ? sourceCollection.Count : sourceCollection.Count - 1);
            stopIndex = Math.Max(stopIndex, -1);
            stopIndex = Math.Min(stopIndex, sourceCollection.Count);

            for (int i = startIndex; (stepCount > 0) ? i < stopIndex : i > stopIndex; i += stepCount)
            {
                yield return sourceCollection[i];
            }
        }
    }
}
