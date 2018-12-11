using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)  // program for testing and finding out how to create some of the functionallity of JSON from the webfile to the Progrm
        {
            //              ::Initialisation of variables::

            Wishlist wList = new Wishlist();  // initialise wishlist object  
            OMovie movieInfo = new OMovie();
            string OApiKey = "&apikey=d6b3c2ae";
            string OAddress = "http://www.omdbapi.com/";
            string[] dbInfo = new string[3]; // string[] , 0 = db choice, 1 = apiKey, 2 = address;

            //set dbInfo[] for following fucntions
            dbInfo[0] = "O"; //c.ToString();
            dbInfo[1] = OApiKey;
            dbInfo[2] = OAddress;

            SearchList();
            AddToWishlist(ref wList, movieInfo.imdbId, movieInfo);

            ReadWishlist(ref wList);    // reads wishlist file saving the contents in a string array which will then be converted into a OMovie object to display the information for
            ShowWishList(wList);

            Console.ReadKey(); // hold program here as above is being used to test a few things

            movieInfo = SearchRead(dbInfo);
            // "Add this film to the wishlist?"
            AddToWishlist(ref wList,movieInfo.imdbId, movieInfo);


            Console.WriteLine(wList.IDs[0]); // this works and als reference works so that the actial values are chnaged 
            //WriteWishList(wList);

            Console.WriteLine("\n\n\nFile Written");
            Console.ReadLine();

            AddToWishlist(ref wList, "tt0537428", movieInfo);
            int count = 0;
            foreach(string s in wList.IDs) // make sure AddToWishlist has worked
            {
                Console.WriteLine("Movie in list" + wList.IDs[count]);
                count++;
            }

            //SearchList(); // exc eption when this runs, detailed in the programming log

 /*                         :: Need to add whole section about choosing which Db to be running functions from ::           */


            Console.ReadLine(); // just to hold the console.

        }

        // displays the OMovie information for other functions in the program
        static void ShowInfo(OMovie movieInfo)
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
        
        
        //wishlist region
        #region
        static void ShowWishList(Wishlist wList)
        {
            OMovie[] movieInfo = new OMovie[20]; // array of object one for each id in the array
            int count = 0;
            foreach (string s in wList.IDs)
            {
                if (wList.IDs[count] != "") // only go to show the info if there is an id in that location in the array otherwse it throws exception
                {
                    movieInfo[count] = SearchOnID(wList.IDs[count]);
                    Console.WriteLine("\n{0}. ", count);
                    ShowInfo(movieInfo[count]);
                }
                count++;
            }
        }
           
        static void ReadWishlist(ref Wishlist wList) // read the wishlist file into a string to then be split up into an arrary of movie obejct
        {
            string[] readWishlist = { "" };
            if (File.Exists(@"C: \Users\tomwe\Documents\University\Software Engineering\Projects\MovieDbProjectConsoleApp\MovieDbProjectConsoleApp\WishList.txt") == false)
            {
                System.IO.File.WriteAllLines(@"C:\Users\tomwe\Documents\University\Software Engineering\Projects\MovieDbProjectConsoleApp\MovieDbProjectConsoleApp\WishList.txt", readWishlist);
                Console.WriteLine("File does not exist");
            }
            else
                Console.WriteLine("File Exists");

            //  -->  filmWishList; // use this public Object WishList so can access it across the program
            string filmListStr;

            int count = 0;
            foreach (string i in wList.IDs)     // initiate wishlist values
            {
                wList.IDs[count] = "";
                count++;
            }
            
              // break whole string down into an array of strings, one element for each imdb id
            using (StreamReader r = new StreamReader(@"C:\Users\tomwe\Documents\University\Software Engineering\Projects\MovieDbProjectConsoleApp\MovieDbProjectConsoleApp\WishList.txt"))  // I think this section needs some json extension to work as there is no .net library built in.  // "..\\WishList.txt"
            {
                filmListStr = r.ReadToEnd();
            }

            if (filmListStr != null)
            {
                //Console.WriteLine(filmListStr + "  film list string"); // display results so console
                count = 0;
                foreach (char c in filmListStr)
                {
                    if (c == ';') // when the character is a semi-colon move onto the next index
                        count++;
                    else
                        wList.IDs[count] = wList.IDs[count] + c;
                }
                
            }else
                Console.WriteLine("Wish List file is empty, please add a film before trying to look at it again");
            
            /*  // use this for testing to see if the read is working
            foreach(string s in wList.IDs) // output the read ids so I know that it is working
            {
                if (s != "") 
                    Console.WriteLine(s + "  Movie");
            }
            */       
        }

        static void AddToWishlist(ref Wishlist wList, string IdToAdd, OMovie chosenMovie)
        {
            Console.Write("Would you like to add {0}, {1} to your wishlist? (Y/N)",chosenMovie.title,chosenMovie.year);
            char choice = ' ';
            choice = Console.ReadKey().KeyChar;

            if (choice == 'Y') // movie is chosen to be added to this wishlist
            {
                int count = 0; // used to have this at -1
                foreach (string s in wList.IDs) // find the next possible index to store a value
                {
                    if (s != "") // if string is not null then there must be a movie in that location so move to the next one
                        count++;
                }
                if (count < wList.IDs.Length) //(wList.IDs[wList.IDs.Length] != "") // if the end location is 
                    wList.IDs[count] = chosenMovie.imdbId;
                else
                {
                    Console.WriteLine("Wishlist is full, please remove an item before adding a new movie");
                    // -> "would you like to remove an item from the wishlist? (Y/N)"
                    removeWishlistItem(ref wList);
                }
            }
        }

        static void removeWishlistItem(ref Wishlist wList)
        {
            char cOption;
            int iOption;

            Console.WriteLine("Choose one of the following options to remove from the wishlist");
            ShowWishList(wList);
            cOption = Console.ReadKey().KeyChar;
            iOption = Convert.ToInt32(cOption);
            //Add conformation if statement before deleting the option.
            wList.IDs[iOption] = "";
            Console.WriteLine("Movie removed"); // can change it around so that it will say the movie name has been removed?
        }

        static void WriteWishList(Wishlist wList) // convert string[] to string
        {
            string fileDir = @"C: \Users\tomwe\Documents\University\Software Engineering\Projects\MovieDbProjectConsoleApp\MovieDbProjectConsoleApp\WishList.txt";
            string contents = "";
            int count = 0;
            foreach(string s in wList.IDs)
            {
                contents = contents + wList.IDs[count] + ';';
                count++;
            }

            System.IO.File.WriteAllText(fileDir, contents); //WriteAllText() rather than WriteAllLine() as this is for string array
            Console.WriteLine("Wishlist written to file");
            Console.ReadKey();
        }

        #endregion


        // random region 
        #region

        static OMovie RandomInput(string apiKey) // ----- change string to string[]
        {
            OMovie movieInfo = new OMovie();
            InvalidOId contentsIn = new InvalidOId();
            string contents;

            // -- push the contents from random generation into the object
            do
            {
                string id = RandomGenerate();

                using (var client = new WebClient()) // possible put this section of the code into a seperate function as it is used many other times in the program
                {
                    string address = "http://www.omdbapi.com/?i=" + id + apiKey;
                    //Console.WriteLine(address);
                    contents = client.DownloadString(address);    // contents was originally of type var not string, declared here      // http://www.omdbapi.com/  ?i=tt389619   &apikey=d6b3c2ae
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

        #endregion

        // search region
        #region

        static OMovie SearchList()// searches on a word which brings a list of results which the user chooses one of amd returns the information on that film in object.
        {
            OMovie[] movieInfo = new OMovie[10];
            string[] sList = new string[10];
            Console.Write("Enter Search Item: ");
            string searchVal = Console.ReadLine();
            string sAddress  = "http://www.omdbapi.com/?s=";
            string apiKey = "&apikey=d6b3c2ae";
            string contents;
            using (var client = new WebClient())    // pulls the json from the web
            {
                string address = sAddress+ searchVal + apiKey;
                //Console.WriteLine(address);
                contents = client.DownloadString(address);
            }
            string contents2 = ""; // new string making json an array
            // Console.WriteLine(contents);
            bool arrayBound = false;
            string[] jsonStr = new string[10];
            int count = -1;
            char last= ' ';
            if (contents.Contains("True")) // moves data from string into string[]
            {
                foreach(char c in contents)
                {
                    if ((c == ',') & (last == '}'))
                        continue;
                    if (arrayBound)
                    {
                        if (c == ']')
                            arrayBound = false;
                        else
                        {
                            jsonStr[count] = jsonStr[count] + c;
                            if (c == '}')
                                count++;
                        }
                        
                    }
                    else
                    {
                        if (c == '[')
                        {
                            arrayBound = true;
                            contents2 = contents2 + c;
                            count++;
                        }
                        
                    }

                    last = c;
                }
            }
            Console.WriteLine("Choose one of the following options (1-10)");

            for (int i = 0; i < count; i++) 
            {
                movieInfo[i] = JsonConvert.DeserializeObject<OMovie>(jsonStr[i]);
                Console.WriteLine("{0}. {1}, ({2})", i+1, movieInfo[i].title, movieInfo[i].year);
            }

            char choice = Console.ReadKey().KeyChar;
            int choiceI = choice - '0';
            choiceI--;



            Console.WriteLine(movieInfo[choiceI].title+" chosen");
            return movieInfo[choiceI];
        }
        


        static OMovie SearchOnID(string ID)
        {
            OMovie movieInfo = new OMovie();
            string apiKey = "&apikey=d6b3c2ae";
            string IdAddress = "http://www.omdbapi.com/?i=";
            string address = IdAddress + ID + apiKey;
            string contents = "";

            using (var client = new WebClient()) // possible put this section of the code into a seperate function as it is used many other times in the program
            {
                //Console.WriteLine(address);
                contents = client.DownloadString(address);    // contents was originally of type var not string, declared here      // http://www.omdbapi.com/  ?i=tt389619   &apikey=d6b3c2ae
                if (contents.Contains("False") == false)
                    movieInfo = JsonConvert.DeserializeObject<OMovie>(contents);    // if the json string includes the word error then deserialise into contents(invalid)
                else
                    Console.WriteLine("Movie not found  -  try again"); // UPDATE -> change this around so that when the 
                                                                        //contentsIn = JsonConvert.DeserializeObject<InvalidOId>(contents);
            }
            return movieInfo;
        }

        static string SearchGenerate(string[] dbInfo) //string[] , 0 = db choice, 1 = apiKey, 2 = address;
        {
            string address = "";
            Console.Write("Enter Search Item (one word): ");
            string searchItem = Console.ReadLine();
            address = dbInfo[2] + "?t=" + searchItem + dbInfo[1];
            Console.WriteLine(address);
            return address;
        } // http://www.omdbapi.com/?t=shrek&apikey=d6b3c2ae


        static OMovie SearchRead(string[] dbInfo)
        {
            OMovie movieInfo = new OMovie();
            InvalidOId contentsIn = new InvalidOId();
            string contents;
            using (var client = new WebClient())
            {
                contents = client.DownloadString(SearchGenerate(dbInfo));    // contents was originally of type var not string, declared here      // http://www.omdbapi.com/  ?i=tt389619   8&apikey=d6b3c2ae
                if (contents.Contains("False"))
                    contentsIn = JsonConvert.DeserializeObject<InvalidOId>(contents);   // if the json string includes the word error then deserialise into contents(invalid)
                else
                    movieInfo = JsonConvert.DeserializeObject<OMovie>(contents);

            }

            return movieInfo;
        }

        #endregion

        // test region
        #region

        public void LoadShrekJson() // just originally to help to understand json & c# compatibility
        {
            using (StreamReader r = new StreamReader("shrek.json"))  // I think this section needs some json extension to work as there is no .net library built in.
            {
                string json = r.ReadToEnd();
                List<OMovie> movie = JsonConvert.DeserializeObject<List<OMovie>>(json);
            }

        }
        #endregion

        // class region
        #region
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
            public string imdbId;
        }

        // Classes classification for TMDb API
        public class TMovie
        {
            //    https://api.themoviedb.org/3/               movie/76341 ?api_key=7e929b51f75e77af894a92da22cfd032
        }


        public class Wishlist
        {
            public string[] IDs = new string[20];

        }

        #endregion

    }
}
