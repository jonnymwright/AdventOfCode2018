using System;
using System.Text.RegularExpressions;

namespace jonny.AoC.Day4
{

    public class LogEntry
    {
        public enum LogType
        {
            NewGuard,
            FallsAsleep,
            WakesUp
        }

        public DateTime EntryTime { get; private set; }
        public string Entry { get; private set; }

        public LogType Type { get; private set; }

        public int? GuardId { get; set; }

        public LogEntry(string logText)
        {
            // [1518-11-01 00:00] Guard #10 begins shift
            // [1518-11-01 00:05] falls asleep
            // [1518-11-01 00:25] wakes up
            Regex r = new Regex("\\[(.*)\\] (.*)");
            var match = r.Match(logText);
            EntryTime = DateTime.Parse(match.Groups[1].Value);
            Entry = match.Groups[2].Value;
            switch (Entry)
            {
                case "falls asleep":
                    Type = LogType.FallsAsleep;
                    break;
                case "wakes up":
                    Type = LogType.WakesUp;
                    break;
                default:
                    Type = LogType.NewGuard;
                    r = new Regex("Guard #(\\d+) begins shift");
                    match = r.Match(Entry);
                    GuardId = int.Parse(match.Groups[1].Value);
                    break;
            }
        }
    }
}