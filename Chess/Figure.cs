using System;
using System.Collections.Generic;
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

        public virtual bool TryMove(int newIndex0, int newIndex1, ref bool whiteTurn, List<Figure> White, List<Figure> Black) 
        { 
            return false; 
        }

        public bool CheckFigurePosition(Figure figure, int newIndex0, int newIndex1)
        {
            if(newIndex0 == figure.Index0 && newIndex1 == figure.Index1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChecListFigurePosition(List<Figure> figures, int newIndex0, int newIndex1)
        {
            foreach(Figure figure in figures)
            {
                if(CheckFigurePosition(figure, newIndex0, newIndex1))
                {
                    return true;
                }
            }
            return false;
        }
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

        override public bool TryMove(int newIndex0, int newIndex1, ref bool whiteTurn, List<Figure> Black, List<Figure> White)
        {
            if(IsWhite && whiteTurn && TryMoveWhite(newIndex0, newIndex1, Black, White))
            {
                whiteTurn = false;
                return true;
            }

            if (!IsWhite && !whiteTurn && TryMoveBlack(newIndex0, newIndex1, Black, White))
            {
                whiteTurn = true;
                return true;
            }
            return false;
        }

        bool TryMoveWhite(int newIndex0, int newIndex1, List<Figure> Black, List<Figure> White)
        {
            if (!ChecListFigurePosition(Black, newIndex0, newIndex1) && !ChecListFigurePosition(White, newIndex0, newIndex1))
            {
                if (this.Index0 == 6 &&
                    newIndex0 == this.Index0 - 2 &&
                    newIndex1 == this.Index1)
                {
                    this.Index0 = newIndex0;
                    return true;
                }

                if (newIndex0 >= 0 &&
                    newIndex0 == this.Index0 - 1 &&
                    newIndex1 == this.Index1)
                {
                    this.Index0 = newIndex0;
                    return true;
                }
            }
            else
            {
                if (ChecListFigurePosition(White, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (this.Index0 - 1 == newIndex0 && 
                    (this.Index1 + 1 == newIndex1 || this.Index1 - 1 == newIndex1))
                {
                    for (int i = 0; i < Black.Count; i++)
                    {
                        if (Black[i].Index0 == newIndex0 && Black[i].Index1 == newIndex1)
                        {
                            this.Index0 = newIndex0;
                            this.Index1 = newIndex1;
                            Black.RemoveAt(i);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        bool TryMoveBlack(int newIndex0, int newIndex1, List<Figure> Black, List<Figure> White)
        {
            if (!ChecListFigurePosition(Black, newIndex0, newIndex1) && !ChecListFigurePosition(White, newIndex0, newIndex1))
            {
                if (this.Index0 == 1 &&
                    newIndex0 <= 8 &&
                    newIndex0 == this.Index0 + 2 &&
                    newIndex1 == this.Index1)
                {
                    this.Index0 = newIndex0;
                    return true;
                }

                if (newIndex1 <= 8 &&
                    newIndex0 == this.Index0 + 1 &&
                    newIndex1 == this.Index1)
                {
                    this.Index0 = newIndex0;
                    return true;
                }
            }
            else
            {
                if (ChecListFigurePosition(Black, newIndex0, newIndex1))
                {
                    return false;
                }
                else if (this.Index0 + 1 == newIndex0 &&
                            (this.Index1 + 1 == newIndex1 || this.Index1 - 1 == newIndex1))
                {
                    for (int i = 0; i < White.Count; i++)
                    {
                        if (White[i].Index0 == newIndex0 && White[i].Index1 == newIndex1)
                        {
                            this.Index0 = newIndex0;
                            this.Index1 = newIndex1;
                            White.RemoveAt(i);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}