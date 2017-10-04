using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GreenFox;

namespace RpgGame 
{
    class Map : GameScreen
    {
        public PointCollection CoordinateCollection = new PointCollection();

        public Map(FoxDraw foxDraw)
        {
            for (int y = 0; y < 500; y += 50)
            {
                for (int x = 0; x < 500; x += 50)
                {
                    Point coordinate = new Point(x, y);
                    CoordinateCollection.Add(coordinate);
                }
            }
            
            Tiles tiles = new Tiles();
            for (int i = 0; i < CoordinateCollection.Count; i++)
            {
                if (tiles.floorSurfaceList.Contains(i))
                {
                    foxDraw.AddImage(@"../../Assets/floor.png", CoordinateCollection[i]);
                }
                else
                {
                    foxDraw.AddImage(@"../../Assets/wall.png", CoordinateCollection[i]);
                }
            }
        }
    }
}
