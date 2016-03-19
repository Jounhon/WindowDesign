using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering_System.Model
{
    public class PageControl
    {
        private int _page;

        public PageControl()
        {
            _page = 1;
        }

        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
            }
        }

        // init page
        public void InitializePage()
        {
            _page = 1;
        }

        // go privious page
        public void GoPreviousPage()
        {
            if (_page - 1 > 0)
                _page--;
        }        
    }
}
