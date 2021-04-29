using System;

namespace Octogotchi.FunctionApp
{
    [Flags]
    public enum OctogotchiStates
    {
        Egg = 1,
        Kid = 2,
        KidSleepy = 4,
        KidSad = 8,
        Adult = 16,
        AdultSleepy = 32,
        AdultSad = 64,
        AdultDead = 128,
        AdultGhost = 256,
    }
}