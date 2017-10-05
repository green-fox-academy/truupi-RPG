using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenFox;

namespace RpgGame
{
    class Skeleton : Enemy
    {
        public Skeleton(FoxDraw foxDraw)
        {
            DrawSkeletons(foxDraw);
        }

        public void DrawSkeletons(FoxDraw foxDraw)
        {
            for (int i = 0; i < MainWindow.rnd.Next(2, 5); i++)
            {
                int randomNumber = MainWindow.rnd.Next(0, 100);
                foxDraw.AddImage(@"./Assets/skeleton.png", Map.CoordinateCollection[randomNumber]);
            }
        }
    }
}
