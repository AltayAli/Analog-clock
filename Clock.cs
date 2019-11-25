using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    class Clock
    {
        Graphics graphics;
        Bitmap bmp;
        public int ss = DateTime.Now.Second;
        public int mm = DateTime.Now.Minute;
        public int hour = DateTime.Now.Hour;
        public int width { get; set; }
        public int height { get; set; }
        int cx = 0;
        int cy = 0;
        public Clock()
        {
            bmp = new Bitmap(width, height);
            graphics = Graphics.FromImage(bmp);
            cx = width * 2;
            cy = height / 2;
        }

        public void drawLine(PictureBox pc)
        {
            graphics.Clear(Color.White);
            pc.Image = bmp;
        }

        public void msScarpion(int value, int scLength, Color color, int width)
        {
            int xCoordinate = 0;
            int yCoordinate = 0;
            value *= 6;
            if (value >= 0 && value <= 100)
            {
                xCoordinate = cx + (int)(scLength * Math.Sin(Math.PI * value / 180));
                yCoordinate = cy - (int)(scLength * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                xCoordinate = cx - (int)(scLength * -Math.Sin(Math.PI * value / 180));
                yCoordinate = cy - (int)(scLength * Math.Cos(Math.PI * value / 180));
            }

            graphics.DrawLine(new Pen(color, width), new Point(87, 99), new Point(xCoordinate, yCoordinate));

        }
        public void hourScarpion(int hourValue, int minuteValue, int hourLength, Color color, int width)
        {
            int xCoordinate = 0;
            int yCoordinate = 0;
            int value = (int)((hourValue * 30) + (minuteValue * 0.5));
            if (value >= 0 && value <= 100)
            {
                xCoordinate = cx + (int)(hourLength * Math.Sin(Math.PI * value / 180));
                yCoordinate = cy - (int)(hourLength * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                xCoordinate = cx - (int)(hourLength * -Math.Sin(Math.PI * value / 180));
                yCoordinate = cy - (int)(hourLength * Math.Cos(Math.PI * value / 180));
            }

            graphics.DrawLine(new Pen(color, width), new Point(87, 99), new Point(xCoordinate, yCoordinate));
        }
        public string wordClock()
        {
            string clock = String.Empty;
            if (mm == 0)
            {
                clock += $"{hour} o`clock";
            }
            else if (mm == 15)
            {
                clock += $"quater past {hour}";
            }
            else if (mm == 30)
            {
                clock += $"half past {hour}";
            }
            else if (mm == 45)
            {
                if (hour <= 23)
                {
                    clock += $"quater to {hour + 1}";
                }
                else
                {
                    clock += $"quater to {00}";
                }
            }
            else if (mm > 30)
            {
                if (hour <= 23)
                {
                    clock += $"{60 - mm} minute  to {hour + 1}";
                }
                else
                {
                    clock += $"{mm} minute  to {00}";
                }

            }
            else
            {
                clock += $"{mm} minute  past {hour}";
            }
            return clock;
        }
    }
}
