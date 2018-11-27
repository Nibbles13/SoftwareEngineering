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
            }



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
            //}


        }

    }
}
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;


namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)  // program for testing and finding out how to create some of the functionallity of JSON from the webfile to the Progrm
		{
			Movie movieInfo = new Movie();
			invalidId wrongAns = new invalidId // create object to represent what is output if the imdb id is wrong.
			{
				Response = "False",
				Error = "Incorrect IMDb ID."
			};
			string contents;
			invalidId contentsIn = new invalidId();
			do
			{
				string id = RandomGenerate();
				string apiKey = "&apikey=d6b3c2ae";
				using (var client = new WebClient())
				{
					string address = "http://www.omdbapi.com/?i=" + id + apiKey;
					//Console.WriteLine(address);
					contents = client.DownloadString(address);    // contents was originally of type var not string, declared here      // http://www.omdbapi.com/  ?i=tt389619   8&apikey=d6b3c2ae
					if (contents.Contains("False"))
						contentsIn = JsonConvert.DeserializeObject<invalidId>(contents);   // if the json string includes the word error then deserialise into contents(invalid)
					else
						movieInfo = JsonConvert.DeserializeObject<Movie>(contents);
				}
			} while (contentsIn == wrongAns);
			Console.WriteLine(movieInfo); // this is no how to output the whole object unfortunately
			Console.WriteLine("   mnTitle: {0} ", movieInfo.title.ToString());
			Console.WriteLine("    Year: {0} ", movieInfo.year.ToString());
			Console.WriteLine("  Rating: {0} ", movieInfo.rated.ToString());
			Console.WriteLine("Released: {0} ", movieInfo.released.ToString());
			Console.WriteLine(" Runtime: {0} ", movieInfo.runtime.ToString());
			Console.WriteLine("   Genre: {0} ", movieInfo.genre.ToString());
			Console.WriteLine("Director: {0} ", movieInfo.director.ToString());
			Console.WriteLine("  Poster: {0} ", movieInfo.poster.ToString());


			Console.ReadLine();

		}

		static string RandomGenerate()
		// generate a random number that will be used as the imdb ID number
		// This does not really work because the chances of it generating an Id for a film rather than tv show, episode or actor is unlikely and so does not return correct results.
		{
			Console.WriteLine("Continue to search a random movie on the DB");
			//char cont = Console.ReadKey().KeyChar;
			Random rnd = new Random();
			int imdbIdNo = rnd.Next(1, 1500000);  // ?? need to find a way of making sure the ID is valid.  ??
			string imdbId = imdbIdNo.ToString();
			while (imdbId.Length < 7)
				imdbId = "0" + imdbId;
			imdbId = "tt" + imdbId;
			Console.WriteLine(imdbId);
			//Console.ReadKey();

			return imdbId;
		}

		public void LoadJson()
		{
			using (StreamReader r = new StreamReader("shrek.json"))  // I think this section needs some json extension to work as there is no .net library built in.
			{
				string json = r.ReadToEnd();
				List<Movie> movie = JsonConvert.DeserializeObject<List<Movie>>(json);
			}

		}

		public class invalidId
		{
			public string Response;
			public string Error;
		}

		public class Movie
		{
			public string title;
			public string year;
			public string rated;
			public string released;
			public string runtime;
			public string genre;
			public string director;
			public string poster;

		}


	}
}

	*/