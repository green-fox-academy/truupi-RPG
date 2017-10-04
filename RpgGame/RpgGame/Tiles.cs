using System;
using System.IO;
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
    class Tiles
    {
        public List<int> floorSurfaceList = new List<int>();
        public List<int> wallSurfaceList = new List<int>();
        public bool IsWall = false;

        public Tiles()
        {
            string[] mapSurface = File.ReadAllLines(@"../../Assets/map.txt");
            floorSurfaceList = mapSurface[0].Split(',').Select(Int32.Parse).ToList();
            wallSurfaceList = mapSurface[1].Split(',').Select(Int32.Parse).ToList();

            foreach (var wallSurface in wallSurfaceList)
            {
                IsWall = true;
            }

        }
    }
}
