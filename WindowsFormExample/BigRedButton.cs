using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormExample
{
	public partial class BigRedButton : Form
	{
		public BigRedButton()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Button was clicked");

		}

		private void button2_MouseUp(object sender, MouseEventArgs e)
		{
			MessageBox.Show(e.X.ToString());
				
		}
	}
}
