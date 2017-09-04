using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCSE
{
    public partial class SimpleImageForm : Form
    {
        public SimpleImageForm()
        {
            InitializeComponent();
        }

        private void SimpleImageForm_Load(object sender, EventArgs e)
        {
            //LoadImage("");
            Bitmap flag = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int red = 0;
            int white = 11;
            while (white <= 100)
            {
                flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }
            //this.pictureBox1.Image = flag;
            UpdateImage(flag);

            InitializeComponent();
            this.pictureBox1.Image = flag;
        }

        public PictureBox GetPictureBox()
        {
            return pictureBox1;
        }

        public Image GetImage()
        {
            return pictureBox1.Image;
        }

        public void LoadImage(string filename)
        {
            //////Bitmap bitmap = (Bitmap)Image.FromFile(filename);
            //this.SetImage(bitmap);
            //this.pictureBox1.Image = bitmap;
            //this.pictureBox1.ImageLocation = "c:\\temp\\sample.jpg";
            //this.pictureBox1.Image =
            Bitmap flag = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int red = 0;
            int white = 11;
            while (white <= 100)
            {
                flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }
            //pictureBox1.
            // this.pictureBox1 = new PictureBox();
            //this.pictureBox1.Image.
            this.pictureBox1.Image = flag;
            /////this.pictureBox1.Image = bitmap;
        }

        public void SetImage(Image image)
        {
            pictureBox1.Image = image;
        }

        public void UpdateImage(Bitmap bmp)
        {
            //InitializeComponent();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;


            //this.pictureBox1 = new PictureBox();
            pictureBox1.Image = bmp;

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();



            InitializeComponent();
            this.pictureBox1.Image = bmp;
        }
    }
}
