using INDAxisTools.IO;
using INDAxisTools.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INDAxisTools.Processing;

namespace INDAxisTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Axis Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = dlg.FileName;

                txtOutput.Text =
                    Path.Combine(
                        Path.GetDirectoryName(dlg.FileName),
                        Path.GetFileNameWithoutExtension(dlg.FileName) +
                        "_Offset.txt");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtInput.Text))
            {
                MessageBox.Show("Input file not found.");
                return;
            }

            double offset;

            if (!double.TryParse(txtOffset.Text, out offset))
            {
                MessageBox.Show("Invalid offset.");
                return;
            }

            Cursor = Cursors.WaitCursor;

            lblStatus.Text = "Reading...";

            List<AxisPoint> input =
                AxisReader.Read(txtInput.Text);

            lblStatus.Text = "Generating Offset...";

            List<AxisPoint> output =
                AxisOffsetGenerator.Generate(
                    input,
                    offset,
                    rbLeft.Checked);

            lblStatus.Text = "Writing...";

            AxisWriter.Write(
                txtOutput.Text,
                output);

            Cursor = Cursors.Default;

            lblStatus.Text = "Finished";

            MessageBox.Show("Completed.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
