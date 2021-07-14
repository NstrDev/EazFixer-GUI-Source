using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace EazFixerAPI
{
    public static class API
    {
        public static void Deobfuscate(MetroTextBox eazfixerfile1, MetroTextBox inputfile1, MetroCheckBox virt_fix1, MetroCheckBox keep_types1, MetroTextBox outputlog1)
        {
            if (!File.Exists(eazfixerfile1.Text) || !File.Exists(inputfile1.Text))
            {
                MessageBox.Show("Invalid Files", "Eaz Fixer API");
                return;
            }

            string argm = $"--file \"{inputfile1.Text}\"";
            if (keep_types1.Checked)
            {
                argm += " --keep-types";
            }

            if (virt_fix1.Checked)
            {
                argm += " --virt-fix";
            }

            try
            {
                string filename = Path.GetFileName(eazfixerfile1.Text);
                string direc = Path.GetDirectoryName(eazfixerfile1.Text);
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.Arguments = argm;
                p.StartInfo.WorkingDirectory = direc;
                p.StartInfo.FileName = eazfixerfile1.Text;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                outputlog1.Text = output;
                MessageBox.Show("Completed", "Eaz Fixer API");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}