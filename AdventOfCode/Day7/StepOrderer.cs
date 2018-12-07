using System;
using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day7
{
    public class StepOrderer
    {
        private Step[] steps;

        public StepOrderer(string dependencies)
        {
            steps = dependencies.Split("\r")
                .Select(line => new Step(line))
                .ToArray();
        }

        public string GetOrder()
        {
            var byDependecy = GetDependencyGraph();

            foreach (var step in steps)
            {
                byDependecy[step.After].Add(step.Before);
            }

            var builder = new System.Text.StringBuilder();
            while (byDependecy.Any())
            {
                var candidates = byDependecy.Where(kvp => kvp.Value.Count() == 0);
                var nextStep = candidates.First().Key;
                byDependecy.Remove(nextStep);
                builder.Append(nextStep);

                foreach (var dependencies in byDependecy.Values)
                {
                    dependencies.Remove(nextStep);
                }
            }
            return builder.ToString();
        }

        public int GetTimings(int addtionalTimePerStep, int numberOfWorkers)
        {
            var byDependecy = GetDependencyGraph();

            var workersTime = Enumerable.Range(0, numberOfWorkers)
                .ToDictionary(worker => worker, woker => 0);
            var workersActivity = Enumerable.Repeat((char?) null, numberOfWorkers).ToList();
            int time;
            for (time = 0; byDependecy.Any(); time++)
            {
                workersTime = workersTime.ToDictionary(kvp => kvp.Key, kvp => kvp.Value == 0 ? 0 : kvp.Value - 1);

                var availableWorkers = workersTime.Where(kvp => kvp.Value == 0).ToList();
                foreach (var worker in availableWorkers)
                {
                    if (workersActivity[worker.Key].HasValue)
                    {
                        foreach (var dependencies in byDependecy.Values)
                        {
                            dependencies.Remove(workersActivity[worker.Key].Value);
                        }
                        workersActivity[worker.Key] = null;
                    }
                }
                foreach (var worker in availableWorkers)
                {
                    
                    if (byDependecy.Any(kvp => kvp.Value.Count() == 0)) {
                        var availableWork = byDependecy.Where(kvp => kvp.Value.Count() == 0).FirstOrDefault();
                        workersActivity[worker.Key] = availableWork.Key;
                        byDependecy.Remove(availableWork.Key);
                        workersTime[worker.Key] = availableWork.Key + addtionalTimePerStep - 'A' +1;
                    }
                }
            }
            
            return time + workersTime.Values.Max() - 1;
        }

        private Dictionary<char, List<char>> GetDependencyGraph() {
            var all = steps.Select(step => step.Before)
                .Union(steps.Select(step => step.After));

            var result = all
                .OrderBy(id => id)
                .ToDictionary(id => id, id => new List<char>());
            foreach (var step in steps)
            {
                result[step.After].Add(step.Before);
            }

            return result;
        }
    }
}