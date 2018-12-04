using System;
using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day4
{
    public class WatchWatcher
    {

        private LogEntry[] entries;
        public WatchWatcher(string log)
        {
            entries = log.Split("\r")
                .Select(line => new LogEntry(line))
                .OrderBy(logLine => logLine.EntryTime)
                .ToArray();
        }

        public int SleepiestGuard()
        {
            Dictionary<int, int> sleepingMinutesByGuard;
            Dictionary<int, int[]> sleepingTimesByGuard;
            (sleepingMinutesByGuard, sleepingTimesByGuard) = PopulateMaps();

            var bestSleeper = sleepingMinutesByGuard.Aggregate((curr, best) => curr.Value > best.Value ? curr : best).Key;
            var bestMinute = sleepingTimesByGuard[bestSleeper]
                .Select((count, i) => new { count, i })
                .Aggregate((curr, best) => curr.count > best.count ? curr : best).i;
            return bestSleeper * bestMinute;
        }

        public int SleepiestMinute()
        {
            Dictionary<int, int> sleepingMinutesByGuard;
            Dictionary<int, int[]> sleepingTimesByGuard;
            (sleepingMinutesByGuard, sleepingTimesByGuard) = PopulateMaps();

            int bestMinute = 0;
            int bestCount = 0;
            int bestGuard = 0;
            foreach (var kvp in sleepingTimesByGuard)
            {
                var pair = kvp.Value
                    .Select((count, i) => new { Minute = i, Frequency = count })
                    .Aggregate((best, curr) => best.Frequency > curr.Frequency ? best : curr);

                if (pair.Frequency > bestCount)
                {
                    bestCount = pair.Frequency;
                    bestGuard = kvp.Key;
                    bestMinute = pair.Minute;
                }
            }
            return bestGuard * bestMinute;
        }

        private (Dictionary<int, int>, Dictionary<int, int[]>) PopulateMaps() {
            int currentGuardId = 0;
            DateTime asleepFrom = default(DateTime);
            Dictionary<int, int> sleepingMinutesByGuard = new Dictionary<int, int>();
            Dictionary<int, int[]> sleepingTimesByGuard = new Dictionary<int, int[]>();
            foreach (var entry in entries)
            {
                switch (entry.Type)
                {
                    case LogEntry.LogType.NewGuard:
                        currentGuardId = entry.GuardId.Value;
                        if (!sleepingMinutesByGuard.ContainsKey(currentGuardId))
                        {
                            sleepingMinutesByGuard[currentGuardId] = 0;
                            sleepingTimesByGuard[currentGuardId] = new int[60];
                        }
                        break;
                    case LogEntry.LogType.FallsAsleep:
                        asleepFrom = entry.EntryTime;
                        break;
                    case LogEntry.LogType.WakesUp:
                        TimeSpan span = entry.EntryTime.Subtract(asleepFrom);
                        sleepingMinutesByGuard[currentGuardId] += span.Minutes;
                        for (int i = asleepFrom.Minute; i < entry.EntryTime.Minute; i++)
                        {
                            sleepingTimesByGuard[currentGuardId][i]++;
                        }
                        break;
                    default:
                        break;
                }
            }

            return (sleepingMinutesByGuard, sleepingTimesByGuard);
        }
    }
}