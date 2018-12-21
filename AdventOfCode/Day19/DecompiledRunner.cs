namespace jonny.AoC.Day19 {
    public class DecompiledRunner {

        public long Run(int target) {
            int r1,r4;
            long r0=0;

            r4 = 1;

            while(r4 <=target) {
                r1 = 1;
                while(r4*r1<=target) {
                    if (r4*r1 == target)
                        r0 += r4;
                    r1++;
                }
                r4++;
            }
            return r0;
        }

    }
}