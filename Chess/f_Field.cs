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
        Field field;
        int offsetX;
        int offsetY;
        bool mouseDown;

        public f_Field()
        {
            InitializeComponent();
            field = new Field(p_FormBorder.Height);
            this.ClientSize = new Size(field.SpriteSizeX, field.SpriteSizeY + p_FormBorder.Height);
            b_Close.BackColor = Color.IndianRed;
            FrameTimer.Start();
        }
        private void f_Field_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            if(field.WhiteTurn())
            {
                p_FormBorder.BackColor = Color.White;
                p_FormBorder.ForeColor = Color.Black;
                l_Turn.Text = "Ход белых";
            }
            else
            {
                p_FormBorder.BackColor = Color.Black;
                p_FormBorder.ForeColor = Color.White;
                l_Turn.Text = "Ход черных";
            }

            gr.DrawImage(field.Sprite, 0, p_FormBorder.Height, field.SpriteSizeX, field.SpriteSizeY);
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

        private void p_FormBorder_MouseDown(object sender, MouseEventArgs e)
        {
            offsetX = e.X;
            offsetY = e.Y;
            mouseDown = true;
        }

        private void p_FormBorder_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void p_FormBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offsetX, currentScreenPos.Y - offsetY);
            }
        }

        private void b_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
