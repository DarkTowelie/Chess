using System.Drawing;

namespace Chess
{
    class Field
    {
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

        public Field()
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

            Cells = new Cell[8, 8];
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    float left = BorderWidth + i * CellWidth;
                    float right = left + CellWidth;
                    float top = BorderWidth + j * CellWidth;
                    float bottom = top + CellWidth;
                    bool front = (j == 0 || j == Cells.Length - 1);
                    Cells[i, j] = new Cell(left, top, right, bottom, false, front);
                }
            }
        }
        public void HoverCell(int x, int y)
        {
            bool isHoverd = false;
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if(Cells[i,j].Left <= x &&
                        Cells[i,j].Right >=x &&
                        Cells[i,j].Top <= y &&
                        Cells[i,j].Bottom >= y)
                    {
                        CellIndexHovered = new Point(i, j);
                        isHoverd = true;
                    }
                }
            }

            if(!isHoverd)
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
    }
}
