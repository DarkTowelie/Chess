using System;
using System.Drawing;

namespace Chess
{
    public abstract class Figure
    {
        public int Index0 { get; protected set; }
        public int Index1 { get; protected set; }
        public Image Sprite { get; protected set; }
        public bool IsWhite { get; protected set; }

        public Figure()
        {
            this.Index0 = -1;
            this.Index1 = -1;
            this.Sprite = new Bitmap(1, 1);
            this.IsWhite = false;
        }

        public virtual void Move(int newIndex0, int newIndex1) { }
    }

    public class Pawn : Figure
    {
        public Pawn(int Index0, int Index1, bool isWhite)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.IsWhite = isWhite;
            this.Sprite = isWhite ? new Bitmap("image/white/pawn.png") : new Bitmap("image/black/pawn.png");
        }

        override public void Move(int newIndex0, int newIndex1) {
            if(IsWhite)
            {
                this.Index0--;
            }
            else
            {
                this.Index0++;
            }
        }
    }
}
