using System.Collections.Generic;
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
                new List<string>(){"3 0","4 0"}, 
                new List<string>(){"4 4","4 3"}
                );
            _display = new Display();
            
            _display.DisplayField(field,player,obsticales,boxes);
        }
    }
}