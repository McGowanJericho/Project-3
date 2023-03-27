/**

*--------------------------------------------------------------------

* File name: MP3.cs

* Project name: Project 1

*--------------------------------------------------------------------

* Author’s name and email: Jericho McGowan || mcgowanj2@etsu.edu

* Course-Section: 002

* Creation Date: 2/6/2023

* -------------------------------------------------------------------

*/
using MP3_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MP3_Tracker
{
    internal class MP3
    {
        //Fields
        #region Fields
        private string songTitle;
        private string songArtist;
        private string songRelease; //Song Release date
        private double playback; // playback time in minutes
        private Genre genre;
        private decimal dlCost;        //Download Cost
        private double sizeInMB; // File size in MB
        private string pathToPhoto; //Path of a jpg file
        #endregion

        //Constructors
        #region Constructors
        public MP3()
        {
            songTitle = "N/A";
            songArtist = "N/A";
            songRelease = "N/A";
            playback = 1.0;
            genre = new Genre();
            dlCost = 1;
            sizeInMB = 1.0;
            pathToPhoto = "N/A";
        }
        public MP3(string songTitle, string songArtist, string songRelease, double playback, Genre genre, decimal dlCost, double sizeInMB, string pathToPhoto)
        {
            this.songTitle = songTitle;
            this.songArtist = songArtist;
            this.songRelease = songRelease;
            this.playback = playback;
            this.genre = genre;
            this.dlCost = dlCost;
            this.sizeInMB = sizeInMB;
            this.pathToPhoto = pathToPhoto;
        }
        public MP3(MP3 other)
        {
            SetSongTitle(other.songTitle);
            SetSongArtist(other.songArtist);
            SetSongRelease(other.songRelease);
            SetPlayback(other.playback);
            SetGenre(other.genre);
            SetDLCost(other.dlCost);
            SetSizeInMB(other.sizeInMB);
            SetPath(other.pathToPhoto);
        }
        #endregion

        //Getter/Setter
        #region Getter/Setters


        #region Set/Get of SongTitle
        public string GetSongTitle()
        {
            return songTitle;
        }
        public void SetSongTitle(string songTitle)
        {
            this.songTitle = songTitle;
        }
        #endregion

        #region Set/Get of SongArtist
        public string GetSongArtist()
        {
            return songArtist;
        }
        public void SetSongArtist(string songArtist)
        {
            this.songArtist = songArtist;
        }
        #endregion

        #region Set/Get of SongRelease
        public string GetSongRelease()
        {
            return songRelease;
        }
        public void SetSongRelease(string songRelease)
        {
            this.songRelease = songRelease;
        }
        #endregion

        #region Set/Get of Playback
        public double GetPlayback()
        {
            return playback;
        }
        public void SetPlayback(double playback)
        {
            this.playback = playback;
        }
        #endregion

        #region Set/Get of Genre
        public Genre GetGenre()
        {
            return genre;
        }
        public void SetGenre(Genre genre)
        {
            this.genre = genre;
        }
        #endregion

        #region Set/Get of DLCost
        public decimal GetDLCost()
        {
            return dlCost;
        }
        public void SetDLCost(decimal dlCost)
        {
            this.dlCost = dlCost;
        }
        #endregion

        #region Set/Get of SizeInMB
        public double GetSizeInMB()
        {
            return sizeInMB;
        }
        public void SetSizeInMB(double value)
        {
            sizeInMB = value;
        }
        #endregion

        #region Set/Get of Path
        public string GetPath()
        {
            return pathToPhoto;
        }
        public void SetPath(string pathToPhoto)
        {
            this.pathToPhoto = pathToPhoto;
        }
        #endregion


        #endregion

        //ToString
        #region ToString

        public override string ToString()
        {
            return 
                $"\tTitle: {songTitle}\n\tArtist: {songArtist}\n\tSong Release Date: {songRelease}\n\tPlayback time in Minutes: " +
                $"{playback} minutes\n\tGenre: {genre}\n\tDownload Cost: {dlCost}\n\tFile Size in MB: {sizeInMB}MB\n\tAlbum Photo: {pathToPhoto}" +
                "\n------------------------------------------------------------\n\n";
        }


        #endregion
    }

}
