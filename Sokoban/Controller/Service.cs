using System;
using System.Collections.Generic;
using System.Linq;
using Sokoban.Model;
using Sokoban.View;

namespace Sokoban.Controller
{
    public class Service
    {
        private Player player;
        private Field field;
        private Obsticales obsticales;
        private Boxes boxes;
        private Display _display;
        
        public void StartUp()
        {
            player = new Player("0 0");
            field = new Field(5,5);
            obsticales = new Obsticales(new List<string>(){"0 3", "1 3","2 3", "2 2"});
            boxes = new Boxes
                (
                new List<string>(){"2 0","2 1"}, 
                new List<string>(){"4 4","4 3"}
                );
            _display = new Display();
            _display.DisplayField(field,player,obsticales,boxes);
            Play();
        }

        public void Play()
        {
            while (true)
            {
                Console.WriteLine();
                char input = Console.ReadKey().KeyChar;

                int playerOldRow = player.Coordinates.Split().Select(int.Parse).ToList()[0];
                int playerOldCol = player.Coordinates.Split().Select(int.Parse).ToList()[1];

                int playerRow = playerOldRow;
                int playerCol = playerOldCol;
                
                switch (input)
                {
                    case 'w':
                        playerRow--;
                        break;
                    case 'a':
                        playerCol--;
                        break;
                    case 's':
                        playerRow++;
                        break;
                    case 'd':
                        playerCol++;
                        break;
                }

                string newCoordinate = playerRow + " " + playerCol;
                
                if (playerRow >= field.Rows || 
                    playerRow < 0 || 
                    playerCol >= field.Cols || 
                    playerCol < 0 ||
                    obsticales.Coordinates.Contains(newCoordinate))
                {
                    playerRow = playerOldRow;
                    playerCol = playerOldCol;
                }

                if (boxes.BoxCoordinates.Contains(newCoordinate))
                {
                    int index = boxes.BoxCoordinates.IndexOf(newCoordinate);
                    
                    int boxRow = boxes.BoxCoordinates[index].Split().Select(int.Parse).ToList()[0];
                    int boxCol = boxes.BoxCoordinates[index].Split().Select(int.Parse).ToList()[1];
                    
                    switch (input)
                    {
                        case 'w':
                            boxRow--;
                            break;
                        case 'a':
                            boxCol--;
                            break;
                        case 's':
                            boxRow++;
                            break;
                        case 'd':
                            boxCol++;
                            break;
                    }

                    boxes.BoxCoordinates[index] = boxRow + " " + boxCol;
                }
                

                player.Coordinates = playerRow + " " + playerCol;
                
                Console.Clear();
                _display.DisplayField(field,player,obsticales,boxes);
            }
        }
    }
}