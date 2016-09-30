using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoKrzyzyk
{
    public partial class FormOverlayClickable : Form
    {
        Point pointToClick = new Point();
        public Point PointToClick { get { return pointToClick; } }

        public FormOverlayClickable(Form parent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.ClientSize = parent.ClientSize;
            Size size = new Size();
            size = parent.Controls.Find("flowLayoutPanelBoard", false)[0].Size;
            Point position = new Point();
            position.X = parent.Controls.Find("flowLayoutPanelBoard", false)[0].Location.X + parent.Location.X;
            position.Y = parent.Controls.Find("flowLayoutPanelBoard", false)[0].Location.Y + parent.Location.Y;
            this.ClientSize = size;
            this.ShowInTaskbar = false;
            this.Location = position;

        }


        private void MouseClicked(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.X + " " + e.Y);
            this.Hide();
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            pointToClick.X = e.X;
            pointToClick.Y = e.Y;
            this.Hide();
        }

        private void FocusLeft(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
