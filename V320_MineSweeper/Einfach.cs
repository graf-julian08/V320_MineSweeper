using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public class Einfach : ISchwierigkeit
    {
        public int LiefereBreite() => 8; public int LiefereHoehe() => 8; public int LiefereMinenAnzahl() => 10;
    }
}
