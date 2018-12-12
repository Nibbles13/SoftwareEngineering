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

namespace ACME_Interface
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            using (var client = new WebClient())
            {
                var contents = client.DownloadString("http://www.google.co.uk");
                Console.WriteLine(contents);
                Console.Read();
            };
        }
                       
        //public class OMovie // this is now situated in the main
        //{
        //    public string title;
        //    public string year;
        //    public string rated;
        //    public string released;
        //    public string runtime;
        //    public string genre;
        //    public string director;
        //    public string poster;

        //} 

        //using (IWebDriver driver = new FirefoxDriver())
        //{
        //    //Notice navigation is slightly different than the Java version
        //    //This is because 'get' is a keyword in C#
        //    driver.Navigate().GoToUrl("www.omdbapi.com/");

        //    // Find the text input element by its name
        //    IWebElement query = driver.FindElement(By.Name("q"));

        //    // Enter something to search for
        //    query.SendKeys("Cheese");

        //    // Now submit the form. WebDriver will find the form for us from the element
        //    query.Submit();

        //    // Google's search is rendered dynamically with JavaScript.
        //    // Wait for the page to load, timeout after 10 seconds
        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

        //    // Should see: "Cheese - Google Search" (for an English locale)
        //    Console.WriteLine("Page title is: " + driver.Title);
        //    //}


        //    //}
        //}
    }
}

