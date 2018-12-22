using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadsAndDelegates
{
	delegate void UpdateProgressDelegate(int val);

    public partial class AsyncBad : Form
    {

        public AsyncBad()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new AsyncBad());
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
			// create a delegate and assign the target
	        var progDel = new UpdateProgressDelegate(StartProcess);
	        // called on a second thread
	        progDel?.BeginInvoke(100, null, null);
	        MessageBox.Show("Done with opeartion!");

        }

        //Called Asynchronously
        //This is BAD because helper thread is updating UI components directly
        private void StartProcess(int max)
        {
            this.pbStatus.Maximum = max;
            for (int i = 0; i <= max; i++)
            {
				// Bad, a 2ndry thread should never touch a GUI thread.
                Thread.Sleep(10);
	            lblOutput.Text = i.ToString(); // GUI thread
                this.pbStatus.Value = i;
            }
        }
    }
}
