using System;
using System.Text;

namespace Book
{
    class Movie : Media
    {
        // Variables declared
        private String directorName;
        private String encrptedSummary;
        private StringBuilder decryptedSummary = new StringBuilder();
        private String summary;

        // Constructor for Movie Class with argument - Title and Year
        public Movie(string title, int year) : base(title, year)
        {
            Title = title;
            Year = year;
        }

        // Director method to intialize directorName
        public String Director(String director)
        {
            directorName = director;
            return directorName;
        }

        // Sets the encryptedSummary with summary accpeted as argument
        public void SetSummary(String summary)
        {
            encrptedSummary = summary;
            this.summary = Decrypt();
        }

        // Returns Summary when called with the object
        public override String GetSummary()
        {
            return summary;
        }

        // ToString Method is overriden to return customized string
        public override string ToString()
        {
            return $"Movie Title : {Title} ({Year}) \nDirector: {directorName}\n";
        }

        // Encrypt Method to encrpt String with rot - 13 cipher
        public string Encrypt()
        {
            // encrptedSmmary converted to character Array
            encrptedSummary.ToCharArray();

            // Loops through character array
            for (int i = 0; i < encrptedSummary.Length; i++)
            {
                // Condition check for all capital Letters
                if (encrptedSummary[i] >= 'A' && encrptedSummary[i] <= 'Z')
                {
                    // Letter is decrpted and is stored into the decrypted summary
                    decryptedSummary.Append((char)('A' + ((encrptedSummary[i] - 'A' + 13) % 26)));
                }

                // Condition check for all small Letters
                else if (encrptedSummary[i] >= 'a' && encrptedSummary[i] <= 'z')
                {
                    // Letter is decrypted and is stored into the decrypted summary
                    decryptedSummary.Append((char)('a' + ((encrptedSummary[i] - 'a' + 13) % 26)));
                }

                // Condition run if all the above conditions returns false
                else
                {
                    // Letter is stored as it is to the decrypted summary
                    decryptedSummary.Append(encrptedSummary[i]);
                }
            }
            // returns decrypted summary
            return decryptedSummary.ToString();
        }

        // Decrypt Method to decrypt String encrypted by rot - 13 cipher
        public string Decrypt()
        {
            // Encryption and Decryption for string is same for rot - 13 cipher
            return Encrypt();
        }
    }
}
