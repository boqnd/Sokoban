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

        private bool flag = true;
        private bool resetFlag = false;
        private int currLevel = 0;
        public void StartUp()
        {
            player = new Player("0 0");
            field = new Field(5,5);
            obsticales = new Obsticales(new List<string>(){"0 3", "1 3","2 3", "2 2"});
            boxes = new Boxes
                (
                new List<string>(){"2 0","2 1"}, 
                new List<string>(){"4 0","3 3"}
                );
            _display = new Display();
            _display.DisplayLevel(currLevel);
            _display.DisplayField(field,player,obsticales,boxes);

            Play();
            SetLevel1();

        }

        public void SetLevel1()
        {
            
            player = new Player("1 3");
            field = new Field(3,4);
            obsticales = new Obsticales(new List<string>(){"0 0"});
            boxes = new Boxes
            (
                new List<string>(){"1 1","1 2"}, 
                new List<string>(){"0 3","2 1"}
            );
            _display = new Display();
            _display.DisplayLevel(currLevel);
            _display.DisplayField(field,player,obsticales,boxes);
            Play();
            SetLevel2();
        }
        
        public void SetLevel2()
        {
            
            player = new Player("1 0");
            field = new Field(3,4);
            obsticales = new Obsticales(new List<string>(){"2 0", "0 3", "1 3"});
            boxes = new Boxes
            (
                new List<string>(){"1 1","1 2"}, 
                new List<string>(){"2 2","2 3"}
            );
            _display = new Display();
            _display.DisplayLevel(currLevel);
            _display.DisplayField(field,player,obsticales,boxes);
            Play();
            SetLevel3();
        }
        
        public void SetLevel3()
        {
            
            player = new Player("3 4");
            field = new Field(6,8);
            obsticales = new Obsticales(new List<string>()
            {
                "0 0","1 0","2 0","3 0","2 1","3 1","2 3","3 3","2 5","3 5","2 7","3 7","1 7","0 7","0 6","0 5","5 3","5 4"
            });
            boxes = new Boxes
            (
                new List<string>(){"1 2","2 2", "1 5"}, 
                new List<string>(){"4 1","4 3","4 5"}
            );
            _display = new Display();
            _display.DisplayLevel(currLevel);
            _display.DisplayField(field,player,obsticales,boxes);
            Play();
            _display.Congrats();

        }

        public void LevelPick()
        {
            bool levelPickFlag = true;
            int selectedLevel = 0;
            Console.Clear();
            Console.WriteLine("Use W/S to navigate and P to play the selected level.");
            Console.Write("Select level -> ");
            Console.WriteLine(selectedLevel);
            
            while (levelPickFlag)
            {
                char input = Console.ReadKey().KeyChar;

                switch (input)
                {
                    case 'w':
                        selectedLevel++;
                        break;
                    case 's':
                        selectedLevel--;
                        break;  
                }

                void PlayLevel()
                {
                    Console.Clear();
                    currLevel = selectedLevel;
                    switch (currLevel)
                    {
                        case 0:
                            StartUp();
                            break;
                        case 1:
                            SetLevel1();
                            break;
                        case 2:
                            SetLevel2();
                            break;
                        case 3:
                            SetLevel3();
                            break;
                    }

                    levelPickFlag = false;
                }
                
                if (selectedLevel<0)
                {
                    selectedLevel = 0;
                }

                if (selectedLevel>3)
                {
                    selectedLevel = 3;
                }
                
                Console.Clear();
                Console.WriteLine("Use W/S to navigate and P to play the selected level.");
                Console.Write("Choose level -> ");
                Console.WriteLine(selectedLevel);

                if (input == 'p')
                {
                    PlayLevel();
                }
                
            }
        }
        public void Play()
        {
            flag = true;
            resetFlag = false;
            while (flag)
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
                    case 'r':
                        resetFlag = true;
                        flag = false;
                        break;
                    case 'l':
                        LevelPick();
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
                    
                    int boxOldRow = boxes.BoxCoordinates[index].Split().Select(int.Parse).ToList()[0];
                    int boxOldCol = boxes.BoxCoordinates[index].Split().Select(int.Parse).ToList()[1];
                    
                    int boxRow = boxOldRow;
                    int boxCol = boxOldCol;
                    
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

                    string newBoxCoordinate = boxRow + " " + boxCol;
                    
                    if (boxRow >= field.Rows || 
                        boxRow < 0 || 
                        boxCol >= field.Cols || 
                        boxCol < 0 ||
                        obsticales.Coordinates.Contains(newBoxCoordinate) || 
                        boxes.BoxCoordinates.Contains(newBoxCoordinate))
                    {
                        playerRow = playerOldRow;
                        playerCol = playerOldCol;
                        boxRow = boxOldRow;
                        boxCol = boxOldCol;
                    }
                    
                    boxes.BoxCoordinates[index] = boxRow + " " + boxCol; 
                }
                

                player.Coordinates = playerRow + " " + playerCol;
                
                Console.Clear();
                _display.DisplayLevel(currLevel);
                _display.DisplayField(field,player,obsticales,boxes);

                if (boxes.BoxCoordinates.OrderBy(x => x).SequenceEqual(boxes.GoalCoordinates.OrderBy(x => x)))
                {
                    Console.Clear();
                    flag = false;
                    currLevel++;
                }
            }

            if (resetFlag)
            {
                Console.Clear();
                switch (currLevel)
                {
                    case 0:
                        StartUp();
                        break;
                    case 1:
                        SetLevel1();
                        break;
                    case 2:
                        SetLevel2();
                        break;
                    case 3:
                        SetLevel3();
                        break;
                }
            }
        }
    }
}