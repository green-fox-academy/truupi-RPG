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
using System.IO;

namespace RpgGame 
{
    class Map : GameScreen
    {
        public static PointCollection CoordinateCollection = new PointCollection();
        public static List<int> floorSurfaceList = new List<int>();

        public Map(FoxDraw foxDraw)
        {
            MapCreation();
            MapDraw(foxDraw);
        }

        public void MapDraw(FoxDraw foxDraw)
        {
            string[] mapSurface = File.ReadAllLines(@"../../Assets/map.txt");
            floorSurfaceList = mapSurface[0].Split(',').Select(Int32.Parse).ToList();

            for (int i = 0; i < CoordinateCollection.Count; i++)
            {
                if (floorSurfaceList.Contains(i))
                {
                    foxDraw.AddImage(@"../../Assets/floor.png", CoordinateCollection[i]);
                }
                else
                {
                    foxDraw.AddImage(@"../../Assets/wall.png", CoordinateCollection[i]);
                }
            }

        }

        public void MapCreation()
        {
            for (int y = 0; y < 500; y += 50)
            {
                for (int x = 0; x < 500; x += 50)
                {
                    Point coordinate = new Point(x, y);
                    CoordinateCollection.Add(coordinate);
                }
            }
        }
    }
}
