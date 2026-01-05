using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public class GameController
    {
        private Board _board = new Board();
        private Caretaker _caretaker = new Caretaker();
        private ConsoleView _view = new ConsoleView();

        public void StartSpiel()
        {
            Console.WriteLine("Schwierigkeit: 1 (Einfach), 2 (Mittel), 3 (Schwer)");
            string wahl = Console.ReadLine();
            ISchwierigkeit diff = wahl switch { "2" => new Mittel(), "3" => new Schwer(), _ => new Einfach() };

            _board.Initialisiere(diff);
            Run();
        }

        private void Run()
        {
            while (true)
            {
                _view.ZeigeBoard(_board);

                if (_board.IstGewonnen())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Gewonnen!");
                    Console.ResetColor();
                }

                string input = _view.LiefereEingabe();
                if (input.ToLower() == "u") { MacheRueckgaengig(); continue; }

                _caretaker.Save(_board.ErstelleMemento());

                try
                {
                    string[] parts = input.Split(',');
                    int x = int.Parse(parts[0]);
                    int y = int.Parse(parts[1]);

                    if (!_board.Aufdecken(x, y))
                    {
                        _view.ZeigeBoard(_board);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBOOM! Du bist auf eine Mine getreten.");
                        Console.ResetColor();
                        Console.WriteLine("Rückgängig machen? (j/n)");
                        if (Console.ReadLine().ToLower() == "j") MacheRueckgaengig();
                        else break;
                    }
                }
                catch { Console.WriteLine("Ungültige Eingabe! Bitte x,y verwenden."); }
            }
        }

        private void MacheRueckgaengig()
        {
            var m = _caretaker.LiefereLetztenZustand();
            if (m != null) _board.StelleWiederher(m);
            else Console.WriteLine("Kein Undo möglich!");
        }
    }
}
