using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EarTrainer
{
    public partial class Gui : Form
    {
        private Model model;

        public Gui()
        {
            InitializeComponent();
            model = new Model();
        }

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gui());
        }

        private void noteButton_Click(object sender, EventArgs e)
        {
            showTextBox.Text = "";
            model.SetRandomNote();
            model.Play();
        }

        private void intervalButton_Click(object sender, EventArgs e)
        {
            showTextBox.Text = "";
            model.SetRandomInterval();
            model.Play();
        }

        private void repeatButton_Click(object sender, EventArgs e)
        {
            model.Play();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showTextBox.Text = model.GetString();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (intervalBox.Text == "No interval")
            {
                model.Play(note1Box.Text);
            }
            else
            {
                model.Play(note1Box.Text, intervalBox.Text, directionBox.Text);
            }
        }
    }
}
