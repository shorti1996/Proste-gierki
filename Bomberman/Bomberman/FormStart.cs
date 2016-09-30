using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class FormStart : Form
    {
        string map;
        public FormStart()
        {
            InitializeComponent();
            string[] files = System.IO.Directory.GetFiles(@"Maps/");
            comboBoxMap.Items.AddRange(files);
            if (files != null)
                comboBoxMap.Text = files[0];
        }

        private void comboBoxMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            map = Path.GetFileName(comboBoxMap.Text);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CreateFormMain);
            thread.Start();
        }

        private void CreateFormMain()
        {
            Form FormMain = new FormMain(map, this);
            Screen screen = Screen.FromControl(FormMain);
            int height = (int)(screen.WorkingArea.Height * 0.9);
            int width = (int)(screen.WorkingArea.Width * 0.9);
            FormMain.Size = new Size(width, height);
            FormMain.ShowDialog();
        }
    }
}
