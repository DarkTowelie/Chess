using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Cell
    {
        public int Index0 { get; }
        public int Index1 { get; }

        public float Left { get; }
        public float Top { get; }
        public float Right { get; }
        public float Bottom { get; }

        public bool IsHot { get; set; }

        public Cell(int Index0, int Index1, float Left, float Top, float Right, float Bottom, bool IsHot)
        {
            this.Index0 = Index0;
            this.Index1 = Index1;
            this.Left = Left;
            this.Top = Top;
            this.Right = Right;
            this.Bottom = Bottom;
            this.IsHot = IsHot;
        }
    }
}
