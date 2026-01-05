using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public class Board
    {
        private Feld[,] _grid;
        public int Breite { get; private set; }
        public int Hoehe { get; private set; }

        public void Initialisiere(ISchwierigkeit strategie)
        {
            Breite = strategie.LiefereBreite();
            Hoehe = strategie.LiefereHoehe();
            _grid = new Feld[Hoehe, Breite];

            for (int y = 0; y < Hoehe; y++)
                for (int x = 0; x < Breite; x++)
                    _grid[y, x] = new Feld();

            PlatziereMinen(strategie.LiefereMinenAnzahl());
            BerechneNachbarn();
        }

        private void PlatziereMinen(int anzahl)
        {
            Random rand = new Random();
            int platziert = 0;
            while (platziert < anzahl)
            {
                int x = rand.Next(Breite);
                int y = rand.Next(Hoehe);
                if (!_grid[y, x].IstMine)
                {
                    _grid[y, x].IstMine = true;
                    platziert++;
                }
            }
        }

        private void BerechneNachbarn()
        {
            for (int y = 0; y < Hoehe; y++)
            {
                for (int x = 0; x < Breite; x++)
                {
                    if (_grid[y, x].IstMine) continue;
                    _grid[y, x].NachbarMinen = ZaehleUmgebendeMinen(x, y);
                }
            }
        }

        private int ZaehleUmgebendeMinen(int x, int y)
        {
            int count = 0; 
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    int nx = x + i, ny = y + j;
                    if (nx >= 0 && nx < Breite && ny >= 0 && ny < Hoehe && _grid[ny, nx].IstMine)
                        count++;
                }
            return count;
        }

        public bool Aufdecken(int x, int y)
        {
            if (x < 0 || x >= Breite || y < 0 || y >= Hoehe || _grid[y, x].IstAufgedeckt) return true;

            _grid[y, x].IstAufgedeckt = true;
            if (_grid[y, x].IstMine) return false;

            if (_grid[y, x].NachbarMinen == 0)
            {
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                        Aufdecken(x + i, y + j);
            }
            return true;
        }

        public bool IstGewonnen()
        {
            for (int y = 0; y < Hoehe; y++)
            {
                for (int x = 0; x < Breite; x++)
                {
                    if (!_grid[y, x].IstMine && !_grid[y, x].IstAufgedeckt)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Feld GetField(int x, int y) => _grid[y, x];

        public Memento ErstelleMemento() => new Memento(_grid, Hoehe, Breite);

        public void StelleWiederher(Memento m)
        {
            this._grid = m.Zustand;
            this.Hoehe = m.Hoehe;
            this.Breite = m.Breite;
        }
    }
}
