using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;

namespace DrawAnywhereUnitTest
{
    [TestClass]
    public class ButtonControlTest
    {
        const bool IS_CIRCLE_ENABLED = true;
        const bool IS_RECTANGLE_ENABLED = false;
        const bool IS_SMILE_ENABLED = false;
        const bool IS_REDO_ENABLED = true;
        const bool IS_UNDO_ENABLED = true;
        const bool IS_DELETE_ENABLED = true;
        PrivateObject _target;
        ButtonControl _control;
        [TestInitialize()]
        [DeploymentItem("DrawingModel.dll")]
        public void Initialize()
        {
            _control = new ButtonControl();
            _target = new PrivateObject(_control);
        }
        [TestMethod()]
        public void IsCircleEnabledTest()
        {
            Assert.IsFalse((bool)_target.GetProperty("IsCircleEnabled"));
            _control.IsCircleEnabled = IS_CIRCLE_ENABLED;
            Assert.IsTrue((bool)_target.GetProperty("IsCircleEnabled"));
        }
        [TestMethod()]
        public void IsRectangleEnabledTest()
        {
            Assert.IsTrue((bool)_target.GetProperty("IsRectangleEnabled"));
            _control.IsRectangleEnabled = IS_RECTANGLE_ENABLED;
            Assert.IsFalse((bool)_target.GetProperty("IsRectangleEnabled"));
        }
        [TestMethod()]
        public void IsSmileEnabledTest()
        {
            Assert.IsTrue((bool)_target.GetProperty("IsSmileEnabled"));
            _control.IsSmileEnabled = IS_SMILE_ENABLED;
            Assert.IsFalse((bool)_target.GetProperty("IsSmileEnabled"));
        }
        [TestMethod()]
        public void IsRedoEnabledTest()
        {
            Assert.IsFalse((bool)_target.GetProperty("IsRedoEnabled"));
            _control.IsRedoEnabled = IS_REDO_ENABLED;
            Assert.IsTrue((bool)_target.GetProperty("IsRedoEnabled"));
        }
        [TestMethod()]
        public void IsUndoEnabledTest()
        {
            Assert.IsFalse((bool)_target.GetProperty("IsUndoEnabled"));
            _control.IsUndoEnabled = IS_UNDO_ENABLED;
            Assert.IsTrue((bool)_target.GetProperty("IsUndoEnabled"));
        }
        [TestMethod()]
        public void IsDeleteEnabledTest()
        {
            Assert.IsFalse((bool)_target.GetProperty("IsDeleteEnabled"));
            _control.IsDeleteEnabled = IS_DELETE_ENABLED;
            Assert.IsTrue((bool)_target.GetProperty("IsDeleteEnabled"));
        }
    }
}
