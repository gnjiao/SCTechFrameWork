using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifAnimation
{
    public partial class GifShow : Form
    {
        /// <summary>
        /// Initial from getting picture file to bitmap instance
        /// </summary>
        /// <param name="fileName">picture file path</param>
        public GifShow(string fileName)
        {
            InitializeComponent();
            this.TopMost = true;
            this.pictureBox1.Image = new Bitmap("./" + fileName);
        }

        /// <summary>
        /// Set style to FormBorderStyle.None, it means no border
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GifShow_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
        }

        /// <summary>
        /// Set hint text
        /// </summary>
        /// <param name="hintText">what word you want to inform?</param>
        public void setHintText(string hintText)
        {
            this.label1.Text = hintText;
        }
    }
}
