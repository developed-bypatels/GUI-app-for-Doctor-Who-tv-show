using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// I Prerak Patel (000736376) certify that I have done this work without anyone's help and I have not made my work available to any one else.
namespace Lab5B
{
    class Episode
    {
        /// <summary>
        /// Stores story name
        /// </summary>
        private string STORY;
        /// <summary>
        /// Stores season number
        /// </summary>
        private int SEASON;
        /// <summary>
        /// Stores year number
        /// </summary>
        private int YEAR;
        /// <summary>
        /// Stores episode title 
        /// </summary>
        private string TITLE;

        /// <summary>
        /// Constructor for Episode class
        /// </summary>
        /// <param name="story">string for story name</param>
        /// <param name="season">integer for season number</param>
        /// <param name="year">integer for year</param>
        /// <param name="title">string for episode title</param>
        public Episode(string story, int season, int year, string title)
        {
            STORY = story;
            SEASON = season;
            YEAR = year;
            TITLE = title;
        }
        /// <summary>
        /// returns story name
        /// </summary>
        public string getStory()
        {
            return STORY;
        }
        /// <summary>
        /// returns season number
        /// </summary>
        public int getSeason()
        {
            return SEASON;
        }
        /// <summary>
        /// returns year number
        /// </summary>
        public int getYear()
        {
            return YEAR;
        }
        /// <summary>
        /// returns episode title
        /// </summary>
        public string getTitle()
        {
            return TITLE;
        }
    }
}
