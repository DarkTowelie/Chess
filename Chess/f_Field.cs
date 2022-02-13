using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class f_Field : Form
    {
        Field field = new Field("image/field.jpg");
        public f_Field()
        {
            InitializeComponent();
            this.Width = 676;
            this.Height = 699;
        }
        private void f_Field_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(field.Sprite, 0, 0, field.SpriteSizeX, field.SpriteSizeY); ;

        }
    }
}
