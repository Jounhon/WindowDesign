using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System.Collections.Generic;

namespace DrawAnywhereUnitTest
{
    [TestClass]
    public class ModelTest
    {
        const double INIT_POSITION_X = 80;
        const double INIT_POSITION_Y = 20;
        const double FALSE_POSITION_X = 0;
        const double FALSE_POSITION_Y = 0;
        const int INIT_WIDTH = 20;
        const int INIT_HEIGHT = 30;
        const string CIRCLE_TYPE = "DrawingModel.Circles";
        const string RECTANGLE_TYPE = "DrawingModel.Rectangles";
        int[] _colors = { 0, 0, 0, 0 };
        double[] _datas = { INIT_POSITION_X, INIT_POSITION_Y, INIT_WIDTH, INIT_HEIGHT };
        PrivateObject _target;
        Model _model;
        [TestInitialize()]
        [DeploymentItem("DrawingModel.dll")]

        public void Initialize()
        {
            _model = new Model();
            _model.ChangeShape(CIRCLE_TYPE);
            _target = new PrivateObject(_model);
        }
        [TestMethod()]
        public void GetShapesTest()
        {
            List<Shape> list = _model.GetShapes;
            Assert.AreEqual(list, _target.GetProperty("GetShapes"));
        }
        [TestMethod()]
        public void ChangeShapeTest()
        {
            _model.ChangeShape(CIRCLE_TYPE);
        }
        [TestMethod()]
        public void ChangeColorTest()
        {
            _model.ChangeColor(_colors);
        }
        [TestMethod()]
        public void PressTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
        }
        [TestMethod()]
        public void MoveTest()
        {
            _model.Move(INIT_POSITION_X, INIT_POSITION_Y);
        }
        [TestMethod()]
        public void ReleaseTest()
        {
            _model.Release(INIT_POSITION_X, INIT_POSITION_Y);
        }
        [TestMethod()]
        public void AddOneShapeTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            List<Shape> list = _model.GetShapes;
            Assert.AreEqual(1, list.Count);
            _model.Undo();
        }
        [TestMethod()]
        public void ChangeSelectedShapeColorTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Press(INIT_POSITION_X + 10, INIT_POSITION_Y + 10);
            _model.ChangeColor(_colors);
            _model.Undo();
            _model.Redo();
        }
        [TestMethod()]
        public void MakeClearTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.MakeClear();
            _model.Undo();
            _model.Redo();
        }
        [TestMethod()]
        public void AddDataShapeTest()
        {
            _model.AddDataShape(CIRCLE_TYPE, _datas, _colors);
            List<Shape> list = _model.GetShapes;
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod()]
        public void DeleteSelectedShapeTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Press(INIT_POSITION_X + 10, INIT_POSITION_Y + 10);
            _model.DeleteSelectedShape();
            _model.Undo();
            _model.Redo();
        }
        [TestMethod()]
        public void MoveSelectedShapeTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Press(INIT_POSITION_X + 10, INIT_POSITION_Y + 10);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Undo();
            _model.Redo();
        }
        [TestMethod()]
        public void ResizeSelectedShapeTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            List<Shape> list = _model.GetShapes;
            _model.Press(list[0].PositionX + 2, list[0].PositionY + 2);
            _model.Release(list[0].PositionX + 2, list[0].PositionY + 2);
            _model.Move(list[0].PositionX + 1, list[0].PositionY + 1);
            _model.Press(list[0].PositionX + 1, list[0].PositionY + 1);
            _model.Move(INIT_POSITION_X - 10, INIT_POSITION_Y - 10);
            _model.Release(INIT_POSITION_X - 10, INIT_POSITION_Y - 10);
            _model.Undo();
            _model.Redo();
        }
        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            _model._modelChanged += HandleModelChanged;
            _model.MakeClear();
        }
        void HandleModelChanged()
        {
        }
        [TestMethod()]
        public void GetIsRedoEnableTest()
        {
            _model.Redo();
            Assert.IsFalse((bool)_target.GetProperty("IsRedoEnabled"));
            _model.MakeClear();
            _model.Undo();
            Assert.IsTrue((bool)_target.GetProperty("IsRedoEnabled"));
        }
        [TestMethod()]
        public void GetIsUndoEnableTest()
        {
            _model.Undo();
            Assert.IsFalse((bool)_target.GetProperty("IsUndoEnabled"));
            _model.MakeClear();
            Assert.IsTrue((bool)_target.GetProperty("IsUndoEnabled"));
        }
        [TestMethod()]
        public void IsSelectedTest()
        {
            Assert.IsFalse((bool)_target.GetProperty("IsSelected"));
        }
        [TestMethod()]
        public void MouseEventDrawModeTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Release(INIT_POSITION_X, INIT_POSITION_Y);
        }
        [TestMethod()]
        public void MouseEventSetShapeTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X - 10, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X, INIT_POSITION_Y - 10);
        }
        [TestMethod()]
        public void MouseEventCalculateRadiusTest()
        {
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_HEIGHT, INIT_POSITION_Y + INIT_WIDTH);
            _model.Release(INIT_POSITION_X + INIT_HEIGHT, INIT_POSITION_Y + INIT_WIDTH);
            _model.Press(INIT_POSITION_X + 1, INIT_POSITION_Y + 1);
        }
        [TestMethod()]
        public void MouseEventCheckExistTest()
        {
            _model.ChangeShape(CIRCLE_TYPE);
            _model.Press(INIT_POSITION_Y, INIT_POSITION_X);
            _model.Move(INIT_POSITION_Y + INIT_HEIGHT, INIT_POSITION_X + INIT_WIDTH);
            _model.Release(INIT_POSITION_Y + INIT_HEIGHT, INIT_POSITION_X + INIT_WIDTH);
            _model.ChangeShape(RECTANGLE_TYPE);
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_HEIGHT, INIT_POSITION_Y + INIT_WIDTH);
            _model.Release(INIT_POSITION_X + INIT_HEIGHT, INIT_POSITION_Y + INIT_WIDTH);
            _model.Press(INIT_POSITION_X + 1, INIT_POSITION_Y + 1);
        }
        [TestMethod()]
        public void MouseEventCheckAnchorLeftTopTest()
        {
            _model.ChangeShape(RECTANGLE_TYPE);
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            List<Shape> list = _model.GetShapes;
            _model.Press(list[0].PositionX + 2, list[0].PositionY + 2);
            _model.Release(list[0].PositionX + 2, list[0].PositionY + 2);
            // left-top
            _model.Move(list[0].PositionX - 1, list[0].PositionY + 1);
            _model.Move(list[0].PositionX + 1, list[0].PositionY - 1);
            _model.Move(list[0].PositionX - 1, list[0].PositionY - 1);
            _model.Move(list[0].PositionX + 1, list[0].PositionY + 1); // true

            _model.Press(list[0].PositionX + 1, list[0].PositionY + 1);
            _model.Move(list[0].PositionX - 10, list[0].PositionY - 10);
        }
        [TestMethod()]
        public void MouseEventCheckAnchorLeftBottomTest()
        {
            _model.ChangeShape(RECTANGLE_TYPE);
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            List<Shape> list = _model.GetShapes;
            _model.Press(list[0].PositionX + 2, list[0].PositionY + 2);
            _model.Release(list[0].PositionX + 2, list[0].PositionY + 2);
            // left-bottom
            _model.Move(list[0].PositionX - 1, list[0].PositionY + list[0].Height + 1);
            _model.Move(list[0].PositionX - 1, list[0].PositionY + list[0].Height - 1);
            _model.Move(list[0].PositionX + 1, list[0].PositionY + list[0].Height + 1);
            _model.Move(list[0].PositionX + 1, list[0].PositionY + list[0].Height - 1);// true

            _model.Press(list[0].PositionX + 1, list[0].PositionY + list[0].Height - 1);
            _model.Move(list[0].PositionX - 10, list[0].PositionY + list[0].Height + 10);
        }
        [TestMethod()]
        public void MouseEventCheckAnchorRightTopTest()
        {
            _model.ChangeShape(RECTANGLE_TYPE);
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            List<Shape> list = _model.GetShapes;
            _model.Press(list[0].PositionX + 2, list[0].PositionY + 2);
            _model.Release(list[0].PositionX + 2, list[0].PositionY + 2);
            // right-top
            _model.Move(list[0].PositionX + list[0].Width - 1, list[0].PositionY + 1);
            _model.Move(list[0].PositionX + list[0].Width - 1, list[0].PositionY - 1);
            _model.Move(list[0].PositionX + list[0].Width + 1, list[0].PositionY + 1);
            _model.Move(list[0].PositionX + list[0].Width - 1, list[0].PositionY + 1);// true

            _model.Press(list[0].PositionX + list[0].Width - 1, list[0].PositionY + 1);
            _model.Move(list[0].PositionX + list[0].Width + 10, list[0].PositionY - 10);
        }
        [TestMethod()]
        public void MouseEventCheckAnchorRightBottomTest()
        {
            _model.ChangeShape(RECTANGLE_TYPE);
            _model.Press(INIT_POSITION_X, INIT_POSITION_Y);
            _model.Move(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            _model.Release(INIT_POSITION_X + INIT_WIDTH, INIT_POSITION_Y + INIT_HEIGHT);
            List<Shape> list = _model.GetShapes;
            _model.Press(list[0].PositionX + 2, list[0].PositionY + 2);
            _model.Release(list[0].PositionX + 2, list[0].PositionY + 2);
            // right-bottom
            _model.Move(list[0].PositionX + list[0].Width - 1, list[0].PositionY + list[0].Height + 1);
            _model.Move(list[0].PositionX + list[0].Width + 1, list[0].PositionY + list[0].Height - 1);
            _model.Move(list[0].PositionX + list[0].Width + 1, list[0].PositionY + list[0].Height + 1);
            _model.Move(list[0].PositionX + list[0].Width - 1, list[0].PositionY + list[0].Height - 1);// true

            _model.Press(list[0].PositionX + list[0].Width - 1, list[0].PositionY + list[0].Height - 1);
            _model.Move(list[0].PositionX + list[0].Width + 10, list[0].PositionY + list[0].Height + 10);
        }
    }
}
