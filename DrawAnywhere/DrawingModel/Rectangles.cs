using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Rectangles : Shape
    {
        //畫矩形
        public override void Draw(IGraphics graphics)
        {
            double[] data = { PositionX, PositionY, Width, Height };
            graphics.DrawRectangle(data, Color);
            if (Border)
                graphics.DrawSelectedBorder(data);
        }
    }
}
