using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        string filePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files|*.*|C# class|*.cs*|TXT files|*.txt*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                labelName.Text = openFileDialog1.SafeFileName;
                if (File.Exists(filePath))
                {
                    textContent.Text = File.ReadAllText(filePath);
                    buttonSave.Enabled = true;
                    buttonSaveAs.Enabled = true;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(filePath, textContent.Text);
            MessageBox.Show("Soubor uložen");
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "NewFile.txt";
            saveFileDialog1.Filter = "Text file|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
                Text = filePath;
                File.WriteAllText(filePath, textContent.Text);
            }
        }
    }
}
