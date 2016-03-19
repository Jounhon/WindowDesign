using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ordering_System.Model;

namespace Ordering_System
{
    public partial class StartUpForm : Form
    {
        private CustomerSideForm _frontForm;
        private RestaurantSideForm _backForm;
        PresentationStartFormModel _startFromModel;
        SystemModel _systemModel;
        CategoryControl _categoryControl;

        public StartUpForm(PresentationStartFormModel startFromModel)
        {
            InitializeComponent();
            this._startFromModel = startFromModel;
            this._systemModel = _startFromModel.GetSystemModel();
            this._categoryControl = _systemModel.GetCategoryControl();
            _categoryControl.InitializeCategoryList();
            _systemModel.InitializeMealList();
            _frontForm = new CustomerSideForm(new PresentationFrontSideFormModel(_systemModel));
            _backForm = new RestaurantSideForm(new PresentationBackSideFormModel(_systemModel));
        }

        // show the custoer side form
        private void ClickFrontButton(object sender, EventArgs e)
        {
            _frontForm.Show();
            _frontForm.FormClosing += new FormClosingEventHandler(CloseFrontFrom);
            // _frontForm.FormClosed += new FormClosedEventHandler(CloseFrontForm);
            _frontButton.Enabled = false;
        }

        // show the restaurant side form
        private void ClickBackButton(object sender, EventArgs e)
        {
            _backForm.Show();
            _backForm.FormClosing += new FormClosingEventHandler(CloseBackFrom);
            //_backForm.FormClosed += new FormClosedEventHandler(CloseBackForm);
            _backButton.Enabled = false;
        }

        // close the forms
        private void ClickExitButton(object sender, EventArgs e)
        {
            if (_frontForm != null)
            {
                _frontForm.Close();
            }
            if (_backForm != null)
            {
                _backForm.Close();
            }
            this.Close();
        }

        // forntend form closing
        private void CloseFrontFrom(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _frontForm.Hide();
            _frontButton.Enabled = true;
        }

        // backend form closing
        private void CloseBackFrom(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _backForm.Hide();
            _backButton.Enabled = true;
        }
        //// frontend form closed
        //private void CloseFrontForm(object sender, FormClosedEventArgs e)
        //{
        //    _frontButton.Enabled = true;
        //}

        //// backend form closed
        //private void CloseBackForm(object sender, FormClosedEventArgs e)
        //{
        //    _backButton.Enabled = true;
        //}
    }
}
