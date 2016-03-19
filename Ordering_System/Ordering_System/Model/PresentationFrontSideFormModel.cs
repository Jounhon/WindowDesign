using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering_System.Model;

namespace Ordering_System
{
    public class PresentationFrontSideFormModel
    {
        SystemModel _model;
        PageControl _pageControl;
        bool _isPreviousButtonVisible = true;
        bool _isNextButtonVisible = true;
        bool _isRecordDataGridViewReadOnly = false;
        bool _isTextBoxColumnReadOnly = true;
        bool _isNumericUpDownColumnReadOnly = false;

        public PresentationFrontSideFormModel(SystemModel systemModel)
        {
            this._model = systemModel;
            this._pageControl = _model.GetPageControl();
        }

        // get system model
        public SystemModel GetSystemModel()
        {
            return _model;
        }

        //get numeric up and down column read only
        public bool IsNumericUpDownColumnReadOnly
        {
            get
            {
                return _isNumericUpDownColumnReadOnly;
            }
        }

        // get text box column read only
        public bool IsTextBoxColumnReadOnly
        {
            get
            {
                return _isTextBoxColumnReadOnly;
            }
        }

        // get record data grid view read only
        public bool IsRecordDataGridViewReadOnly
        {
            get
            {
                return _isRecordDataGridViewReadOnly;
            }
        }

        // get previous button visible
        public bool IsPreviousButtonVisible
        {
            get
            {
                return _isPreviousButtonVisible;
            }
        }

        // get next button visible
        public bool IsNextButtonVisible
        {
            get
            {
                return _isNextButtonVisible;
            }
        }

        // invisible next button
        public void CheckNextButton(string categoryName)
        {
            if (_pageControl.Page.Equals(_model.GetMaxPage(categoryName)))
                _isNextButtonVisible = false;
            else
                _isNextButtonVisible = true;
        }

        // invisible previous button
        public void CheckPreviousButton()
        {
            if (_pageControl.Page.Equals(1))
                _isPreviousButtonVisible = false;
            else
                _isPreviousButtonVisible = true;
        }
    }
}
