using V320_MineSweeper;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController controller = new GameController();

            Console.WriteLine("=== WILLKOMMEN ZU MINESWEEPER ===");

            try
            {
                controller.StartSpiel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}");
            }

            Console.WriteLine("\nDas Programm wird beendet. Auf Wiedersehen!");
        }
    }
}