namespace jonny.AoC.Day20 {
    public class Room
    {
        public int Distance {get; set;}

        //0=N,1=E,2=W,3=S
        public Room[] Neighbours { get; } = new Room[4];

        public void RepairDistances(int distance) {
            if (distance < Distance) {
                Distance = distance;
                foreach (var n in Neighbours)
                {
                    if (n != null)
                        n.RepairDistances(++distance);
                }
            }
        }
    }
}