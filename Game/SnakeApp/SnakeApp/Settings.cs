using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public enum Directions
    {
        // enum, cause easier to classify directions
        Left,
        Right,
        Up,
        Down
    };

    class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Directions direction { get; set; }

        public Settings()
        {
            Width = 16; // width of canvas
            Height = 16; // height of canvas
            Speed = 10; // speed of snake
            Score = 0; // starting score
            Points = 1; // points per food
            GameOver = false;
            direction = Directions.Down;
        }
    }
}
