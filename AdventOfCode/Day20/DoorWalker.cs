using System;
using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day20 {
    public class DoorWalker
    {
        private class State {
            public int Distance {get {return Room.Distance;}}
            public Room Room {get; set;}
            public int X {get; set;}
            public int Y {get; set;}
            public int Step {get; set;}

            public Stack<int> Return {get; private set;} = new Stack<int>();

            public State ShallowCopy() {
                return new State {
                    Room = Room,
                    X = X,
                    Y = Y,
                    Step = Step,
                    Return = new Stack<int>(Return)
                };
            }
        }

        private HashSet<Tuple<int, int, int>> exploredStates = new HashSet<Tuple<int, int, int>>();
        
        public int Closed {get; private set;}

        private Stack<State> history;
        private State current;

        private Dictionary<int, Dictionary<int, Room>> map;

        public DoorWalker() {
            current = new State{
                Room = new Room(),
                Step = 1
            };
            history = new Stack<State>();
            history.Push(current);
        }

        public void Walk(string path) {
            map = new Dictionary<int, Dictionary<int, Room>>{
                {0, new Dictionary<int, Room>()}
            };
            map[0][0] = current.Room;
            while (history.Any()) {
                bool move = false;
                int roomIndex = -1;
                switch (path[current.Step]) {
                    case 'N':
                        roomIndex = 0;
                        current.Y++;
                        move = true;
                        break;
                    case 'E':
                        roomIndex = 1;
                        current.X++;
                        move = true;
                        break;
                    case 'W':
                        roomIndex = 2;
                        current.X--;
                        move = true;
                        break;
                    case 'S':
                        roomIndex = 3;
                        current.Y--;
                        move = true;
                        break;
                    case '$':
                        current = history.Pop();
                        break;
                    case '(':
                        Branch(path);
                        break;
                    case '|':
                        current.Step = current.Return.Pop();
                        CheckClosingOff();
                        break;
                    case ')':
                        current.Return.Pop();
                        CheckClosingOff();
                        break;
                }
                if (move) {
                    Room next;
                    if (TryGetRoom(current.X, current.Y, out next)) {
                        current.Room.RepairDistances(next.Distance + 1);
                    } else {
                        next = new Room {Distance = current.Distance + 1};
                        PlaceRoom(current.X, current.Y, next);
                    }
                    current.Room.Neighbours[roomIndex] = next;
                    next.Neighbours[3 - roomIndex] = current.Room;
                    current.Room = next;
                }
                current.Step ++;
            }

        }

        public int FurthestRoom() {
            var distances = map.SelectMany(kvp => kvp.Value.Select(k => k.Value.Distance));
            return distances.Max();
        }

        public int FarRooms(int threshold) {
            var distances = map.SelectMany(kvp => kvp.Value.Select(k => k.Value.Distance));
            distances = distances.Where(d => d >= threshold);
            return distances.Count();
        }

        private void Branch(string path) {
            int depth = 1;
            List<State> clones = new List<State>{current};
            for (int i = current.Step+1; depth>0; i++) {
                switch (path[i]) {
                    case '(':
                        depth++;
                        break;
                    case '|':
                        if (depth == 1) {
                            var clone = current.ShallowCopy();
                            clone.Step = i;
                            history.Push(clone);
                            clones.Add(clone);
                        }
                        break;
                    case ')':
                        depth--;
                        if (depth == 0) {
                            foreach(var clone in clones) {
                                clone.Return.Push(i);
                            }
                        }
                        break;
                }
            }
        }

        private bool TryGetRoom(int x, int y, out Room room) {
            Dictionary<int, Room> row;
            if (!map.TryGetValue(y, out row)) {
                room = null;
                return false;
            }
            return row.TryGetValue(x, out room);
        }

        private void PlaceRoom(int x, int y, Room room) {
            Dictionary<int, Room> row;
            if (!map.TryGetValue(y, out row)) {
                row = new Dictionary<int, Room>();
                map[y] = row;
            }
            row[x] = room;
        }

        private void CheckClosingOff() {
            Tuple<int,int,int> state = new Tuple<int, int, int>(current.X, current.Y, current.Step);
            if (exploredStates.Contains(state)) {
                current = history.Pop();
                Closed++;
            } else {
                exploredStates.Add(state);
            }
        }
    }
}