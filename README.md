# Fitness-Snake

### Arduino & Pulse Sensor

To run our version of the snake game, you will need an [Arduino UNO](https://store.arduino.cc/arduino-uno-rev3) and a [pulse sensor](https://learn.sparkfun.com/tutorials/sparkfun-pulse-oximeter-and-heart-rate-monitor-hookup-guide).

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

[More detailed version](https://github.com/aliekens/pulse_sensor_tutorial)


Connect kabels
Upload programma
Check COM poort (welke usb poort de arduino insteekt)

Snake Game:
Set COM poort: Program.Cs -> "myport.PortName = "COM3"; // usb poort"
