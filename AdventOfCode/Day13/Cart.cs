using System;
using System.Collections.Generic;

namespace jonny.AoC.Day13
{
    public class Cart
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private int velX;
        private int velY;

        private Queue<Action> intersectionAction;

        public Cart(int x, int y, char facing)
        {
            this.X = x;
            this.Y = y;

            switch (facing)
            {
                case '>':
                    velX = 1;
                    break;
                case '<':
                    velX = -1;
                    break;
                case 'v':
                    velY = 1;
                    break;
                case '^':
                    velY = -1;
                    break;
            }

            Action[] actions = {TurnLeft, TurnStraight, TurnRight};
            intersectionAction = new Queue<Action>(actions);
        }

        public void Tick(Func<int, int, TrackPiece> nextSpaceGetter) {
            X += velX;
            Y += velY;
            TrackPiece nextspace = nextSpaceGetter(X, Y);

            switch(nextspace) {
                case TrackPiece.LeadingCurve:
                    int temp = velX;
                    velX = velY;
                    velY = temp;
                    break;
                case TrackPiece.TrailingCurve:
                    temp = velX;
                    velX = -velY;
                    velY = -temp;
                    break;
                case TrackPiece.Intersection:
                    var action = intersectionAction.Dequeue();
                    action();
                    intersectionAction.Enqueue(action);
                    break;
            }
        }

        private void TurnLeft() {
            int temp = velX;
            velX = velY;
            velY = -temp;
        }
        private void TurnRight() {
            int temp = velX;
            velX = -velY;
            velY = temp;
        }
        private void TurnStraight() {}
    }
}