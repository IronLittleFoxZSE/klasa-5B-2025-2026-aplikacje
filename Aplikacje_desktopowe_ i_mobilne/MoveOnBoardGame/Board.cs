using MoveOnBoardGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveOnBoardGame
{
    class Board
    {
        private int topCorner = 5;
        private int leftCorner = 5;
        private int height = 20;
        private int width = 60;
        private ConsoleColor borderBackgroundColor = ConsoleColor.DarkRed;
        private ConsoleColor borderForegroundColor = ConsoleColor.Yellow;

        private ConsoleColor stoneBackgroundColor = ConsoleColor.DarkMagenta;
        private ConsoleColor stoneForegroundColor = ConsoleColor.Green;

        private ConsoleColor fruitBackgroundColor = ConsoleColor.Green;
        private ConsoleColor fruitForegroundColor = ConsoleColor.White;

        private char borderChar = 'X';
        
        private char stoneChar = 'S';
        private double percentOfStoneObstacles = 0.02;

        private char fruitChar = 'F';
        private double percentOfFruitObstacles = 0.02;

        private List<AvailableField> availableFieldsOnBoard = new List<AvailableField>();

        public Board()
        {
            CompleteAvailableFields();
            GenerateRandomObstacles(TypeOfObstacle.Stone, percentOfStoneObstacles);
            GenerateRandomObstacles(TypeOfObstacle.Fruit, percentOfFruitObstacles);
        }

        public void Draw()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.ForegroundColor = borderForegroundColor;
            Console.BackgroundColor = borderBackgroundColor;

            //górna krawędź
            Console.SetCursorPosition(topCorner, leftCorner);
            for (int i = 0; i < width; i++)
            {
                Console.Write(borderChar);
            }

            //krawędzie boczne
            for (int i = 1; i < height - 1; i++)
            {
                //lewa
                Console.SetCursorPosition(topCorner, i + leftCorner);
                Console.Write(borderChar);

                //prawa
                Console.SetCursorPosition(width - 1 + topCorner, i + leftCorner);
                Console.Write(borderChar);
            }

            //dolna krawędź
            Console.SetCursorPosition(topCorner, height - 1 + leftCorner);
            for (int i = 0; i < width; i++)
            {
                Console.Write(borderChar);
            }

            DrawObstacles(TypeOfObstacle.Stone, stoneBackgroundColor, stoneForegroundColor, stoneChar);
            DrawObstacles(TypeOfObstacle.Fruit, fruitBackgroundColor, fruitForegroundColor, fruitChar);
        }

        private void DrawObstacles(TypeOfObstacle typeOfObstacle, ConsoleColor backgroundColor, ConsoleColor foregroundColor, char sign)
        {
            Console.ForegroundColor = backgroundColor;
            Console.BackgroundColor = foregroundColor;

            List<AvailableField> listOfObstacles = availableFieldsOnBoard.Where(af => af.TypeOfObstacle == typeOfObstacle).ToList();
            foreach (AvailableField item in listOfObstacles)
            {
                Console.SetCursorPosition(item.X, item.Y);
                Console.Write(sign);
            }

            Console.ResetColor();
        }

        public CollisionType CollisionDetect(int x, int y)
        {
            AvailableField availableField = availableFieldsOnBoard
                                            .FirstOrDefault(af => af.X == x && af.Y == y);

            if (availableField == null)
                return CollisionType.BorderCollision;

            if (availableField.TypeOfObstacle == TypeOfObstacle.Stone)
                return CollisionType.StoneCollision;

            if (availableField.TypeOfObstacle == TypeOfObstacle.Fruit)
                return CollisionType.FruitCollision;

            return CollisionType.NoCollision;
        }

        private void CompleteAvailableFields()
        {
            for (int x = topCorner + 1; x <= width + topCorner - 2; x++)
            {
                for (int y = leftCorner + 1; y <= height + leftCorner - 2; y++)
                {
                    AvailableField availableField = new AvailableField();
                    availableField.X = x;
                    availableField.Y = y;
                    availableField.TypeOfObstacle = TypeOfObstacle.None;

                    availableFieldsOnBoard.Add(availableField);
                }
            }
        }

        public AvailableField GetRandomAvailableField()
        {
            Random random = new Random();

            int randomNumnber = random.Next(0, availableFieldsOnBoard.Count);

            AvailableField availableField = availableFieldsOnBoard[randomNumnber];

            return availableField;
        }

        private void GenerateRandomObstacles(TypeOfObstacle typeOfObstacle, double percentOfObstacles)
        { 
            int countOfObstacles = (int)(height * width * percentOfObstacles);

            Random random = new Random();

            List<AvailableField> listForObstacles = availableFieldsOnBoard
                .Where(af => af.TypeOfObstacle == TypeOfObstacle.None)
                .OrderBy(af => random.Next())
                .Take(countOfObstacles)
                .ToList();

            foreach (var item in listForObstacles)
            {
                item.TypeOfObstacle = typeOfObstacle;
            }
        }

    }
}
