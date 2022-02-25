using System.Collections.Generic;
using System.Drawing;

namespace Chess
{
    class Field
    {
        bool whiteTurn;
        public Cell[,] Cells { get; }
        public Image Sprite { get; }
        public Image HoveredSprite { get; }
        public Image SelectedSprite { get; }
        public int SpriteSizeX { get; }
        public int SpriteSizeY { get; }
        public int BorderWidth { get; }
        public float CellWidth { get; }
        public Point CellIndexHovered { get; private set; }
        public Point CellIndexSelected { get; private set; }
        public List<Figure> White { get; }
        public List<Figure> Black { get; }

        public bool WhiteTurn()
        {
            return whiteTurn;
        }

        public Field(int FormBorderHeight)
        {
            BorderWidth = 18;
            CellWidth = 77.5f;
            CellIndexHovered = new Point(-1,-1);
            CellIndexSelected = new Point(-1, -1);
            Sprite = new Bitmap("image/field.jpg");
            HoveredSprite = new Bitmap("image/CellHovered.png");
            SelectedSprite = new Bitmap("image/CellSelected.png");
            SpriteSizeX = 656;
            SpriteSizeY = 656;
            whiteTurn = true;

            White = new List<Figure>();
            Black = new List<Figure>();
            for (int i = 0; i < 8; i++)
            {
                White.Add(new Pawn(6, i, true));
                Black.Add(new Pawn(1, i, false));
            }

            Cells = new Cell[8, 8];
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    float left = BorderWidth + j * CellWidth;
                    float right = left + CellWidth;
                    float top = BorderWidth + i * CellWidth + FormBorderHeight;
                    float bottom = top + CellWidth;
                    Cells[i, j] = new Cell(i, j, left, top, right, bottom, false);
                }
            }
        }
        public void HoverCell(int x, int y)
        {
            bool isHovered = false;
            for (int i = 0; i < Cells.GetLength(0) && !isHovered; i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if(Cells[i,j].Left <= x &&
                        Cells[i,j].Right >=x &&
                        Cells[i,j].Top <= y &&
                        Cells[i,j].Bottom >= y)
                    {
                        CellIndexHovered = new Point(i, j);
                        isHovered = true;
                        break;
                    }
                }
            }

            if(!isHovered)
            {
                CellIndexHovered = new Point(-1, -1);
            }
        }
        public void SelectCell()
        {
            if(CellIndexSelected == CellIndexHovered)
            {
                CellIndexSelected = new Point(-1, -1);
            }
            else
            {
                CellIndexSelected = CellIndexHovered;
            }
        }

        public bool CallMove()
        {
            int Index0 = CellIndexSelected.X;
            int Index1 = CellIndexSelected.Y;
            if (CellIndexSelected != new Point(-1, -1) && 
                CellIndexHovered != new Point(-1, -1) &&
                CellIndexHovered != CellIndexSelected)
            {
                int NewIndex0 = CellIndexHovered.X;
                int NewIndex1 = CellIndexHovered.Y;
                foreach(Figure figure in Black)
                {
                    if(figure.Index0 == Index0 && figure.Index1 == Index1)
                    {
                        this.CellIndexSelected = new Point(-1, -1);
                        return figure.TryMove(NewIndex0, NewIndex1, ref whiteTurn, Black, White);
                    }
                }

                foreach (Figure figure in White)
                {
                    if (figure.Index0 == Index0 && figure.Index1 == Index1)
                    {
                        this.CellIndexSelected = new Point(-1, -1);
                        return figure.TryMove(NewIndex0, NewIndex1, ref whiteTurn, Black, White); ;
                    }
                }
            }
            return false;
        }
    }
}
