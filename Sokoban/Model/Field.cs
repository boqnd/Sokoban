namespace Sokoban.Model
{
    public class Field
    {
        private int rows;
        private int cols;

        public int Rows
        {
            get => rows;
            set => rows = value;
        }

        public int Cols
        {
            get => cols;
            set => cols = value;
        }

        public Field(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
        }
    }
}