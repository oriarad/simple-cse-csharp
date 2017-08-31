using System;
using System.Windows.Forms;

namespace SimpleCSE
{
    public partial class SimpleGoogleMapsForm : Form
    {
        public SimpleGoogleMapsForm()
        {
            InitializeComponent();
        }
        public void SetImage(string url)
        {
            pictureBox1.ImageLocation = url;
        }

        private void SimpleGoogleMapsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
