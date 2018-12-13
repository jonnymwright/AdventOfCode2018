using System;
using System.Collections.Generic;
using System.Linq;

namespace jonny.AoC.Day13 {
    public class TrackTracker
    {
        public TrackPiece[,] Tracks { get; } 
        public List<Cart> Carts { get; }
        private Tuple<int, int> firstCrash;
        public TrackTracker(string[] unparsed) {
            Tracks = new TrackPiece[unparsed.Length, unparsed[0].Length];
            Carts = new List<Cart>();

            int y=0;
            foreach (string  line in unparsed)
            {
                for (int x = 0; x < line.Length; x++)
                {
                    switch (line[x]) {
                        case '>':
                        case '<':
                        case 'v':
                        case '^':
                            Carts.Add(new Cart(x, y, line[x]));
                            //fall through
                            goto case '-';
                        case '-':
                        case '|':
                            Tracks[y,x] = TrackPiece.Straight;
                            break;
                        case '/':
                            Tracks[y,x] = TrackPiece.TrailingCurve;
                            break;
                        case '\\':
                            Tracks[y,x] = TrackPiece.LeadingCurve;
                            break;
                        case '+':
                            Tracks[y,x] = TrackPiece.Intersection;
                            break;
                        case ' ':
                            Tracks[y,x] = TrackPiece.Blank;
                            break;
                    }
                }
                y++;
            }
        }

        public IEnumerable<Cart> Tick() {
            ISet<Cart> crashedCarts = new HashSet<Cart>();
            foreach(var cart in Carts.OrderBy(c => c.Y).ThenBy(c => c.X)) {
                cart.Tick((x, y) => Tracks[y,x]);
                Cart crashedCart = Carts.Except(new[] {cart})
                    .Where(c => c.Y == cart.Y && c.X == cart.X)
                    .FirstOrDefault();
                if (crashedCart != null) {
                    firstCrash = new Tuple<int, int>(cart.X, cart.Y);
                    crashedCarts.Add(cart);
                    crashedCarts.Add(crashedCart);
                }
            }

            return crashedCarts;
        }

        public Tuple<int, int> RunUntilCrash() {
            while (firstCrash == default(Tuple<int, int>)) {
                Tick();
            }
            return firstCrash;
        }

        public Tuple<int, int> RunUntilOneLeft() {
            while (Carts.Count > 1) {
                var toRemove = Tick();

                foreach (var cart in toRemove) {
                    Carts.Remove(cart);
                }
            }
            var survivor = Carts[0];
            return new Tuple<int, int>(survivor.X, survivor.Y);
        }
    }
}