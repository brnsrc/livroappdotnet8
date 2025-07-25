using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public enum WondersOfTheAncientWorld : byte
    {
        None = 0b_0000_0000, //i.e. 0
        GreatPyramidOfGiza = 0b_0000_0001, //i.e. 1
        HangingGardensOfBabylon = 0b_0000_0010, //i.e. 2
        StatueOfZeusAtOlymmpia = 0b_0000_0100, //i.e. 4
        TempleOfArtemisAtEphesus = 0b_0000_1000, //i.e. 8
        MausoleumAtHalicarnassus = 0b_0001_0000, //i.e. 16
        ColossusOfRhode = 0b_0010_0000, //i.e. 32
        LighthouseOfAlexandria = 0b_0100_0000 //i.e. 64
    }
}