using System;
using System.Drawing;

namespace Chess
{
    public abstract class Figure
    {
        public int Index0 { get; protected set; }
        public int Index1 { get; protected set; }
        public Image Sprite { get; protected set; }

        public Figure()
        {
            this.Index0 = -1;
            this.Index1 = -1;
            this.Sprite = new Bitmap(1, 1);
        }

        public virtual void Move() { }
    }

    public class Pawn : Figure
    {
        public Pawn(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.Sprite = isWhite ? new Bitmap("image/white/pawn.png") : new Bitmap("image/black/pawn.png");
        }
    }
}
