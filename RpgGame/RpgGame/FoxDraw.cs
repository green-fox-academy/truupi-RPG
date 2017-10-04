using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace GreenFox
{
    public class FoxDraw
    {
        private const int TILEWIDTH = 50;
        private const int TILEHEIGHT = 50;
        public Canvas Canvas { get; set; }
        public List<UIElement> UIList { get; set; }
        public SolidColorBrush LineColor { get; set; } = SystemColors.WindowFrameBrush;
        public SolidColorBrush ShapeColor { get; set; } = new SolidColorBrush(Colors.DarkGreen);
        public FoxDraw(Canvas canvas)
        {
            Canvas = canvas;
            UIList = new List<UIElement>();
        }
        public void BackgroundColor(Color color)
        {
            Canvas.Background = new SolidColorBrush(color);
        }
        public void StrokeColor(Color color)
        {
            LineColor = new SolidColorBrush(color);
        }
        public void FillColor(Color color)
        {
            ShapeColor = new SolidColorBrush(color);
        }
        //public void DrawEllipse(double x, double y, double width, double height)
        //{
        //    var ellipse = new Ellipse()
        //    {
        //        Stroke = LineColor,
        //        Fill = ShapeColor,
        //        Width = width,
        //        Height = height
        //    };
        //    Canvas.Children.Add(ellipse);
        //    UIList.Add(ellipse);
        //    SetPosition(ellipse, x, y);
        //}
        public void DrawLine(Point p1, Point p2)
        {
            var line = new Line()
            {
                Stroke = LineColor,
                X1 = p1.X,
                Y1 = p1.Y,
                X2 = p2.X,
                Y2 = p2.Y
            };
            Canvas.Children.Add(line);
            UIList.Add(line);
        }
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            var line = new Line()
            {
                Stroke = LineColor,
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2
            };
            Canvas.Children.Add(line);
            UIList.Add(line);
        }
        public void DrawPolygon(IEnumerable<Point> points)
        {
            var polygon = new Polygon()
            {
                Stroke = LineColor,
                Fill = ShapeColor,
                Points = ListToPointCollection(points)
            };
            Canvas.Children.Add(polygon);
            UIList.Add(polygon);
        }
        //public void DrawRectangle(double x, double y, double width, double height)
        //{
        //    var rectangle = new Rectangle()
        //    {
        //        Stroke = LineColor,
        //        Fill = ShapeColor,
        //        Width = width,
        //        Height = height
        //    };
        //    Canvas.Children.Add(rectangle);
        //    UIList.Add(rectangle);
        //    SetPosition(rectangle, x, y);
        //}
        public void AddImage(string source, Point coordinate)
        {
            var image = new Image()
            {
                Width = TILEWIDTH,
                Height = TILEHEIGHT,
                Source = new BitmapImage(new Uri(source, UriKind.Relative))
            };
            Canvas.Children.Add(image);
            UIList.Add(image);
            SetPosition(image, coordinate);
        }
        public void AddImage(Canvas canvas, Point coordinate)
        {
            Canvas.Children.Add(canvas);
            UIList.Add(canvas);
            SetPosition(canvas, coordinate);
        }
        public void SetPosition(UIElement uIElement, Point coordinate)
        {
            Canvas.SetLeft(uIElement, coordinate.X);
            Canvas.SetTop(uIElement, coordinate.Y);
        }
        public void ClearCanvas()
        {
            Canvas.Children.Clear();
        }
        public PointCollection ListToPointCollection(IEnumerable<Point> points)
        {
            var pointCollection = new PointCollection();
            foreach (var point in points)
            {
                pointCollection.Add(point);
            }
            return pointCollection;
        }
    }
}