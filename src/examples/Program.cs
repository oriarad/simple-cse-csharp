using System;
using SimpleCSE;
using System.Drawing;

namespace SimpleCseExamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            SimpleExample();
            SimpleExample3();
            SimpleExample4();
            SimpleExample5();
        }

        private static void SimpleExample()
        {
            SimpleGoogleMaps sgm = new SimpleGoogleMaps();

            sgm.SetWindowTitle("New-York");
            sgm.SetLatitude(40.714728);
            sgm.SetLongitude(-73.998672);
            sgm.SetZoom(12);
            Console.WriteLine(sgm.GenerateUrl());
            sgm.Refresh();
        }


        private static void SimpleExample3()
        {
            SimpleGoogleMaps sgm = new SimpleGoogleMaps();

            sgm.SetLatitude(32.776760);
            sgm.SetLongitude(35.027222);
            sgm.SetZoom(17);
            sgm.SetWidth(640);
            sgm.SetHeight(640);
            sgm.SetWindowTitle("Technion's Department of Education in Technology and Science - Hybrid");
            sgm.SetMapType(SimpleGoogleMaps.HYBRID);
            Console.WriteLine(sgm.GenerateUrl());
            sgm.Refresh();
        }

        private static void SimpleExample4()
        {
            SimpleGoogleMaps sgm = new SimpleGoogleMaps();
            sgm.SetWindowTitle("Technion's Department of Education in Technology and Science - Road-Map");
            sgm.SetLatitude(32.776760);
            sgm.SetLongitude(35.027222);
            sgm.SetZoom(17);
            sgm.SetWidth(640);
            sgm.SetHeight(640);
            sgm.AddMarker(new Marker(32.776760, 35.025, Color.Black));
            sgm.AddMarker(new Marker(32.776760, 35.026, Color.Pink));
            sgm.AddMarker(new Marker(32.776760, 35.027, Color.Blue));
            sgm.AddMarker(new Marker(32.776760, 35.028, Color.Red));
            sgm.AddMarker(new Marker(32.776760, 35.029, Color.Magenta));
            sgm.AddMarker(new Marker(32.776760, 35.030, Color.Green));

            Console.WriteLine(sgm.GenerateUrl());
            sgm.Refresh();
        }

        private static void SimpleExample5()
        {
            SimpleGoogleMaps sgm = new SimpleGoogleMaps();

            sgm.SetLatitude(32.776760);
            sgm.SetLongitude(35.027222);
            sgm.SetZoom(17);
            sgm.SetWidth(640);
            sgm.SetHeight(640);


            Path path = new Path(32.7765, 35.027222);
            path.AddPoint(32.7765, 35.2);
            path.SetColor(Color.Red);
            sgm.AddPath(path);
            Path path2 = new Path(32.777, 35.027222);
            path2.AddPoint(32.777, 35.2);
            path2.SetColor(Color.Orange);
            sgm.AddPath(path2);
            Path path3 = new Path(32.7775, 35.027222);
            path3.AddPoint(32.7775, 35.2);
            path3.SetColor(Color.Cyan);
            sgm.AddPath(path3);
            path = new Path(32.778, 35.027222);
            path.AddPoint(32.778, 35.2);
            path.SetColor(Color.Blue);
            sgm.AddPath(path);
            path = new Path(32.7785, 35.027222);
            path.AddPoint(32.7785, 35.2);
            path.SetColor(Color.Green);
            sgm.AddPath(path);
            sgm.Refresh();

        }
    }
}