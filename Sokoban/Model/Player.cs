namespace Sokoban.Model
{
    public class Player
    {
        private string coordinates;

        public Player(string coordinates)
        {
            this.coordinates = coordinates;
        }

        public string Coordinates
        {
            get => coordinates;
            set => coordinates = value;
        }
    }
}