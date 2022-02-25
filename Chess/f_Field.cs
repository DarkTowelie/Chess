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
        Field field = new Field();
        public f_Field()
        {
            InitializeComponent();
            this.ClientSize = new Size(field.SpriteSizeX, field.SpriteSizeY);
            FrameTimer.Start();
        }
        private void f_Field_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(field.Sprite, 0, 0, field.SpriteSizeX, field.SpriteSizeY);
            if(field.CellIndexHovered != new Point(-1, -1))
            {
                int index0 = field.CellIndexHovered.X;
                int index1 = field.CellIndexHovered.Y;
                gr.DrawImage(field.HoveredSprite, 
                    field.Cells[index0, index1].Left, 
                    field.Cells[index0, index1].Top,
                    field.CellWidth + 0.5f, field.CellWidth + 0.5f);
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            if (field.CellIndexSelected != new Point(-1, -1))
            {
                int index0 = field.CellIndexSelected.X;
                int index1 = field.CellIndexSelected.Y;
                gr.DrawImage(field.SelectedSprite,
                    field.Cells[index0, index1].Left,
                    field.Cells[index0, index1].Top,
                    field.CellWidth + 0.5f, field.CellWidth + 0.5f);
            }

            foreach(Figure figure in field.Black)
            {
                float X = field.Cells[figure.Index0, figure.Index1].Left;
                float Y = field.Cells[figure.Index0, figure.Index1].Top;
                gr.DrawImage(figure.Sprite, X, Y, field.CellWidth, field.CellWidth);
            }

            foreach (Figure figure in field.White)
            {
                float X = field.Cells[figure.Index0, figure.Index1].Left;
                float Y = field.Cells[figure.Index0, figure.Index1].Top;
                gr.DrawImage(figure.Sprite, X, Y, field.CellWidth, field.CellWidth);
            }
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void f_Field_MouseMove(object sender, MouseEventArgs e)
        {
            field.HoverCell(e.X, e.Y);
            this.Text = $"{e.X}; {e.Y}";
        }

        private void f_Field_Click(object sender, EventArgs e)
        {
            if(!field.CallMove())
            {
                field.SelectCell();
            }
        }
    }
}
