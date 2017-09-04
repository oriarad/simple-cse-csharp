using System;
using SimpleCSE;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCseExamples
{
    class SimpleRssExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            SimpleExample1();
            SimpleExample2();
            //SimpleExample3();
            //SimpleExample4();
            //SimpleExample5();
            Console.WriteLine("End");
        }

        private static void SimpleExample1()
        {
            string TEST_URL = "http://www.ynet.co.il/Integration/StoryRss4403.xml";
            SimpleRss rss;
    
                rss = new SimpleRss(TEST_URL);
                for (int i = 0; i < rss.GetSize(); ++i)
                {
                    Console.WriteLine(rss.GetItem(i).GetTitle());
                }
        }

        private static void SimpleExample2()
        {
            SimpleRss rss = new SimpleRss("http://rss.cnn.com/rss/edition.rss");
            for (int i = 0; i < rss.GetSize(); ++i)
            {
                Console.WriteLine(rss.GetItem(i).GetTitle());
            }

        }

        private static void SimpleExample3()
        {
            SimpleRss sr = new SimpleRss();
            sr.LoadUrl("");

        }

        private static void SimpleExample4()
        {
            SimpleRss sr = new SimpleRss();
            sr.LoadUrl("");

        }

        private static void SimpleExample5()
        {
            SimpleRss sr = new SimpleRss();
            sr.LoadUrl("");

        }
    }
}
