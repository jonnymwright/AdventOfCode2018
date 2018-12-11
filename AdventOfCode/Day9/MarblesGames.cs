using System.Collections.Generic;

namespace jonny.AoC.Day9 {
    public class MarblesGame {
        private Marble current;
        private int value;
        private int removedMultiple;
        private int backSpaces;
        private long[] scores;

        public MarblesGame(int players, int removedMultiple = 23, int backSpaces = 7) {
            this.removedMultiple = removedMultiple;
            this.backSpaces = backSpaces;
            scores = new long[players];
            current = new Marble {
                Value = value
            };
            current.Next = current;
            current.Previous = current;
        }

        public long[] Play(int turns) {
            for (int i=0; i< turns; i++) {
                TakeTurn();
            }
            return Scores();
        }

        public void TakeTurn() {
            value++;
            if (value % removedMultiple == 0) {
                RemoveMarble();
            } else {
                PlaceMarble();
            }
        }

        public long[] Scores() {
            return scores;
        }

        public string GameState() {
            var builder = new System.Text.StringBuilder();
            Marble next = current;

            do {
                builder.Append(next.Value + " ");
                next = next.Next;
            } while(next != current);
            return builder.ToString();
        }

        private void PlaceMarble() {
            current = current.Next;
            var newMarble = new Marble {
                Value = value,
                Next = current.Next,
                Previous = current
            };
            current.Next.Previous = newMarble;
            current.Next = newMarble;
            current = current.Next;
        }

        private void RemoveMarble() {
            var scoringPlayer = (value-1) % scores.Length;
            var toRemove = current;
            for(int i=0; i<backSpaces; i++) {
                toRemove = toRemove.Previous;
            }

            toRemove.Previous.Next = toRemove.Next;
            toRemove.Next.Previous = toRemove.Previous;
            current = toRemove.Next;

            scores[scoringPlayer] += toRemove.Value + value;
        }
    }
}