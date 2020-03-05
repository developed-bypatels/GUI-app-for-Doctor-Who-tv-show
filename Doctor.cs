using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// I Prerak Patel (000736376) certify that I have done this work without anyone's help and I have not made my work available to any one else.
namespace Lab5B
{
    class Doctor
    {
        /// <summary>
        /// Stores doctor number
        /// </summary>
        private int ORDINAL;
        /// <summary>
        /// Stores actor name
        /// </summary>
        private string ACTOR;
        /// <summary>
        /// stores series number
        /// </summary>
        private int SERIES;
        /// <summary>
        /// stores age of the actor when he started
        /// </summary>
        private int AGE;
        /// <summary>
        /// stores actor's debut episode 
        /// </summary>
        private string DEBUT;

        /// <summary>
        /// Constructor for Doctor class
        /// </summary>
        /// <param name="ordinal">integer for ordinal</param>
        /// <param name="actor">string for actor name</param>
        /// <param name="series">integer for series number</param>
        /// <param name="age">integer for actor's age</param>
        /// <param name="debut">string for actor's debut film</param>
        public Doctor(int ordinal, string actor, int series, int age, string debut)
        {
            ORDINAL = ordinal;
            ACTOR = actor;
            SERIES = series;
            AGE = age;
            DEBUT = debut;
        }

        /// <summary>
        /// returns doctor number (ordinal)
        /// </summary>
        public int getOrdinal()
        {
            return ORDINAL;
        }
        /// <summary>
        /// returns actor name
        /// </summary>
        public string getActor()
        {
            return ACTOR;
        }
        /// <summary>
        /// returns series number of episode
        /// </summary>
        public int getSeries()
        {
            return SERIES;
        }
        /// <summary>
        /// retunrns age of the actor when he started
        /// </summary>
        public int getAge()
        {
            return AGE;
        }
        /// <summary>
        /// returns debut episode of the actor
        /// </summary>
        public string getDebut()
        {
            return DEBUT;
        }
    }
}
