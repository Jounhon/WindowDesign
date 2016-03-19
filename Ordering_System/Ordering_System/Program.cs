using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ordering_System.Model;

namespace Ordering_System
{
    class Program
    {
        // Main Function to Run Form
        [STAThread]
        static void Main(string[] args)
        {
            StartUpForm startForm = new StartUpForm(new PresentationStartFormModel(new SystemModel()));
            Application.EnableVisualStyles();
            Application.Run(startForm);
        }
    }
}
