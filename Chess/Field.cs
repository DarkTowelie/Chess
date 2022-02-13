using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Field
    {
        public Cell[,] Cells { get; }
        public Image Sprite { get; }
        public int SpriteSizeX { get; }
        public int SpriteSizeY { get; }

        public Field(string spriteSrc)
        {
            Cells = new Cell[8, 8];
            for(int i = 0; i < Cells.GetLength(0); i++)
            {
                for(int j = 0; j < Cells.GetLength(1); j++)
                {
                    int left = 18 + i * 78;
                    int right = left + 78;
                    int top = 18 + j * 78;
                    int bottom = top + 78;
                    bool front = (j == 0 || j == Cells.Length - 1);
                    Cells[i, j] = new Cell(left, top, right, bottom, false, front);
                }
            }
            Sprite = new Bitmap(spriteSrc);
            SpriteSizeX = 656;
            SpriteSizeY = 656;
        }
    }
}
