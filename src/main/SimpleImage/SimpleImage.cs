using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading;

namespace SimpleCSE
{
    public class SimpleImage
    {
        private Bitmap bitmap;
        private int width;
        /**
         * 
         */
        private int height;
        /**
         * 
         */
        //private WritableRaster raster;
        private SimpleImageForm form;
        /**
         * 
         */
        string title = "SimpleImage - No Title";
        /**
         * 
         */
        //string[] metaData = null;

        public SimpleImage()
        {
            this.form = new SimpleImageForm();
            Thread myThread = new Thread((ThreadStart)delegate { Application.Run(form); });
            myThread.Start();
        }

        /**
         * 
         */
        public void Load()
        {
            // Create a file chooser
            OpenFileDialog fc = new OpenFileDialog();
            DialogResult returnVal = fc.ShowDialog();
            if (returnVal == DialogResult.OK)
            {
                Load(fc.FileName);
            }
        }

        /**
         * @param theWidth
         * @param theHeight
         */
        public void Create(int theWidth, int theHeight)
        {
            //this.width = theWidth;
            //this.height = theHeight;
            //this.bi = new BufferedImage(this.width, this.height, BufferedImage.TYPE_INT_RGB);
            //Raster ras = this.bi.getData();
            //this.raster = ras.createCompatibleWritableRaster();
            //this.raster.setRect(ras);
            //this.bi.setData(this.raster);
        }

        /**
         * @param file
         */
        public void Load(FileStream file)
        {
            bitmap = (Bitmap)Image.FromStream(file);
            this.width = this.bitmap.Width;
            this.height = this.bitmap.Height;
            //form.SetImage(bitmap);
            
            //form.GetPictureBox().Image = bitmap;
            //if (this.bi.getType() != BufferedImage.TYPE_INT_RGB)
            //    {
            //        BufferedImage tempBi = new BufferedImage(this.width, this.height, BufferedImage.TYPE_INT_RGB);
            //        Graphics g = tempBi.getGraphics();
            //        g.drawImage(this.bi, 0, 0, null);
            //        this.bi = tempBi;
            //    }

            //Raster ras = this.bi.getData();
            //this.raster = ras.createCompatibleWritableRaster();
            //this.raster.setRect(ras);
            //this.bi.setData(this.raster);
        }

        /**
         * @param filename
         */
        public void Load(string filename)
        {
            //Load(File.Open(filename, FileMode.Open));

            //form.LoadImage(filename);

            this.bitmap = (Bitmap)Image.FromFile(filename);
            this.width = this.bitmap.Width;
            this.height = this.bitmap.Height;
            Refresh();
        }

        /**
         * @param filename
         */
        public void LoadUrl(string url)
        {
            //try
            //{
            //    this.bi = ImageIO.read(new URL(url));
            //    this.width = this.bi.getWidth(null);
            //    this.height = this.bi.getHeight(null);
            //    if (this.bi.getType() != BufferedImage.TYPE_INT_RGB)
            //    {
            //        BufferedImage tempBi = new BufferedImage(this.width, this.height, BufferedImage.TYPE_INT_RGB);
            //        Graphics g = tempBi.getGraphics();
            //        g.drawImage(this.bi, 0, 0, null);
            //        this.bi = tempBi;
            //    }
            //}
            //catch (IOException e)
            //{
            //    System.out.println("err");
            //}
            //Raster ras = this.bi.getData();
            //this.raster = ras.createCompatibleWritableRaster();
            //this.raster.setRect(ras);
            //this.bi.setData(this.raster);
        }

        /**
         * @param x
         * @param y
         * @return The "red" value of the pixel in (x, y)
         */
        public int GetRed(int x, int y)
        {
            return this.bitmap.GetPixel(x, y).R;
        }

        /**
         * @param x
         * @param y
         * @return The "green" value of the pixel in (x, y)
         */
        public int GetGreen(int x, int y)
        {
            return this.bitmap.GetPixel(x, y).G;
        }

        /**
         * @param x
         * @param y
         * @return The "blue" value of the pixel in (x, y)
         */
        public int GetBlue(int x, int y)
        {
            return this.bitmap.GetPixel(x, y).B;
        }

        /**
         * @return The "red" values of the image as two dimensional array
         */
        public int[,] GetRed()
        {
            int[,] result = new int[this.width, this.height];
            for (int i = 0; i < this.width; ++i)
            {
                for (int j = 0; j < this.height; ++j)
                {
                    result[i, j] = GetRed(i, j);
                }
            }
            return result;
        }

