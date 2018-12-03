using System.Linq;
using System.Collections.Generic;

namespace jonny.AoC.Day3 {
    public class ClaimResolver {

        private readonly Claim[] claims;
        private static readonly int size = 1000;
        private static readonly string overlapMarker = "x";
        private readonly string[,] cloth;

        public int Overlapping {get; private set;}

        public string[] NonOverlappingClaims {get; private set;}

        public ClaimResolver(string[] claims) {
            this.claims = claims.Select(claim => new Claim(claim)).ToArray();
            cloth = new string[size, size];
        }

        public void PlaceClaims() {
            ISet<string> claimIds = new HashSet<string>(claims.Select(claim => claim.Id));

            foreach (var claim in claims)
            {
                for(int i = claim.Y; i < (claim.Y + claim.Height); i ++) {
                    for (int j = claim.X; j < (claim.X + claim.Length); j ++) {
                        if (cloth[i, j] == default(string)) {
                            cloth[i, j] = claim.Id;
                        } else {
                            claimIds.Remove(claim.Id);
                            if (cloth[i,j] != overlapMarker) {
                                claimIds.Remove(cloth[i,j]);
                                cloth[i,j] = overlapMarker;
                                Overlapping ++;
                            }
                        }
                    }
                }
            }

            NonOverlappingClaims = claimIds.ToArray();
        }

        public void PrintCloth(int xFrom, int xTo, int yFrom, int yTo) {
            for (int y = yFrom; y < yTo; y++)
            {
                for (int x = xFrom; x < xTo; x++)
                {

                    System.Console.Write((cloth[y,x] ?? string.Empty).PadLeft(4, ' ') );
                }
                System.Console.WriteLine();
            }
        }
    }
}