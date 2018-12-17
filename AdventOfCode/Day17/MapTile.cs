using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day17 {
    internal class MapTile {
        internal enum MapType {
            Sand,
            Clay,
            StandingWater,
            FlowingWater,
            Source
        }

        private MapType type;
        private int x;
        private int y;
        private MapTile[,] map;
        private bool skip = false;

        public bool IsWater { get {
            return type == MapType.FlowingWater || type == MapType.StandingWater || type == MapType.Source;}
        }

        public bool IsStillWater {
            get {return type == MapType.StandingWater;}
        }

        internal MapTile(MapType type, int x, int y, MapTile[,] map) {
            this.type = type;
            this.x = x; 
            this.y = y;
            this.map = map;
        }

        public IEnumerable<MapTile> Tick() {
            if (skip) {
                skip = false; 
                return Enumerable.Empty<MapTile>();
            }
            if (map[y + 1, x].type == MapType.Sand) {
                // fill down
                int tempY = y + 1;
                int height = map.GetUpperBound(0);
                while (tempY <= height && map[tempY, x].type == MapType.Sand) {
                    map[tempY, x].type = MapType.FlowingWater;
                    tempY++;
                }
                if (tempY == height+1 || map[tempY, x].type == MapType.FlowingWater) {
                    return Enumerable.Empty<MapTile>();
                }
                return new [] {map[--tempY, x]};
            } else if (map[y + 1, x].type == MapType.FlowingWater) {
                return Enumerable.Empty<MapTile>();
            } else {
                // fill across
                List<MapTile> result = new List<MapTile>();
                List<MapTile> thisRow = new List<MapTile>{this};

                bool boundedLeft = false;
                bool flowLeft = false;
                bool boundedRight = false;
                bool flowRight = false;
                int tempX = x;
                while (!boundedLeft && ! flowLeft) {
                    tempX--;
                    if (tempX < 0) {
                        flowLeft = true;
                    } else {
                        thisRow.Add(map[y, tempX]);
                        if (map[y+1, tempX].type == MapType.Sand) {
                            flowLeft = true;
                            result.Add(map[y, tempX]);
                        } else if (map[y, tempX].type == MapType.Clay) {
                            boundedLeft = true;
                            thisRow.Remove(map[y, tempX]);
                        } else if (map[y, tempX].type == MapType.FlowingWater) {
                            if (map[y-1, tempX].type == MapType.FlowingWater) 
                                result.Add(map[y-1, tempX]);
                            map[y, tempX].skip = true;
                        }
                    }
                }

                tempX = x;
                while (!boundedRight && ! flowRight) {
                    tempX++;
                    int width = map.GetUpperBound(1);
                    if (tempX == width + 1) {
                        flowRight = true;
                    } else {
                        thisRow.Add(map[y, tempX]);
                        if (map[y+1, tempX].type == MapType.Sand) {
                            flowRight = true;
                            result.Add(map[y, tempX]);
                        } else if (map[y, tempX].type == MapType.Clay) {
                            boundedRight = true;
                            thisRow.Remove(map[y, tempX]);
                        } else if (map[y, tempX].type == MapType.FlowingWater) {
                            if (map[y-1, tempX].type == MapType.FlowingWater) 
                                result.Add(map[y-1, tempX]);
                            map[y, tempX].skip = true;
                        }
                    }
                }

                if (boundedLeft && boundedRight) {
                    if (map[y-1, x].type == MapType.FlowingWater) 
                        result.Add(map[y-1, x]);
                    foreach(var tile in thisRow) {
                        tile.type = MapType.StandingWater;
                    }
                } else {
                    foreach(var tile in thisRow) {
                        tile.type = MapType.FlowingWater;
                    }
                }

                return result;
            }
        }

        public override string ToString() {
            switch (type) {
                case MapType.Sand:
                    return ".";
                case MapType.Clay:
                    return "#";
                case MapType.StandingWater:
                    return "~";
                case MapType.FlowingWater:
                    return "|";
                case MapType.Source:
                    return "+";
            }
            return "";
        }
    }
}