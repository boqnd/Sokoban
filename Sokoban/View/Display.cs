using System;
using Sokoban.Model;

namespace Sokoban.View
{
    public class Display
    {
        public void DisplayField(Field field,Player player,Obsticales obsticales, Boxes boxes)
        {
            string currCoordinate = "";

            for (int col = 0; col < field.Cols+2; col++)
            {
                Console.Write("▒ ");
            }
            Console.WriteLine();
            for (int row = 0; row < field.Rows; row++)
            {
                Console.Write("▒ ");
                for (int col = 0; col < field.Cols; col++)
                {
                    currCoordinate = row + " " + col;
                    
                    if (currCoordinate == player.Coordinates)
                    {
                        Console.Write("& ");
                    }
                    else if (boxes.BoxCoordinates.Contains(currCoordinate))
                    {
                        Console.Write("# ");
                    }
                    else if (boxes.GoalCoordinates.Contains(currCoordinate))
                    {
                        Console.Write("X ");
                    }
                    else if (obsticales.Coordinates.Contains(currCoordinate))
                    {
                        Console.Write("▒ ");
                    }
                    else
                    {
                        Console.Write("  ");
                    } 
                }
                Console.Write("▒ ");

                Console.WriteLine();
            }
            for (int col = 0; col < field.Cols+2; col++)
            {
                Console.Write("▒ ");
            }
        }

        public void DisplayLevel(int level)
        {
            Console.WriteLine(" _____  _____ _   _____________  ___   _   _ ");
            Console.WriteLine("/  ___||  _  | | / /  _  | ___ \\/ _ \\ | \\ | |");
            Console.WriteLine("\\ `--. | | | | |/ /| | | | |_/ / /_\\ \\|  \\| |");
            Console.WriteLine(" `--. \\| | | |    \\| | | | ___ \\  _  || . ` |");
            Console.WriteLine("/\\__/ /\\ \\_/ / |\\  \\ \\_/ / |_/ / | | || |\\  |");
            Console.WriteLine("\\____/  \\___/\\_| \\_/\\___/\\____/\\_| |_/\\_| \\_/");

            switch (level)
            {
                case 0:
                    Console.WriteLine("     _                        _                _  ");
                    Console.WriteLine("    | |                      | |              | | ");
                    Console.WriteLine("  __| | ___ _ __ ___   ___   | | _____   _____| | ");
                    Console.WriteLine(" / _` |/ _ \\ '_ ` _ \\ / _ \\  | |/ _ \\ \\ / / _ \\ | ");
                    Console.WriteLine("| (_| |  __/ | | | | | (_) | | |  __/\\ V /  __/ | ");
                    Console.WriteLine(" \\__,_|\\___|_| |_| |_|\\___/  |_|\\___| \\_/ \\___|_| ");
                    break;
                case 1:
                    Console.WriteLine(" _                _   __ ");
                    Console.WriteLine("| |              | | /  |");
                    Console.WriteLine("| | _____   _____| | `| |");
                    Console.WriteLine("| |/ _ \\ \\ / / _ \\ |  | |");
                    Console.WriteLine("| |  __/\\ V /  __/ | _| |_");
                    Console.WriteLine("|_|\\___| \\_/ \\___|_| \\___/");
                    break;
                case 2:
                    Console.WriteLine(" _                _   _____ ");
                    Console.WriteLine("| |              | | / __  \\");
                    Console.WriteLine("| | _____   _____| | `' / /'");
                    Console.WriteLine("| |/ _ \\ \\ / / _ \\ |   / /  ");
                    Console.WriteLine("| |  __/\\ V /  __/ | ./ /___");
                    Console.WriteLine("|_|\\___| \\_/ \\___|_| \\_____/");
                    break;
                case 3:
                    Console.WriteLine(" _                _   _____ ");
                    Console.WriteLine("| |              | | |____ |");
                    Console.WriteLine("| | _____   _____| |     / /");
                    Console.WriteLine("| |/ _ \\ \\ / / _ \\ |     \\ \\");
                    Console.WriteLine("| |  __/\\ V /  __/ | .___/ /");
                    Console.WriteLine("|_|\\___| \\_/ \\___|_| \\____/");
                    break;
            }
        }

        public void Congrats()
        {
            Console.Clear();
            Console.WriteLine("Congrats");
        }
    }
}