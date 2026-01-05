using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V320_MineSweeper
{
    public class ConsoleView
    {
        public void ZeigeBoard(Board board)
        {
            Console.Clear();
            Console.WriteLine("   " + string.Join(" ", System.Linq.Enumerable.Range(0, board.Breite).Select(i => i.ToString("D2"))));
            for (int y = 0; y < board.Hoehe; y++)
            {
                Console.Write(y.ToString("D2") + " ");
                for (int x = 0; x < board.Breite; x++)
                {
                    var f = board.GetField(x, y);
                    if (!f.IstAufgedeckt)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan; 
                        Console.Write(" . ");
                        Console.ResetColor();
                    }
                    else if (f.IstMine)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" M ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {f.NachbarMinen} ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

        public string LiefereEingabe()
        {
            Console.WriteLine("\nEingabe (x,y) oder 'u' für Undo:");
            return Console.ReadLine();
        }
    }
}
