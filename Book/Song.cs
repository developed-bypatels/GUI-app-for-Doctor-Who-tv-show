using System;
namespace Book
{
    class Song : Media
    {
        // Variables declared
        private String albumName;
        private String artistName;

        // Constructor for Song Class with argument - Title and Year
        public Song(string title, int year) : base(title, year)
        {
            Title = title;
            Year = year;
        }

        // Album method to intialize albumName
        public String Album(String album)
        {
            albumName = album;
            return albumName;
        }

        // Artist method to intialize artistName
        public String Artist(String artist)
        {
            artistName = artist;
            return artistName;
        }

        // This method is never called and so it is not intialized
        public override string GetSummary()
        {
            throw new NotImplementedException();
        }

        // ToString Method is overriden to return customized string
        public override string ToString()
        {
            return $"Song Title : {Title} ({Year}) \nAlbum: {albumName}  Artist: {artistName}\n";
        }
    }
}
