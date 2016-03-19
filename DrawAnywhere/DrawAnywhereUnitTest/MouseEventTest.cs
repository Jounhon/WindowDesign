using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System.Collections.Generic;

namespace DrawAnywhereUnitTest
{
    [TestClass]
    public class MouseEventTest
    {
        const int DEFAULT = -1;
        PrivateObject _target;
        Model _model;
        MouseEventModel _mouseEventModel;
        [TestInitialize()]
        [DeploymentItem("DrawingModel.dll")]

        public void Initialize()
        {
            _model = new Model();
            _mouseEventModel = new MouseEventModel(_model);
            _target = new PrivateObject(_mouseEventModel);
        }
        [TestMethod()]
        public void PropertyShapeListTest()
        {
            List<Shape> list = new List<Shape>();
            Shape shape = new Shape();
            list.Add(shape);
            _mouseEventModel.ShapeList = list;
        }
        [TestMethod()]
        public void PropertyIsPressedTest()
        {
            Assert.IsFalse((bool)_target.GetProperty("IsPressed"));
        }
        [TestMethod()]
        public void PropertyIsSelectedTest()
        {
            Shape shape = _mouseEventModel.IsSelected;
        }
    }
}
