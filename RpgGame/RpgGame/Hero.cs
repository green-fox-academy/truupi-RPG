using System;
using GreenFox;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgGame
{
    class Hero : Characters
    {
        string moveLeftImage = @"./Assets/hero-left.png";
        string moveRightImage = @"./Assets/hero-right.png";
        string moveDownImage = @"./Assets/hero-down.png";
        string moveUpImage = @"./Assets/hero-up.png";
        int position;

        public Hero(FoxDraw foxDraw)
        {
            int d6 = MainWindow.rnd.Next(1, 7);
            maxHP = 20 + 3 * d6;
            currentHP = maxHP;
            dP = 2 * d6;
            aP = 5 + d6;
            level = 1;
            DrawHero(foxDraw);
        }

        public void DrawHero(FoxDraw foxDraw)
        {
            foxDraw.AddImage("./Assets/hero-down.png", Map.CoordinateCollection[0]);
        }

        public void MoveHeroLeft(FoxDraw foxDraw)
        {
            if (Map.floorSurfaceList.Contains(position - 1) && position % 10 != 0)
            {
                foxDraw.AddImage(moveLeftImage, Map.CoordinateCollection[position -= 1]);
            }
            else
            {
                foxDraw.AddImage(moveLeftImage, Map.CoordinateCollection[position]);
            }
        }

        public void MoveHeroRight(FoxDraw foxDraw)
        {
            if (Map.floorSurfaceList.Contains(position + 1) &&position % 10 != 9)
            {
                foxDraw.AddImage(moveRightImage, Map.CoordinateCollection[position += 1]);
            }
            else
            {
                foxDraw.AddImage(moveRightImage, Map.CoordinateCollection[position]);
            }
        }

        public void MoveHeroUp(FoxDraw foxDraw)
        {
            if (Map.floorSurfaceList.Contains(position - 10) && position > 9)
            {
                foxDraw.AddImage(moveUpImage, Map.CoordinateCollection[position -= 10]);
            }
            else
            {
                foxDraw.AddImage(moveUpImage, Map.CoordinateCollection[position]);
            }
        }

        public void MoveHeroDown(FoxDraw foxDraw)
        {
            if (Map.floorSurfaceList.Contains(position + 10) && position < 90)
            {
                foxDraw.AddImage(moveDownImage, Map.CoordinateCollection[position += 10]);
            }
            else
            {
                foxDraw.AddImage(moveDownImage, Map.CoordinateCollection[position]);
            }
        }
    }
}
