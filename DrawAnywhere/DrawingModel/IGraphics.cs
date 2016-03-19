using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;

namespace DrawingModel
{
    public interface IGraphics
    {
        //清除全部
        void ClearAll();
        
        //畫圓
        void DrawCircle(double[] data, int[] colors);

        //畫矩形
        void DrawRectangle(double[] data, int[] colors);

        //畫笑臉
        void DrawSmile(double[] data, int[] colors);

        //畫選擇框
        void DrawSelectedBorder(double[] data);
    }
}
