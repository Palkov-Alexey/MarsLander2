using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**https://www.codingame.com/ide/puzzle/mars-lander-episode-2
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        int startFlatV=0, endFlatV=1, startFlatH=0, endFlatH=0;
        for (int i = 0; i < surfaceN; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
            if(startFlatV!=landY && startFlatV!=endFlatV){
                
                    startFlatV=landY;
                    startFlatH=landX;           
                
            }
            else if(startFlatV==landY){
                endFlatV=landY;
                endFlatH=landX;
            }
        }
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).
            
            int distancion=Distance(X, startFlatH, endFlatH);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            

            // rotate power. rotate is the desired rotation angle. power is the desired thrust power.
            Console.WriteLine(Engine(X, Y, hSpeed, vSpeed, startFlatH, endFlatH, distancion));
        }
    }
    
    static int Distance(int x, int startFlatH, int endFlatH){

        if(Math.Abs(x-startFlatH)<Math.Abs(x-endFlatH)){
            return x-startFlatH;
        }
        else return x-endFlatH;
    }
    
    static string Engine(int X, int Y, int hSpeed, int vSpeed, int startFlatH, int endFlatH, int distance){
        if (X>startFlatH+20 && X<endFlatH-20){
            if(hSpeed>=1){
                return "25 4";
            }
            else if(hSpeed<=-1){
            
                return "-25 4";
            }
            else if(vSpeed<=-40){
                return "0 4";
            }
            else return "0 2";
        }
        else{
            if(Y<2900){
              if (distance>500){
                  if(hSpeed<-50){
                      return "-25 4";
                  }
                  else if(hSpeed<-40 && hSpeed>-50) return "0 4";
                  else return "20 4";
              }
              else if (distance<-500){
                  if(hSpeed>50) return "25 4";
                  if(hSpeed>=40 && hSpeed<50) return "0 4";
                  else return "-20 4";
              }
              else{
                  if (hSpeed>5) return "25 4";
                  else if (hSpeed<-5) return "-25 4";
                  else return "0 4";
              }
            }
            else return "0 1";
        }
    }
}
