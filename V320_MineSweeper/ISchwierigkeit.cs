using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public interface ISchwierigkeit
    {
        int LiefereBreite();
        int LiefereHoehe();
        int LiefereMinenAnzahl();
    }
}