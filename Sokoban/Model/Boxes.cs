using System.Collections.Generic;

namespace Sokoban.Model
{
    public class Boxes
    {
        private List<string> boxCoordinates;
        private List<string> goalCoordinates;

        public Boxes(List<string> boxCoordinates, List<string> goalCoordinates)
        {
            this.boxCoordinates = boxCoordinates;
            this.goalCoordinates = goalCoordinates;
        }

        public List<string> BoxCoordinates
        {
            get => boxCoordinates;
            set => boxCoordinates = value;
        }

        public List<string> GoalCoordinates
        {
            get => goalCoordinates;
            set => goalCoordinates = value;
        }
    }
}