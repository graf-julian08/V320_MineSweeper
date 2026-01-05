using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public class Schwer : ISchwierigkeit
    {
        public int LiefereBreite() => 30; public int LiefereHoehe() => 16; public int LiefereMinenAnzahl() => 99;
    }
}
