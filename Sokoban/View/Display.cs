using System;
using Sokoban.Model;

namespace Sokoban.View
{
    public class Display
    {
        public void DisplayField(Field field,Player player,Obsticales obsticales, Boxes boxes)
        {
            string currCoordinate = "";
            
            for (int row = 0; row < field.Rows; row++)
            {
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
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write("▒ ");
                    } 
                }

                Console.WriteLine();
            }
        }
    }
}