using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public class Caretaker
    {
        private Stack<Memento> _historie = new Stack<Memento>();
        public void Save(Memento m) => _historie.Push(m);
        public Memento LiefereLetztenZustand() => _historie.Count > 0 ? _historie.Pop() : null;
        public bool HatHistorie => _historie.Count > 0;
    }
}
