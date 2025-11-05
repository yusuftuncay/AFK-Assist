using System;

namespace AFK_Assist.Classes
{
    internal static class RandomDelay
    {
        // Index Pickawsd
        public static int NextIndex(Random random, int maxExclusive)
        {
            return random.Next(maxExclusive);
        }

        // Hold Key
        public static int KeyHold(Random random)
        {
            return random.Next(70, 161);
        }

        // Hold Mouse
        public static int MouseHold(Random random)
        {
            return random.Next(60, 141);
        }

        // Gap Between Keys
        public static int BetweenKeypress(Random random)
        {
            return random.Next(120, 360);
        }
    }
}
