using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public class Memento
    {
        public Feld[,] Zustand { get; }
        public int Hoehe { get; }
        public int Breite { get; }

        public Memento(Feld[,] grid, int h, int w)
        {
            Hoehe = h; Breite = w;
            Zustand = new Feld[h, w];
            for (int y = 0; y < h; y++)
                for (int x = 0; x < w; x++)
                    Zustand[y, x] = grid[y, x].Clone();
        }
    }
}
