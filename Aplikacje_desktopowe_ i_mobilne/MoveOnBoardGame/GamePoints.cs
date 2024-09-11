using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOnBoardGame
{
    class GamePoints
    {
        private int pointSum;

        public GamePoints()
        {
            pointSum = 0;
        }

        public void IncresePoint()
        {
            pointSum++;
            DrawPoints();
        }

        private void DrawPoints()
        {

        }
    }
}