        /**
         * @return The "green" values of the image as two dimensional array
         */
        public int[,] GetGreen()
        {
            int[,] result = new int[this.width, this.height];
            for (int i = 0; i < this.width; ++i)
            {
                for (int j = 0; j < this.height; ++j)
                {
                    result[i, j] = GetGreen(i, j);
                }
            }
            return result;
        }

        /**
         * @return The "blue" values of the image as two dimensional array
         */
        public int[,] GetBlue()
        {
            int[,] result = new int[this.width, this.height];
            for (int i = 0; i < this.width; ++i)
            {
                for (int j = 0; j < this.height; ++j)
                {
                    result[i, j] = GetBlue(i, j);
                }
            }
            return result;
        }

        /**
         * @param x
         * @param y
         * @param value
         */
        public void SetRed(int x, int y, int value)
        {
            SetColor(x, y, value, GetGreen(x, y), GetBlue(x, y));
        }

        /**
         * @param x
         * @param y
         * @param value
         */
        public void SetGreen(int x, int y, int value)
        {
            SetColor(x, y, GetRed(x, y), value, GetBlue(x, y));
        }

        /**
         * @param x
         * @param y
         * @param value
         */
        public void SetBlue(int x, int y, int value)
        {
            SetColor(x,y,GetRed(x,y), GetGreen(x, y),value);
        }

        /**
         * @param x
         * @param y
         * @param r
         * @param g
         * @param b
         */
        public void SetColor(int x, int y, int r, int g, int b)
        {
            r = (r > 255 ? 255 : r);
            g = (g > 255 ? 255 : g);
            b = (b > 255 ? 255 : b);
            this.bitmap.SetPixel(x, y, Color.FromArgb(0,r,g,b));
        }

        /**
         * @param x
         * @param y
         * @param color
         */
        public void SetColor(int x, int y, Color color)
        {
            this.bitmap.SetPixel(x, y, color);
        }

        /**
         * 
         */
        public void ShowImage()
        {
            //          this.f = new JFrame(this.title);
            //          this.f.addWindowListener(new WindowAdapter(){
            //              @Override

            //              public void windowClosing(WindowEvent e)
            //          {
            //              System.exit(0);
            //          }
            //      });

            //this.f.add(this);
            //this.f.pack();
            //this.f.setVisible(true);
        }

        /* (non-Javadoc)
         * @see java.awt.Component#paint(java.awt.Graphics)
         */
        //public void paint(Graphics g)
        //{
        //    g.drawImage(this.bi, 0, 0, null);
        //}

        /**
         * @param newTitle
         */
        public void SetTitle(string newTitle)
        {
            this.title = "SimpleImage - " + newTitle;
        }

        /**
         * 
         */
        public string GetTitle()
        {
            return this.title;
        }

        /* (non-Javadoc)
         * @see java.awt.Component#getPreferredSize()
         */
        //public Dimension getPreferredSize()
        //{
        //    if (this.bi == null)
        //    {
        //        return new Dimension(100, 100);
        //    }
        //    return new Dimension(this.bi.getWidth(null), this.bi.getHeight(null));
        //}

        /**
         * 
         */
        public void Refresh()
        {
            form.UpdateImage(bitmap);
        }

        /**
         * @return The window's width
         */
        public int Width()
        {
            return this.width;
        }

        /**
         * @return The window's height
         */
        public int Height()
        {
            return this.height;
        }

        /**
         * @return Two dimensional array of the image's pixels
         */
        public Color[,] GetColors()
        {
            Color[,] result = new Color[this.width, this.height];
            for (int i = 0; i < this.width; ++i)
            {
                for (int j = 0; j < this.height; ++j)
                {
                    result[i, j] = GetColor(i, j);
                }
            }
            return result;
        }

        /**
         * @param i
         * @param j
         * @return The pixel in location (x, y)
         */
        public Color GetColor(int i, int j)
        {
            //TODO: Remove this:
            //System.out.println("A: "+ getRed(i,j));
            //System.out.println("B: "+ getGreen(i,j));
            //System.out.println("C: "+ getBlue(i,j));
            return Color.FromArgb(0, GetRed(i, j), GetGreen(i, j), GetBlue(i, j));
        }
    }
}
