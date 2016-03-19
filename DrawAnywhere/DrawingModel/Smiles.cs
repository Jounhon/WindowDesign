using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Smiles : Shape
    {
        //畫笑臉
        public override void Draw(IGraphics graphics)
        {
            const int TWO = 2;
            double radius;
            if (Width > Height)
                radius = Width * Math.Sqrt(TWO) / TWO;
            else
                radius = Height * Math.Sqrt(TWO) / TWO;
            double[] data = { PositionX, PositionY, radius, radius };
            graphics.DrawSmile(data, Color);
            if (Border)
                graphics.DrawSelectedBorder(data);
        }
    }
}
