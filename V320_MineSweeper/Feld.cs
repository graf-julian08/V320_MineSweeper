using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public class Feld
    {
        public bool IstMine { get; set; }
        public bool IstAufgedeckt { get; set; }
        public int NachbarMinen { get; set; }

        public Feld Clone() => (Feld)this.MemberwiseClone();
    }
}