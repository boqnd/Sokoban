using System.Collections.Generic;

namespace Sokoban.Model
{
    public class Obsticales
    {
        private List<string> coordinates;

        public Obsticales(List<string> coordinates)
        {
            this.coordinates = coordinates;
        }

        public List<string> Coordinates
        {
            get => coordinates;
            set => coordinates = value;
        }
    }
}