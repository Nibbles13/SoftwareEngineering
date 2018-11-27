using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using OpenQA.Selenium.Support.UI;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ACME_Interface
{
    public partial class Form1 : Form
    {

        public Form1()
        {
			InitializeComponent();
			radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
			if (radioButton2.Checked == true)
			{
				int idLng = textBox1.TextLength;
				if (idLng != 9)
				{
					string message = "Invalid IMDb ID has been entered";
					string caption = "Error";

					MessageBox.Show(message, caption);
				}
				else
				{
					Search_Results();
				};
			}
			else
			{
				Search_Results();
			}
		}

		private void debugInstructionsLabel_Click(object sender, EventArgs e)
		{

		}

		private void helloWorldLabel_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			
		}

		private void button4_Click(object sender, EventArgs e)
		{
			

			/*
			Random rnd = new Random();
			int numb = rnd.Next(5);

			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			


			using (var client = new WebClient())
			{
				//var contents = client.DownloadString("http://www.google.co.uk");
				//Console.WriteLine(contents);
				//Console.Read();
			
				//Notice navigation is slightly different than the Java version
				//This is because 'get' is a keyword in C#
				if (numb == 0)
				{
					var contents = client.DownloadString("http://www.omdbapi.com/?i=tt0116231&apikey=d6b3c2ae");
					Console.WriteLine(contents);
					Console.Read();
				}
				else if (numb == 1)
				{
					var contents = client.DownloadString("http://www.omdbapi.com/?i=tt0082971&apikey=d6b3c2ae");
					Console.WriteLine(contents);
					Console.Read();
				}
				else if (numb == 2)
				{
					var contents = client.DownloadString("http://www.omdbapi.com/?i=tt1130884&apikey=d6b3c2ae");
					Console.WriteLine(contents);
					Console.Read();
				}
				else if (numb == 3)
				{
					var contents = client.DownloadString("http://www.omdbapi.com/?i=tt0050212&apikey=d6b3c2ae");
					Console.WriteLine(contents);
					Console.Read();
				}
				else if (numb == 4)
				{
					var contents = client.DownloadString("http://www.omdbapi.com/?i=tt0051201&apikey=d6b3c2ae");
					Console.WriteLine(contents);
					Console.Read();
				}
				else
				{
					Console.WriteLine("oops");
					Console.Read();
				}
			}*/


		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
			if (radioButton2.Checked == true)
			{
				int idLng = textBox1.TextLength;
				if (idLng != 9)
				{
					string message = "Invalid IMDb ID has been entered";
					string caption = "Error";

					MessageBox.Show(message, caption);
				}
				else
				{
				 Search_Results();
				};
			}
			else
			{
				Search_Results();
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			const string message = "This product uses the TMDb API but is not endorsed or certified by TMDb.";
			const string caption = "About";
			MessageBox.Show(message, caption, MessageBoxButtons.OK);
		}

		
		 private void Search_Results()
		 {
			const String Name = "Film Name: ";// +flimName + "ID:" +;
			const String message = "Add to wish list?";
		 var result = MessageBox.Show(Name,  message, MessageBoxButtons.YesNo);

		//if (result == DialogResult.yes)
		//database.add = id;
		 }
		 
	}
}
