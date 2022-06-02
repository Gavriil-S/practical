using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica.Forms.Day4_Forms
{
    public partial class EditAccount : Form
    {
        string number_caller;
        string date;
        string worker;
        public EditAccount(string caller, string Date, string Worker)
        {
            number_caller = caller;
            date = Date;
            worker = Worker;

            InitializeComponent();
        }
    }
}
