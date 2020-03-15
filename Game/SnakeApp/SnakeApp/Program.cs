using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Data; 

namespace SnakeApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread t1 = new Thread(
                new ThreadStart(() =>
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }));

            Thread t2 = new Thread(
                new ThreadStart(() =>
                    {
                    // Arduino
                    SerialPort myport = new SerialPort(); // serial port handler
                    myport.BaudRate = 115200;
                    myport.PortName = "COM6"; // usb poort
                    myport.Open();

                    while (true)
                    {
                        string data_rx = myport.ReadLine();
                        List<int> numbers = data_rx.Split(',').Select(Int32.Parse).ToList();
                        if (numbers[0] != 0)
                        {
                            Console.WriteLine("Hartslag: " + numbers[0]);
                            Form1.Heartrate(numbers[0]);
                        }

                        if (numbers[1] == 0)
                        //Console.WriteLine("Succes");
                        if (numbers[1] == 1)
                            Console.WriteLine("Not Ready");
                        if (numbers[1] == -1)
                            Console.WriteLine("Object detected");
                        if (numbers[1] == -2)
                            Console.WriteLine("Excessive sensor device motion");
                        if (numbers[1] == -3)
                            Console.WriteLine("No object detected");
                        if (numbers[1] == -4)
                            Console.WriteLine("Pressing too hard");
                        if (numbers[1] == -5)
                            Console.WriteLine("Object other that finger detected");
                        if (numbers[1] == -6)
                            Console.WriteLine("Excessive finger motion");

                        //Console.WriteLine(data_rx); // testing
                    }
            }));

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
    }
}
