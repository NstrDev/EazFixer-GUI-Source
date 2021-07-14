using System;
using System.Windows.Forms;
using EazFixerAPI;
using MetroFramework.Forms;

namespace EazFixer_GUI
{
    public partial class Menuform : MetroForm
    {
        public Menuform()
        {
            InitializeComponent();
        }

        private void Menuform_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = $@"{Environment.CurrentDirectory}\EazFixer.exe";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EazFixer (*.exe)|*.exe";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.ReadOnlyChecked = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            metroTextBox1.Text = openFileDialog.FileName;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "File (*.exe, *.dll)|*.exe;*.dll";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.ReadOnlyChecked = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            metroTextBox2.Text = openFileDialog.FileName;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            //Deob
            API.Deobfuscate(metroTextBox1, metroTextBox2, metroCheckBox1, metroCheckBox2, metroTextBox3);
        }
    }
}