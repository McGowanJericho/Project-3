/**

*--------------------------------------------------------------------

* File name: Program.cs

* Project name: MP3 Tracker

*--------------------------------------------------------------------

* Author’s name and email: Jericho McGowan || mcgowanj2@etsu.edu

* Course-Section: 002

* Creation Date: 2/6/2023

* -------------------------------------------------------------------

*/
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace MP3_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Variables

            string? title = string.Empty;
            string? artist = string.Empty;
            string? releaseDate = string.Empty;
            double playbackTime = 0;
            Genre genreEnum = Genre.None; //Added a none attribute to the enum because making every Genre field nullable inside MP3 was causing problems
            decimal dlCost = 0;
            double sizeInMB = 0;
            string? pathToIMG = string.Empty;
            
            Playlist playlist = null;
            string plName = "";
            string plCreator = "";
            bool validInput = false;
            bool validInputM = false;
            List<MP3> mp3List = null;
            int input = 0;
            bool valid = false;
            bool found = false;
            

            string dateCreated = "";
        
            #endregion




            while (validInputM == false)
            {

                //Problem with sorting by date. Try .OrderBy( x => DateTiem.Parse. Also problem with the Edit method
                #region Menu
                if (valid == false)
                {
                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");
                }

                #endregion


                #region Playlist Creation
                if (input == 1)
                {
                    validInput = false;
                    while (validInput == false)
                    {
                        Console.WriteLine("--------------------------------------------------\n");
                        Console.WriteLine("--------------------------------------------------\n");
                        Console.Write("What is the playlist name? ");
                        try
                        {
                            plName = Console.ReadLine();
                            while (validInput == false)
                            {
                                
                                Console.Write("What is the playlist creators name? ");
                                try
                                {
                                    plCreator = Console.ReadLine();
                                    dateCreated = DateTime.Today.ToString("d");
                                    validInput = true;

                                    

                                }
                                catch
                                {
                                    Console.WriteLine("Invalid creator name try again.");
                                };
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid name try again...");
                        }
                        Console.WriteLine($"Playlist created on: {dateCreated}");
                         mp3List = new List<MP3>(); 
                        playlist = new Playlist(mp3List, plName, plCreator, dateCreated); //Input validated everything going into this initialization so I figured a try was not needed.

                        Console.WriteLine("-----------------Playlist Created-----------------\n");
                        Console.WriteLine("--------------------------------------------------\n");


                    }


                    #region Menu
                    Console.WriteLine("--------------------------------------------------\n");
                
                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");

                    #endregion

                }
                #endregion


                #region Song Creation WIP
                if (input == 2)
                {
                    Console.WriteLine("--------------------------------------------------\n");
                    Console.WriteLine("--------------------------------------------------\n");
                    validInput = false;
                    while (validInput == false)
                    {
                        //Gathering User Info
                        try //Try for almost all strings because less can go wrong
                        {
                            Console.Write("Please enter the song's title: ");
                            title = Console.ReadLine();
                            Console.Write("Please enter the song's artist: ");
                            artist = Console.ReadLine();
                            validInput = false;//Try Catch for Release date
                            while (validInput == false)
                            {
                                Console.Write("Please enter the songs release date in MM/dd/yyyy format:  ");
                               
                                DateTime dateDT;
                                try
                                {
                                    releaseDate = Console.ReadLine();
                                    dateDT = DateTime.ParseExact(releaseDate, "MM/dd/yyyy", null);
                                        releaseDate = $"{dateDT.ToString("MM/dd/yyyy")}";
                                        validInput = true;
                                        
                                }
                                catch
                                {
                                    releaseDate = "";
                                    Console.WriteLine("Invalid date try again.");
                                }
                         
                            }
                            validInput = false;//Try/Catch for Playback Time
                            while (validInput == false) 
                            {
                                try //Try for playback time
                                {

                                    Console.Write("Please enter the playback time (minutes): ");
                                    playbackTime = Convert.ToDouble(Console.ReadLine());
                                    validInput = true;



                                }
                                catch
                                {
                                    Console.WriteLine("Invalid input, please enter a valid number in minutes.\n");
                                }


                            }

                            validInput = false;//Try/Catch for Genre
                            while (validInput == false) 
                            {
                                try //Try for Genre
                                {
                                    Console.Write("Please enter the song's genre (Rock, Pop, Jazz, Country, Classical, Other): ");

                                    //Parse/Convert for string to enum(Genre)
                                    genreEnum = (Genre)Enum.Parse(typeof(Genre), (Console.ReadLine()));
                                    validInput = true;

                                }
                                catch(ArgumentException e) //Assuming that the genre they inputted is not a genre in the Enum, so set it to Other. I was unsure if I am supposed to let an exception be handled, and force a valid input, or if I am to take action.
                                {
                                    genreEnum = Genre.Other;
                                    validInput = true;
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine("Invalid genre. Must be any of the following: Rock, Pop, Jazz, Country, Classical, Other. Try again. \n");
                                }

                            }

                            validInput = false;//Try/Catch for download price
                            while (validInput == false) 
                            {
                                try //Try for price to download
                                {
                                    Console.Write("Please enter the cost/price to download: $");
                                    dlCost = decimal.Parse(Console.ReadLine());
                                    validInput = true;
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid price. Please enter a dollar amount. \n");

                                }
                            }

                            validInput = false; //Try/Catch for download size
                            while (validInput == false) 
                            {

                                try//Try for Download Size
                                {
                                    Console.Write("Please enter the size of the file (MB): ");
                                    sizeInMB = double.Parse(Console.ReadLine());
                                    validInput = true;

                                }

                                catch
                                {
                                    Console.WriteLine("Invalid file size, please enter a valid size in MB. \n");
                                }
                            }

                            validInput = false;//Try/Catch for file path
                            while (validInput == false) 
                            {
                                try// Try for file path
                                {


                                    Console.Write("Please enter the path of the album cover photo: ");
                                    pathToIMG = Console.ReadLine();
                                    validInput = true;
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid file path. Try again. \n");
                                }
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Invalid input, try again. \n");
                        }
                        MP3 temp = new MP3(title, artist, releaseDate, playbackTime, genreEnum, dlCost, sizeInMB, pathToIMG);
                        try
                        {
                            mp3List.Add(temp);
                            Console.WriteLine("-----------------Song Added-----------------\n");
                            Console.WriteLine("--------------------------------------------------\n");
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine("A playlist was not made. Please create one then try again.");
                        }
                        catch
                        {
                            Console.WriteLine("Error occurred.");
                        }


                        #region Menu
                        Console.WriteLine("--------------------------------------------------\n");

                        Console.WriteLine(
                        "\n1. Create a new playlist" +
                        "\n2. Create a new MP3 for the playlist" +
                        "\n3. Edit an existing MP3 from the playlist" +
                        "\n4. Drop an MP3 from the playlist" +
                        "\n5. Display all MP3's in the playlist" +
                        "\n6. Find and display an MP3 by song title" +
                        "\n7. Display all MP3s on the tracker of a given genre" +
                        "\n8. Display all MP3's on the tracker with a given artist" +
                        "\n9. Sort the MP3s by song title" +
                        "\n10. Sort the MP3s by song release date" +
                        "\n11. Exit the Program");
                        Console.Write("\nWhat would you like to do? ");
                        valid = false;
                        while (valid == false)
                        {
                            try
                            {

                                input = Convert.ToInt32(Console.ReadLine());
                                if (input > 0 && input < 12)
                                {
                                    valid = true;
                                }
                                else
                                {
                                    Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                                Console.Write("What would you like to do? ");
                            }
                            catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                        }
                        Console.WriteLine("--------------------------------------------------\n");

                        #endregion
                    }


                }

                #endregion


                #region Edit MP3 WIP
                else if (input == 3)
                {
                    int edit = 0;
                    validInput = false;
                    while (validInput == false)
                    {

                        Console.WriteLine("What MP3 position would you like to edit (Starting at #1)? ");
                        try
                        {
                            edit = Convert.ToInt32(Console.ReadLine()) - 1;
                            validInput = true;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input try again");
                        }
                    }
                    try
                    {
                        playlist.Edit(playlist.GetMP3List()[edit]); //Added a method to the playlist class to do this 
                    }
                    catch
                    {
                        Console.WriteLine("MP3 does not exist. Going back to menu...");
                    }
                    #region Menu
                    Console.WriteLine("--------------------------------------------------\n");

                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");

                    #endregion
                }
                #endregion //Look at the menu loops


                #region Remove MP3
                else if (input == 4)
                {
                    validInput = false;
                    while (validInput == false)
                    {
                        int removeI = 0;
                        Console.WriteLine("What MP3 at what position would you like to remove (Starting at #1). ");
                        try
                        {
                            removeI = Convert.ToInt32(Console.ReadLine()) - 1;
                            validInput = true;
                            try
                            {
                                playlist.Remove(playlist.GetMP3List()[removeI]);
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine("A playlist was not made. Please try again");
                            }
                            catch
                            {
                                Console.WriteLine("Error occurred. Try again");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input try again");
                        }

                    }
                    #region Menu
                    Console.WriteLine("--------------------------------------------------\n");

                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");

                    #endregion
                }
                #endregion


                #region Display MP3
                else if (input == 5)
                {
                    try
                    {
                        Console.WriteLine(playlist.ToString());
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("A playlist was not made. Please try again");
                    }
                    catch
                    {
                        Console.WriteLine("Error occurred. Try again");
                    }
                    #region Menu
                    Console.WriteLine("--------------------------------------------------\n");

                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");

                    #endregion
                }
                #endregion


                #region Display MP3 by song title
                else if (input == 6)
                {
                    Console.WriteLine("What song would you like to find (Use song name)? ");
                    string searchKey = string.Empty;
                    searchKey = Console.ReadLine();
                    validInput = false;
                    while (validInput == false)
                    {
                       
                        try
                        {
                            Console.WriteLine(playlist.GetMP3List()[playlist.SearchByTitle(searchKey)]);
                            validInput = true;
                        }
                        catch
                        {
                            validInput = true;
                            Console.WriteLine("Song not found in your playlist. Returning to Menu...\n");
                        }
                    }
    
                    #region Menu
                    Console.WriteLine("--------------------------------------------------\n");

                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");

                    #endregion
                }
                #endregion


                #region Display all MP3's on tracker of a given Genre
                else if (input == 7)
                {
                    found = false;
                    validInput = false;
                    Genre searchGenre = Genre.None; //Used none because setting to nullable caused too many issues
                    Console.WriteLine("What genre would you like to display all music for(Rock, Pop, Jazz, Country, Classical, Other)? ");
                    
                        try
                        {
                            searchGenre = (Genre)Enum.Parse(typeof(Genre), (Console.ReadLine()));
                           

                        }
                        catch //Sets genre to other automatically because every genre not in the enum is another  genre.
                        {
                            searchGenre = Genre.Other;
                        }
                    try
                    {
                        for (int i = 0; i < mp3List.Count; i++)
                        {
                            if (playlist.GetMP3List()[i].GetGenre() == searchGenre)
                            {
                                Console.WriteLine(playlist.GetMP3List()[i].ToString());
                                found = true;
                            }
                            
                        }
                        if(found == false)
                        {
                            Console.WriteLine("No songs with the specified genre exist.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Song with genre not found.");
                    }
                    #region Menu
                    Console.WriteLine("--------------------------------------------------\n");

                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");

                    #endregion
                }
                #endregion


                #region Display all MP3's on tracker of a given Artist
                else if (input == 8)
                {
                    string searchArtist = string.Empty;
                    Console.WriteLine("What artist would you like to display songs for?");
                    searchArtist = Console.ReadLine(); //No validation because it is a string, it accepts most things
                    try
                    {
                        found = false;
                        for (int i = 0; i < mp3List.Count; i++)
                        {
                            if (playlist.GetMP3List()[i].GetSongArtist() == searchArtist)
                            {
                                Console.WriteLine(playlist.GetMP3List()[i].ToString());
                                found = true;
                            }

                           
                        }
                        if(found == false)
                        {
                            Console.WriteLine("No song with that artist name was found.");
                        }
                
                        
                    }
                    catch
                    {
                        Console.WriteLine("An error occurred.");
                    }


                    #region Menu
                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }

                    #endregion
                }
                #endregion


                #region Sort the MP3's by song title
                else if (input == 9)
                {
                    try
                    {
                        playlist.SortByTitle();
                        Console.WriteLine("Playlist Sorted by Title");
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("A playlist was not made to sort.");
                    }
                    catch
                    {
                        Console.WriteLine("Error occurred. Try again");
                    }
                    #region Menu
                    Console.WriteLine("--------------------------------------------------\n");

                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");

                    #endregion
                }
                #endregion


                #region Sort the MP3's by song release date
                else if (input == 10)
                {
                    try
                    {
                        playlist.SortingByDate();
                        Console.WriteLine("Playlist Was Sorted by Release Date");
                    }
                    catch (NullReferenceException e)
                    {
                        Console.WriteLine("A playlist was not made to sort.");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Error occurred. Try again");
                    }
                    #region Menu
                    Console.WriteLine("--------------------------------------------------\n");

                    Console.WriteLine(
                    "\n1. Create a new playlist" +
                    "\n2. Create a new MP3 for the playlist" +
                    "\n3. Edit an existing MP3 from the playlist" +
                    "\n4. Drop an MP3 from the playlist" +
                    "\n5. Display all MP3's in the playlist" +
                    "\n6. Find and display an MP3 by song title" +
                    "\n7. Display all MP3s on the tracker of a given genre" +
                    "\n8. Display all MP3's on the tracker with a given artist" +
                    "\n9. Sort the MP3s by song title" +
                    "\n10. Sort the MP3s by song release date" +
                    "\n11. Exit the Program");
                    Console.Write("\nWhat would you like to do? ");
                    valid = false;
                    while (valid == false)
                    {
                        try
                        {

                            input = Convert.ToInt32(Console.ReadLine());
                            if (input > 0 && input < 12)
                            {
                                valid = true;
                            }
                            else
                            {
                                Console.WriteLine("Input is not a menu option, please input an integer between 1-11 (inclusive).\n");
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Not an accepted format. Please input a valid integer. \n ");
                            Console.Write("What would you like to do? ");
                        }
                        catch (Exception e) { Console.WriteLine("Invalid input format, please try again."); }
                    }
                    Console.WriteLine("--------------------------------------------------\n");

                    #endregion
                }
                #endregion


                #region Exit Program
                else
                {
                    validInputM = true;
                }
                #endregion


            }

        }

    }

}









