using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureToConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            float averageValue = 0;
            float averageBrightness = 0;
            float averageSaturation = 0;
            int xCursor = 0;
            int yCursor = 0;

            //Bitmap picture = new Bitmap("C:\\Users\\krust\\OneDrive\\Bureau\\C#\\PictureToConsole\\PictureToConsole\\butterfly.jpg");
            //Bitmap picture = new Bitmap("C:\\Users\\krust\\OneDrive\\Bureau\\C#\\PictureToConsole\\PictureToConsole\\sunflower.jpg");
            Bitmap picture = new Bitmap("C:\\Users\\krust\\OneDrive\\Bureau\\C#\\PictureToConsole\\PictureToConsole\\image.jpg");
            //Bitmap picture = new Bitmap("C:\\Users\\krust\\OneDrive\\Bureau\\C#\\PictureToConsole\\PictureToConsole\\cat.jpeg");

            for (int y = 0; y < picture.Height-45; y+=picture.Height / 28)
            {
                for(int x = 0; x < picture.Width-30; x+=picture.Width / 100)
                {
                    for (int subY = y; subY < y + picture.Height / 28; subY++)
                    {
                        for (int subX = x; subX < x + picture.Width / 100; subX++)
                        {
                            averageValue += picture.GetPixel(subX, subY).GetHue();
                            averageBrightness = picture.GetPixel(subX, subY).GetBrightness();
                            averageSaturation = picture.GetPixel(subX, subY).GetSaturation();
                        }
                    }
                    
                    averageValue /= (picture.Height / 28) * (picture.Width / 100);
                    averageBrightness /= (picture.Height / 28) * (picture.Width / 100);
                    averageSaturation /= (picture.Height / 28) * (picture.Width / 100);

                    //Console.WriteLine(averageBrightness * 10000);

                    if(averageValue > 0 && averageValue < 30) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if(averageValue >= 30 && averageValue < 60)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if( averageValue >= 60 && averageValue < 90)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(averageValue >= 90 && averageValue < 120)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if(averageValue >= 120 && averageValue < 160)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if(averageValue >= 160 && averageValue <= 250)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if(averageSaturation <= 15)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if(averageSaturation >= 80)
                    {
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    Console.SetCursorPosition(xCursor, yCursor);
                    if(averageBrightness * 10000 > 1f)
                    {
                        Console.Write("@");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    

                    xCursor++;
                }
                Console.WriteLine();
                averageValue = 0;
                xCursor = 0;
                yCursor++;
            }
            Console.ReadLine();
            
        }
    }
}
