using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MP3_Tracker
{
    internal class Playlist
    {
        #region Fields


        private List<MP3> mp3List;
        private string name;
        private string playlistCreator;
        private string dateCreated;

        #endregion


        #region Getter
        public List<MP3> GetMP3List() //Made so I could access mp3List
        {
            return mp3List;
        }

        public string GetDateCreated() //So I can access the the date created in main
        {
            return dateCreated;
        }
        #endregion


        #region Constructors
        public Playlist()
        {
            this.mp3List = new List<MP3>();
            this.name = "N/A";
            this.playlistCreator = "N/A";
            this.dateCreated = "N/A";
        }
        public Playlist(List<MP3> mp3List, string name, string playlistCreator, string datecreated)
        {
            this.mp3List = mp3List;
            this.name = name;
            this.playlistCreator = playlistCreator;
            this.dateCreated = datecreated;
        }
        public Playlist(Playlist copyPlaylist)
        {
            this.mp3List = new List<MP3>(copyPlaylist.mp3List);
        }
        #endregion


        #region Add/Remove/Edit
        public void Add(MP3 mp3)
        {
            this.mp3List.Add(mp3);
        }
        public void Remove(MP3 mp3)
        {
            this.mp3List.Remove(mp3);
        }
        public void Edit(MP3 mp3)
        {
            string change = string.Empty;
            Genre changeE;
            int inputM = 0;
            bool validInputEdit = false;

            Console.Write("What would you like to change about the MP3?");
            Console.WriteLine($"\n--------------------------------------------");
            Console.WriteLine(" 1. Title" +
                "\n 2. Artist" +
                "\n 3. Release Date" +
                "\n 4. Playback Time" +
                "\n 5. Genre" +
                "\n 6. Download Cost $" +
                "\n 7. Size in MB:" +
                "\n 8. Path to Album Cover");


            Console.Write("\nWhat would you like to change about the MP3? ");

            while (validInputEdit == false)
            {
                try
                {
                    inputM = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"\n--------------------------------------------");
                    if (inputM > 0 && inputM < 9)
                    {
                        if (inputM == 1)
                        {
                            Console.Write("What would you like to change the title to? ");
                            change = Console.ReadLine();
                            mp3.SetSongTitle(change);
                            Console.WriteLine("----------------Successfully Changed the Title ------------------------\n");
                            validInputEdit = true;

                        }
                        else if (inputM == 2)
                        {
                            Console.Write("Who would you like to change the artist to? ");
                            change = Console.ReadLine();
                            mp3.SetSongArtist(change);
                            Console.WriteLine("----------------Successfully Changed the Artist -----------------------\n");
                            validInputEdit = true;
                        }
                        else if (inputM == 3)
                        {
                            Console.Write("What would you like to change the release date to? ");
                            bool validInput = false;//Try Catch for Release date
                            while (validInput == false)
                            {

                                try
                                {
                                    Console.Write("\nWhat is the song's month created(1-12)? ");
                                    int month = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("\nWhat is the song's day created (1-31)? ");
                                    int day = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("\nWhat is the song's year created(Ex. 2003, 2019)? ");
                                    int year = Convert.ToInt32(Console.ReadLine());
                                    if ((month > 0 && month < 13) && (day > 0 && day < 32) && (year <= Convert.ToInt32(DateTime.Now.Year.ToString()))) //Validate input is a valid date. Then convert to a string format and exit loop
                                    {
                                        change = $"{month}/{day}/{year}";
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not a valid date. Please try again.");
                                    }

                                }
                                catch
                                {
                                    Console.WriteLine("Invalid date try again.");
                                }

                            }
                            mp3.SetSongRelease(change);
                            validInputEdit = true;
                        }
                        else if (inputM == 4)
                        {
                            Console.Write("What would you like to change the playback time to? ");
                            change = Console.ReadLine();
                            double changeD = Convert.ToDouble(change);
                            mp3.SetPlayback(changeD);
                            Console.WriteLine("-------------Successfully Changed the Playback Time -------------------\n");
                            validInputEdit = true;
                        }
                        else if (inputM == 5)
                        {
                            try
                            {
                                Console.Write("What would you like to change the Genre to (Rock, Pop, Jazz, Country, Classical, Other)? ");
                                changeE = (Genre)Enum.Parse(typeof(Genre), (Console.ReadLine()));
                                mp3.SetGenre(changeE);
                                Console.WriteLine("----------------Successfully Changed the Genre-------------------------\n");
                                validInputEdit = true;
                            }
                            catch
                            {
                                changeE = Genre.Other;
                                Console.WriteLine("----------------Successfully Changed the Genre-------------------------\n");
                                validInputEdit = true;
                            }
                        }
                        else if (inputM == 6)
                        {
                            Console.Write("What would you like to change download cost to? ");
                            change = Console.ReadLine();
                            decimal changeDE = Convert.ToDecimal(change);
                            mp3.SetDLCost(changeDE);
                            Console.WriteLine("----------------Successfully Changed the Download Price ---------------\n");
                            validInputEdit = true;
                        }
                        else if (inputM == 7)
                        {
                            Console.Write("What would you like to change the file size to? ");
                            change = Console.ReadLine();
                            double changeD = Convert.ToDouble(change);
                            mp3.SetSizeInMB(changeD);
                            Console.WriteLine("----------------Successfully Changed the File Size---------------------\n");
                            validInputEdit = true;
                        }
                        else if (inputM == 8)
                        {
                            Console.Write("What would you like to change the file path to? ");
                            change = Console.ReadLine();
                            mp3.SetPath(change);
                            Console.WriteLine("----------------Successfully Changed the File Path---------------------\n");
                            validInputEdit = true;
                        }

                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input, please try again.");
                }

            }
        }



        #endregion


        #region Sort/Search

        public int SearchByTitle(string searchKey)
        {
            int foundIndex = -1;
            for (int i = 0; i < this.mp3List.Count; i++)
            {

                if (mp3List[i].GetSongTitle() == searchKey)
                {
                    foundIndex = i;
                }

            }
            return foundIndex;
        }
        public void SortByTitle()
        {
            for (int i = 0; i < mp3List.Count - 1; i++)
            {
                int min = i;
                for (int u = i + 1; u < mp3List.Count; u++)
                {
                    if (mp3List[u].GetSongTitle().CompareTo(mp3List[min].GetSongTitle()) < 0)
                    {
                        min = u;
                    }
                }
                if (min != i)
                {
                    MP3 temp = mp3List[i];
                    mp3List[i] = mp3List[min];
                    mp3List[min] = temp;
                }
            }


        }


        public void SortingByDate()
        {
            for (int i = mp3List.Count; i > 1; i--)
            {
                int max = i;
              
                    string[] strings = mp3List[i].GetSongRelease().Split("/");
                    string[] stringsU = mp3List[max].GetSongRelease().Split("/");
                    if (Convert.ToInt32(strings[2]) > Convert.ToInt32(stringsU[2])) //compare years
                    {
                        max = i;

                    }
                    else if(Convert.ToInt32(strings[2]) == Convert.ToInt32(stringsU[2]))
                    {
                        if (Convert.ToInt32(strings[0]) > Convert.ToInt32(stringsU[0])) //compare months
                        {
                            max = i;
                        }
                        else if(Convert.ToInt32(strings[0]) == Convert.ToInt32(stringsU[0]))
                        {
                            if (Convert.ToInt32(strings[1]) > Convert.ToInt32(stringsU[1]))
                            {
                                max = i;
                            }
                        }

                    }
                    else if(max != i-1)
                    {
                        MP3 temp = mp3List[i];
                        mp3List[i] = mp3List[max];
                        mp3List[max] = temp;
                    }


                
                /*     for (int i = mp3List.Count; i > 1; i--)
            {
                int min = i;
                for (int u = i + 1; i < mp3List.Count; u++)
                {
                    string[] strings = mp3List[i].GetSongRelease().Split("/");
                    string[] stringsU = mp3List[u].GetSongRelease().Split("/");
                    if (Convert.ToInt32(strings[2]) < Convert.ToInt32(stringsU[2])) //compare years
                    {
                        min = u;

                    }
                    else if(Convert.ToInt32(strings[2]) == Convert.ToInt32(stringsU[2]))
                    {
                        if (Convert.ToInt32(strings[0]) < Convert.ToInt32(stringsU[0])) //compare months
                        {
                            min = u;
                        }
                        else if(Convert.ToInt32(strings[0]) < Convert.ToInt32(stringsU[0]))
                        {
                            if (Convert.ToInt32(strings[1]) < Convert.ToInt32(stringsU[1]))
                            {
                                min = u;
                            }
                        }
                    }
                    if(min != u)
                    {
                        MP3 temp = mp3List[i];
                        mp3List[i] = mp3List[min];
                        mp3List[min] = temp;
                    }


                }
                */





            }

        }
        #endregion


        #region ToString
        public override string ToString()
        {
            string playlist = $"--------------------------------------------------" +
                $"\n--------------------------------------------------" +
                $"\nPlaylist Name: {name}" +
                $"\nCreation Date: {dateCreated}" +
                $"\nPlaylist creator: {playlistCreator}\n";
            for (int i = 0; i < mp3List.Count; i++)
            {
                playlist += $"\n--------------#{i + 1}--------------------";
                playlist += $"\n{mp3List[i].ToString()}";
            }
            return playlist;
        }
        #endregion


        public static int FindLargest(List<MP3> mp3List)
        {
            int posOfLargest = 0;


            for (int i = 1; i < mp3List.Count; i++)
            {
                //Used GetName to get the name of the Person array[i] and used CompareTo to compare the names of two objects.
                if (mp3List[i].)
                {

                    posOfLargest = i;
                }
            }

            //Return the largest item in the array
            return posOfLargest;
        }
    }
}
