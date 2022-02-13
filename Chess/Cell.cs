using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Cell
    {
        public float Left { get; }
        public float Top { get; }
        public float Right { get; }
        public float Bottom { get; }

        public bool IsHot { get; set; }
        public bool IsFront { get; }

        public Cell(float Left, float Top, float Right, float Bottom, bool IsHot, bool IsFront)
        {
            this.Left = Left;
            this.Top = Top;
            this.Right = Right;
            this.Bottom = Bottom;
            this.IsHot = IsHot;
            this.IsFront = IsFront;
        }

    }
}
