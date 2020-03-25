﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeApp
{

    public partial class Form1 : Form
    {
        private static List<Circle> Snake = new List<Circle>();
        private static Circle food = new Circle();
        public Form1()
        {
            InitializeComponent();
            new Settings();

            gameTimer.Interval = 1000 / Settings.Speed;

            gameTimer.Tick += updateScreen;

            gameTimer.Start();
            startGame();
        }

        private static void updateScreen(object sender, EventArgs e)
        {
            if (Settings.GameOver == true)
            {
                if (Input.KeyPress(Keys.Enter))
                {
                    startGame();
                }
            }
            else
            {
                if (Input.KeyPress(Keys.Right) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                else if (Input.KeyPress(Keys.Left) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                else if (Input.KeyPress(Keys.Up) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                else if (Input.KeyPress(Keys.Down) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }
                movePlayer();

                // Variable speed
                if (procent > Settings.MaximumHeartrateProcent) // if heartrate too high, snek go fast
                {
                    gameTimer.Interval = 1000 / Settings.FastSpeed;
                }
                else if (procent < Settings.MinimumHeartrateProcent) // if heartrate too low, snek go slow
                {
                    gameTimer.Interval = 1000 / Settings.SlowSpeed;
                }
                else // otherwise normal speed
                {
                    gameTimer.Interval = 1000 / Settings.Speed;
                }
            }
            pbCanvas.Invalidate();
        }
        private static void movePlayer()
        {
            // main loop for snake head & parts
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //if snake head is active
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].X++;
                            break;
                        case Directions.Left:
                            Snake[i].X--;
                            break;
                        case Directions.Up:
                            Snake[i].Y--;
                            break;
                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                    }
                    int maxXpos = pbCanvas.Size.Width / Settings.Width;
                    int maxYpos = pbCanvas.Size.Height / Settings.Height;

                    if (
                        Snake[i].X < 0 || Snake[i].Y < 0 ||
                        Snake[i].X > maxXpos || Snake[i].Y > maxYpos
                        )
                    {
                        die();
                    }
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            die();
                        }
                    }
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        eat();
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, true);
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false);
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.GameOver == false)
            {
                Brush snakeColour; //Create new brush called snake colour

                //loop to check the snake parts
                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.Black;
                    }
                    else
                    {
                        // set color depending on speed
                        if (procent > Settings.MaximumHeartrateProcent) // if heartrate too high, snek go red
                        {
                            snakeColour = Brushes.Red;
                        }
                        else if (procent < Settings.MinimumHeartrateProcent) // if heartrate too low, snek go blue
                        {
                            snakeColour = Brushes.Blue;
                        }
                        else // otherwise normal color
                        {
                            snakeColour = Brushes.Green;
                        }
                        
                    }
                    //draw snake body & head
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * Settings.Width,
                        Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));
                    //draw food
                    canvas.FillEllipse(Brushes.Red, new Rectangle(
                        food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));
                }
            }
            else
            {
                string gameOver = "Game Over \n" + "Final Score is " + Settings.Score + "\n Press Enter To Restart \n";
                label3.Text = gameOver;
                label3.Visible = true;
            }
        }
        private static void startGame()
        {
            label3.Visible = false;
            new Settings();
            Snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 }; // new head for snake
            Snake.Add(head); //add head to snake array

            //label2.Text = Settings.Score.ToString(); // Show score
            label2.Invoke(t => t.Text = Settings.Score.ToString()); // thread fix

            generateFood(); // run the food function
        }
        private static void generateFood()
        {
            int maxXpos = pbCanvas.Size.Width / Settings.Width;

            int maxYpos = pbCanvas.Size.Height / Settings.Height;

            Random rnd = new Random();
            food = new Circle { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };
        }

        private static void eat()
        {
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            if (Program.HeartrateDetected == true)
            {
                Snake.Add(body); //add snake parts to array
                Settings.Score += Settings.Points; //increase game score
            }
            label2.Text = Settings.Score.ToString(); // insert new score in label
            generateFood(); // generate new food
            
        }

        private static void die()
        {
            Settings.GameOver = true;
        }
        private static void HeartrateDetected()
        {
            if (Program.HeartrateDetected == true)
            {
                //HearrateDetectorLabel.Text = "Heartrate Detected!";
                //HearrateDetectorLabel.ForeColor = System.Drawing.Color.Green;
                HearrateDetectorLabel.Invoke(t => t.Text = "Heartrate Detected!");
                HearrateDetectorLabel.Invoke(t => t.ForeColor = System.Drawing.Color.Green);
            }
            else
            {
                //HearrateDetectorLabel.Text = "Heartrate Not Detected";
                //HearrateDetectorLabel.ForeColor = System.Drawing.Color.Red;
                HearrateDetectorLabel.Invoke(t => t.Text = "Heartrate Not Detected!");
                HearrateDetectorLabel.Invoke(t => t.ForeColor = System.Drawing.Color.Red);
            }
        }

        private static double procent;
        public static void Heartrate(int x)
        {
            label5.Invoke(t => t.Text = x.ToString()); // insert number into label

            double age = 20; // user age
            double max = 220 - age; // max heartrate according to age
            procent = (x / max) * 100; // to procent
            label7.Invoke(t => t.Text = procent.ToString()); // insert number into label
            HeartrateDetected();
        }
    }

    public static class Extensions // needed to insert values into form from other thread
    {
        public static void Invoke<TControlType>(this TControlType control, Action<TControlType> del)
            where TControlType : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action(() => del(control)));
            else
                del(control);
        }
    }
}
