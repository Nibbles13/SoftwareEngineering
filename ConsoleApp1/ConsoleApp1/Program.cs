using System;
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
            Console.WriteLine("Choose from OMdb_API (O) or The_Movie_DB_API (M) [M in progress]");
            char c = Console.ReadKey().KeyChar;
            c = char.ToUpper(c); 
            if (c == 'O')
            {
                OMovie movieInfo = new OMovie();
                movieInfo = RandomInput();
                
                // display movie info (from OMDbapi)
                if (movieInfo.title != null)
                {
                    Console.WriteLine("   Title: {0} ", movieInfo.title.ToString());
                    Console.WriteLine("    Year: {0} ", movieInfo.year.ToString());
                    Console.WriteLine("  Rating: {0} ", movieInfo.rated.ToString());
                    Console.WriteLine("Released: {0} ", movieInfo.released.ToString());
                    Console.WriteLine(" Runtime: {0} ", movieInfo.runtime.ToString());
                    Console.WriteLine("   Genre: {0} ", movieInfo.genre.ToString());
                    Console.WriteLine("Director: {0} ", movieInfo.director.ToString());
                    Console.WriteLine("  Poster: {0} ", movieInfo.poster.ToString());
                }
                else // error message
                {
                    Console.WriteLine("This movie ID does not exsits -- random generator must try again"); // this line shouldn't be needed anymore having updated the while loop
                }
            }else if (c == 'M')
            {

            }

            Console.ReadLine(); // just to hold the console.

        }

        static OMovie RandomInput()
        {
            OMovie movieInfo = new OMovie();
            InvalidOId contentsIn = new InvalidOId();
            string contents;


            // -- push the contents from random generation into the object
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
                        contentsIn = JsonConvert.DeserializeObject<InvalidOId>(contents);   // if the json string includes the word error then deserialise into contents(invalid)
                    else
                        movieInfo = JsonConvert.DeserializeObject<OMovie>(contents);
                }
            } while (movieInfo.title == null);
            return movieInfo;
        }

        static string RandomGenerate()
        // generate a random number that will be used as the imdb ID number
        // This does not really work because the chances of it generating an Id for a film rather than tv show, episode or actor is unlikely and so does not return correct results.
        {
            Console.WriteLine("Continue to search a random movie on the DB");
            char cont = Console.ReadKey().KeyChar;
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

        public void LoadShrekJson()
		{
			using (StreamReader r = new StreamReader("shrek.json"))  // I think this section needs some json extension to work as there is no .net library built in.
			{
				string json = r.ReadToEnd();
				List<OMovie> movie = JsonConvert.DeserializeObject<List<OMovie>>(json); 
			}

		}

        // classes classification for OMDb_API results
        public class InvalidOId
        {
            public string Response;
            public string Error;
        }

		public class OMovie
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

        // Classes classification for TMDb API
        public class TMovie
        {
            //    https://api.themoviedb.org/3/               movie/76341 ?api_key=7e929b51f75e77af894a92da22cfd032
        }


    }
}
