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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                //Notice navigation is slightly different than the Java version
                //This is because 'get' is a keyword in C#
                driver.Navigate().GoToUrl("http://www.omdbapi.com/?i=tt0116231&apikey=d6b3c2ae");

				// Find the text input element by its name
				//IWebElement query = driver.FindElement(By.Name("t"));

				// Enter something to search for
				// query.SendKeys("Cheese");

				// Now submit the form. WebDriver will find the form for us from the element
				//IWebElement element = driver.FindElement(By.Id("submit"));
				//query.Submit();

				// Google's search is rendered dynamically with JavaScript.
				// Wait for the page to load, timeout after 10 seconds
				// var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
				// wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

				// Should see: "Cheese - Google Search" (for an English locale)
				Console.WriteLine("Film data is: " + driver.PageSource);
            }


            MessageBox.Show("Thanks!");

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
			Random rnd = new Random();
			int numb = rnd.Next(5);

			/*
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			*/


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
			}
			
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
