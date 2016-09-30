using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class FormGameOver : Form
    {
        Form form;
        public FormGameOver(string message, Form form)
        {
            InitializeComponent();
            labelMessage.Text = message;
            this.form = form;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            form.Close();
            this.Close();
        }
    }
}
