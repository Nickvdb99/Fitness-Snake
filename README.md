# Fitness-Snake

### Arduino & Pulse Sensor

To run our version of the snake game, you will need an [Arduino UNO](https://store.arduino.cc/arduino-uno-rev3) and a [pulse sensor](https://learn.sparkfun.com/tutorials/sparkfun-pulse-oximeter-and-heart-rate-monitor-hookup-guide).

You will also need the [Arduino IDE](https://www.arduino.cc/download_handler.php) to upload the Arduino script to the arduino.
To upload the script to your Arduino, open the ArduinoSettings.ino file (\Fitness-Snake-master\Game\ArduinoSettings.ino).
Click on Sketch and on Upload.
To use the game with the Arduino you need to find which port the Arduino is connected to. If you click on Tools and hover over Port, you can see to which port the Arduino is connected to.

#### Next we will hook up our sensor to the Arduino:
You'll need 6 male-male jumper cables and plug the cables into these ports on the arduino & sensor

| Arduino | Cable Color  | Sensor |
|---------|--------|------|
| GND     | Black  | GND  |
| 3V3     | Red   | 3V3  |
| SDA     | Blue  | SDA  |
| SCL     | Yellow   | SCL  |
| 4       | White    | RST  |
| 5       | Orange | MFIO |

[More detailed explanation](https://github.com/aliekens/pulse_sensor_tutorial)


### Visual Studio

To run our project you will need [Visual Studio](https://visualstudio.microsoft.com/downloads/)

### Setup of the game

Set COM port: \Fitness-Snake-master\Game\SnakeApp\SnakeApp\Program.cs -> (line 36) "myport.PortName = "COM3"; // usb poort" -> Change the port to the port your arduino is using (see explanation on Arduino & Pulse sensor).

You can make changes to the game settings in the Settings.cs file (\Fitness-Snake-master\Game\SnakeApp\SnakeApp\Settings.cs). You can change the width and height of the game, the speed of the snake, the starting score and the number of points you get per food.

Don't forget to save the Program.cs and Settings.cs files if you made any changes.

### Startup of the game

To start up the game you can either run the Program.cs file in Visual Studio or you can run the SnakeApp.exe file. You can find the .exe file in the following directory: \Fitness-Snake-master\Game\SnakeApp\SnakeApp\bin\Debug\SnakeApp.exe

When using the pulse sensor it is important that you don't press too hard or move too much with your finger on the sensor. The game will say when the sensor gives an error.
