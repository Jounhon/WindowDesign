using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;

namespace DrawAnywhereUnitTest
{

    [TestClass]
    public class ShapeTest
    {
        const double INIT_POSITION_X = 80;
        const double INIT_POSITION_Y = 20;
        const double INIT_RADIUS = 20;
        const bool BODER = true;
        int[] _initColors = { 255, 255, 255, 255 };
        PrivateObject _target;
        Shape _shape;
        [TestInitialize()]
        [DeploymentItem("DrawingModel.dll")]
        public void Initialize()
        {
            _shape = new Shape();
            _shape.PositionX = INIT_POSITION_X;
            _shape.PositionY = INIT_POSITION_Y;
            _shape.Width = INIT_RADIUS;
            _shape.Height = INIT_RADIUS;
            _shape.Color = _initColors;
            _target = new PrivateObject(_shape);
        }
        [TestMethod()]
        public void ShapePropertyTest()
        {
            Assert.AreEqual(INIT_POSITION_X, _target.GetProperty("PositionX"));
            Assert.AreEqual(INIT_POSITION_Y, _target.GetProperty("PositionY"));
            Assert.AreEqual(INIT_RADIUS, _target.GetProperty("Width"));
            Assert.AreEqual(INIT_RADIUS, _target.GetProperty("Height"));
            Assert.AreEqual(_initColors, _target.GetProperty("Color"));
            Assert.IsFalse((bool)_target.GetProperty("Border"));
            _shape.Border = BODER;
            Assert.IsTrue((bool)_target.GetProperty("Border"));
        }
        [TestMethod()]
        public void ShapeSetDataTest()
        {
            _shape = new Shape();
            _shape.SetData(INIT_POSITION_X + 1, INIT_POSITION_Y, INIT_RADIUS, INIT_RADIUS);
            _target = new PrivateObject(_shape);
            Assert.AreEqual(INIT_POSITION_X + 1, _target.GetProperty("PositionX"));
            Assert.AreEqual(INIT_POSITION_Y, _target.GetProperty("PositionY"));
            Assert.AreEqual(INIT_RADIUS, _target.GetProperty("Width"));
            Assert.AreEqual(INIT_RADIUS, _target.GetProperty("Height"));
        }
        [TestMethod()]
        public void ShapeDrawTest()
        {
            _shape.Draw(null);
        }
    }
}
