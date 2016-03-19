using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ordering_System;

namespace OrderTest
{
    [TestClass]
    public class PresentationStartFormTest
    {
        PrivateObject _target;
        PresentationStartFormModel _presentationModel;
        SystemModel _systemModel;
        [TestInitialize()]
        [DeploymentItem("Ordering_System.exe")]
        public void Initialize()
        {
            _systemModel = new SystemModel();
            _presentationModel = new PresentationStartFormModel(_systemModel);
            _target = new PrivateObject(_presentationModel);
        }
        [TestMethod()]
        public void PresentationTest()
        {
            SystemModel _model = _presentationModel.GetSystemModel();
            Assert.AreEqual(_systemModel, _model);
        }
    }
}
