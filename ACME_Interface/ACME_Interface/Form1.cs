using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Newtonsoft.Json;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using System.IO;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ACME_Interface
{
    public partial class Form1 : Form
    {
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
            public string imdbID;

        }

        public class Wishlist
        {
            public string[] IDs = new string[20];
            public int items; // hold number of items in the wishlist

        }

        public Form1() // equivelent to the Main() in a program.cs, it is the first thing that runs which is where things should be initialised.
        {
			InitializeComponent();
			radioButton1.Checked = true;
            string OApiKey = "&apikey=d6b3c2ae";
            string OAddress = "http://www.omdbapi.com/";
            //Wishlist wList = new Wishlist();  // initialise wishlist object  
            wList = new Wishlist();
            OMovie movieInfo = new OMovie();
            apiKey = OApiKey;
            ReadWishlist(ref wList);
            textBox2.Text = "Open Load Movie";


            WriteWishList(); // do this on close
        }

        public Wishlist wList;
        public string apiKey;
        public string webAddress;
        public string currentID;

        private void ReadWishlist(ref Wishlist wList) // read the wishlist file into a string to then be split up into an arrary of movie obejct
        {
            OMovie movieInfo = new OMovie();
            string[] readWishlist = { "" };
            if (File.Exists(@"C:\Users\tomwe\Documents\University\Software Engineering\ACMEv2\ACME_Interface\Wishlist.txt") == false)
            {
                System.IO.File.WriteAllLines(@"C:\Users\tomwe\Documents\University\Software Engineering\ACMEv2\ACME_Interface\Wishlist.txt", readWishlist);
            }

            string filmListStr;
            int count = 0;
            foreach (string j in wList.IDs)     // initiate wishlist values
            {
                wList.IDs[count] = "";
                count++;
            }

            // break whole string down into an array of strings, one element for each imdb id
            using (StreamReader r = new StreamReader(@"C:\Users\tomwe\Documents\University\Software Engineering\ACMEv2\ACME_Interface\Wishlist.txt"))  // I think this section needs some json extension to work as there is no .net library built in.  // "..\\WishList.txt"
            {
                filmListStr = r.ReadToEnd(); // this section works.
            }

            if (filmListStr != null)
            {
                count = 0;
                foreach (char c in filmListStr)
                {
                    if (c == ';') // when the character is a semi-colon move onto the next index
                        count++;
                    else
                        wList.IDs[count] = wList.IDs[count] + c;
                }
            }
            else
                textBox2.Text = "Wish List file is empty, please add a film before trying to look at it again";

        }

        private void WriteWishList() // convert string[] to string
        {
            string fileDir = @"C:\Users\tomwe\Documents\University\Software Engineering\ACMEv2\ACME_Interface\Wishlist.txt";
            string contents = "";
            int count = 0;
            foreach (string s in wList.IDs)
            {
                contents = contents + wList.IDs[count] + ';';
                count++;
            }

           // MessageBox.Show(contents, "wishlist out");

            System.IO.File.WriteAllText(fileDir, contents); //WriteAllText() rather than WriteAllLine() as this is for string array
            //Console.WriteLine("Wishlist written to file");
            //Console.ReadKey();
        }


        private void button1_Click(object sender, EventArgs e) // section for omdbAPI button click
        {
            string textBoxValue = textBox1.Text;
            webAddress = "http://www.omdbapi.com/";
            apiKey = "&apikey=d6b3c2ae";
            //TextBoxString mc = new TextBoxString();
            //mc.MyProperty = textBox1_TextChanged.Text;
            string sAddress = webAddress + "?t=" + textBoxValue + apiKey;
            OMovie searchMovie = new OMovie();
            InvalidOId invalid = new InvalidOId();
            string contents;
            using (var client = new WebClient())
            {
                contents = client.DownloadString(sAddress); // apikey unauthorized
                if (contents.Contains("False"))
                {
                    invalid = JsonConvert.DeserializeObject<InvalidOId>(contents);
                    //OSearch_Results(invalid);
                }
                else
                {
                    searchMovie = JsonConvert.DeserializeObject<OMovie>(contents);
                    OSearch_Results(searchMovie);
                }
            }

            currentID = searchMovie.imdbID;

		}

		private void debugInstructionsLabel_Click(object sender, EventArgs e)
		{

		}

		private void helloWorldLabel_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e) // wishlist button
		{
            apiKey = "&apikey=d6b3c2ae";
            //wList = new Wishlist();
            OMovie movieInfo = new OMovie();
            //ReadWishlist(ref wList);
            string s = "", contents = "";
            int i = 0;
            while ((i <=19)&(wList.IDs[i] != ""))
            {
                using (var client = new WebClient()) // possible put this section of the code into a seperate function as it is used many other times in the program
                {
                    string address = "http://www.omdbapi.com/?i=" + wList.IDs[i] + apiKey;
                    contents = client.DownloadString(address);    // contents was originally of type var not string, declared here      // http://www.omdbapi.com/  ?i=tt389619   &apikey=d6b3c2ae
                    if (contents.Contains("False"))
                        Console.WriteLine("Random ID is not valid");
                    else
                        movieInfo = JsonConvert.DeserializeObject<OMovie>(contents);
                }
                if (movieInfo.title != "-1")
                    s = s + (i + 1) + ". " + movieInfo.title + "\r\n"; // write the output to textbox
                i++;
            }
            textBox2.Text = s + "\r\nMovie Wishlist";

        }

        // region for random
        #region 
        //____________________ start of random functionality
        private void button4_Click(object sender, EventArgs e) // Random Film Button
		{
            string OApiKey = "&apikey=d6b3c2ae";
            OMovie movieInfo = new OMovie();
            movieInfo = RandomInput(OApiKey);
            string message =
            "\nTitle:    " + movieInfo.title.ToString() +
            "\r\nYear:     " + movieInfo.year.ToString() +
            "\r\nRating:   " + movieInfo.rated.ToString() +
            "\r\nReleased: " + movieInfo.released.ToString() +
            "\r\nRuntime:  " + movieInfo.runtime.ToString() +
            "\r\nGenre:    " + movieInfo.genre.ToString() +
            "\r\nDirector: " + movieInfo.director.ToString();
            //"\r\nPoster:   " + movieInfo.poster.ToString();
            string caption = "Randomly generated film";
            textBox2.Text = message;

            //MessageBox.Show(message, caption);
            pictureBox1.ImageLocation = movieInfo.poster.ToString();


        }
        
        static OMovie RandomInput(string apiKey) // ----- change string to string[]
        {
            OMovie movieInfo = new OMovie();
            InvalidOId contentsIn = new InvalidOId();
            string contents;


            // -- push the contents from random generation into the object
            do
            {
                string id = RandomGenerate();

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
            Random rnd = new Random();
            int imdbIdNo = rnd.Next(1, 1500000);  // ?? need to find a way of making sure the ID is valid.  ??
            string imdbId = imdbIdNo.ToString();
            while (imdbId.Length < 7)
                imdbId = "0" + imdbId;
            imdbId = "tt" + imdbId;

            return imdbId;
        }
        //___________________ end of random functonality 
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e) // section for the text box on the form 
		{

		}

        public class TextBoxString
        {
            public string MyProperty { get; set; }
        }

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
            string searchtxt = "  ";
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
				 //Search_Results(searchtxt);
				};
			}
			else
			{
				//Search_Results(searchtxt);
			}
		}

		private void button5_Click(object sender, EventArgs e) // this button event for "about"
		{
			const string message = "This product uses the TMDb API but is not endorsed or certified by TMDb.";
			const string caption = "About";
			MessageBox.Show(message, caption, MessageBoxButtons.OK);
		}

		
		private void OSearch_Results(OMovie movieInfo)
		{
			const String Name = "Film Name: ";// +flimName + "ID:" +;
            string message = "" +
                "\r\nTitle:    " + movieInfo.title.ToString() +
                "\r\nYear:     " + movieInfo.year.ToString() +
                "\r\nRating:   " + movieInfo.rated.ToString() +
                "\r\nReleased: " + movieInfo.released.ToString() +
                "\r\nRuntime:  " + movieInfo.runtime.ToString() +
                "\r\nGenre:    " + movieInfo.genre.ToString() +
                "\r\nDirector: " + movieInfo.director.ToString();
                //"\r\nPoster:   " + movieInfo.poster.ToString(); 
            //var result = MessageBox.Show(message,  "Search Results");
            textBox2.Text = message;
            pictureBox1.ImageLocation = movieInfo.poster.ToString();
            //if (result == DialogResult.yes)
            //database.add = id;
        }

        // classes classification for OMDb_API results


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // text box on the main screen for dispaying the movie information
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = "Are you sure you want to add movie to wishlist?", caption = "Add movie";
            DialogResult dr = MessageBox.Show(s,caption,MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    AddToWishlist(ref wList,currentID);
                    break;
                case DialogResult.No:
                    //continue
                    break;
            }

        }

        private void AddToWishlist(ref Wishlist wList, string IdToAdd) //, OMovie chosenMovie)
        {
            int count = 0; // used to have this at -1
            foreach (string s in wList.IDs) // find the next possible index to store a value
            {
                if (s != "") // if string is not null then there must be a movie in that location so move to the next one
                    count++;
            }
            if (count < wList.IDs.Length){ // if the end location is 
                wList.IDs[count] = IdToAdd;
                string s = wList.IDs[count];
                MessageBox.Show(s, "output id added");
        }
            else
            {
                Console.WriteLine("Wishlist is full, please remove an item before adding a new movie");
                // -> "would you like to remove an item from the wishlist? (Y/N)"
                //removeWishlistItem(ref wList);
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteWishList();
        }
    }
}
