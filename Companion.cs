using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// I Prerak Patel (000736376) certify that I have done this work without anyone's help and I have not made my work available to any one else.
namespace Lab5B
{
    class Companion
    {
        /// <summary>
        /// Stores comapanion name
        /// </summary>
        private string NAME;
        /// <summary>
        /// Stores actor name
        /// </summary>
        private string ACTOR;
        /// <summary>
        /// Stores doctor number
        /// </summary>
        private int DOCTOR;
        /// <summary>
        /// stores companion debut episode
        /// </summary>
        private string DEBUT;

        /// <summary>
        /// Constructor for Companion class
        /// </summary>
        /// <param name="name">string for companion name</param>
        /// <param name="actor">string for actor name</param>
        /// <param name="doctor">integer for doctor number</param>
        /// <param name="debut">string for companion debut episode</param>
        public Companion(string name, string actor, int doctor, string debut)
        {
            NAME = name;
            ACTOR = actor;
            DOCTOR = doctor;
            DEBUT = debut;
        }

        /// <summary>
        /// returns companion name
        /// </summary>
        public string getName()
        {
            return NAME;
        }
        /// <summary>
        /// returns actor name
        /// </summary>
        public string getActor()
        {
            return ACTOR;
        }
        /// <summary>
        /// returns doctor number
        /// </summary>
        public int getDoctor()
        {
            return DOCTOR;
        }
        /// <summary>
        /// returns companion debut episode
        /// </summary>
        public string getDebut()
        {
            return DEBUT;
        }
    }
}
