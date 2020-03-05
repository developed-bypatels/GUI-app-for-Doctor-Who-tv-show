using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// I Prerak Patel (000736376) certify that I have done this work without anyone's help and I have not made my work available to any one else.
namespace Lab5B
{
    public partial class Form1 : Form
    {
        /* Handling the shorcut key pressed from the keyboard WITH ANOTHER LOGIC */
        /// <summary>
        /// Variable that checks whether Ctrl button is pressed or not
        /// </summary>
        private bool isCtrlDown;

        /// <summary>
        /// Variable that checks whether Q button is pressed or not
        /// </summary>
        private bool isQDown;

        /// <summary>
        /// Variable that checks whether O button is pressed or not
        /// </summary>
        private bool isODown;

        /// <summary>
        /// Variable that checks whether the data from the fule is retrived or not
        /// </summary>
        private bool dataLoaded;

        /// <summary>
        /// List to store all Doctor class objects
        /// </summary>
        private List<Doctor> doctorsList;

        /// <summary>
        /// List to store all Companion class objects
        /// </summary>
        private List<Companion> companionsList;

        /// <summary>
        /// List to store all Episode class objects
        /// </summary>
        private List<Episode> episodesList;

        Stream stream = null;                   // Stream is called to get of sequence bytes

        /// <summary>
        /// First Initialization of Form
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Gets the image from the directory to print it to pictureBox
            pictureBox1.Image = Image.FromFile("../image.png");

            // Object to handle the key pressed events
            this.KeyDown += new KeyEventHandler(keysDown);

            // Object for event handling
            this.comboBox1.SelectedIndexChanged += new EventHandler(changeDetails);

            // delaring the KeyPreview to true fro accepting the key events 
            this.KeyPreview = true;

            // Declaring all key pressed variables to false on form load
            // to set all the events to to false
            isCtrlDown = isQDown = isODown = dataLoaded = false;

            doctorsList = new List<Doctor>();
            companionsList = new List<Companion>();
            episodesList = new List<Episode>();
        }

        /// <summary>
        /// Method that handle the key pressed
        /// </summary>
        private void keysDown(object sender, KeyEventArgs e)
        {
            // Condition returns true if "Ctrl" is pressed on keyboard
            // logic says among all Modifier Keys if the "Ctrl" is pressed then return true
            if (ModifierKeys.HasFlag(Keys.Control))
                isCtrlDown = true;

            // Condition returns true if "Q" is pressed on keyboard
            // logic says if the among the all the keys on the keyboard if the "Q" is pressed then return true
            if (e.KeyCode == Keys.Q)
                isQDown = true;

            // Condition returns true if "O" is pressed on keyboard
            // logic says if the among the all the keys on the keyboard if the "O" is pressed then return true
            if (e.KeyCode == Keys.O)
                isODown = true;

            // Condition returns true if the "Ctrl" and "O" is pressed at 
            if (isCtrlDown && isODown)
            {
                /// <summary>
                /// File name of the opened file
                /// </summary>
                string fileName = "";

                // Object  for openDialog class
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // setting the title to openfileDialogBox
                openFileDialog.Title = "Open Doctor Who Data File";

                // Filtering the file that the program can accept
                openFileDialog.Filter = "txt files|*txt";

                // condtition returns true if the user presses "OK" on the File Dialog Box
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // retreiving filename of the file
                    fileName = openFileDialog.FileName;
                    extractData(fileName);
                }
            }

            // Condition returns true if the user presses "Ctrl" and "Q" at the same time
            if (isCtrlDown && isQDown)

                // closes the program
                Application.Exit();

            // setting all the variable to false for further use
            isCtrlDown = isQDown = isODown = false;
        }

        /// <summary>
        /// Method for "Open" Tool strip item clicked
        /// </summary>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// File name of the opened file
            /// </summary>
            string fileName = "";

            // Object  for openDialog class
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // setting the title to openfileDialogBox
            openFileDialog.Title = "Open Doctor Who Data File";

            // Filtering the file that the program can accept
            openFileDialog.Filter = "txt files|*txt";

            // condtition returns true if the user presses "OK" on the File Dialog Box
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // condition returns true if the file opened is not empty
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        // stream that has whole the data of file
                        using (stream)
                        {
                            // retrieves file name
                            fileName = openFileDialog.FileName;

                            // invokes the extractData with fileName as parameter to read file
                            extractData(fileName);
                        }
                    }
                }
                catch
                {
                    // User-frienly Message box displaying that there was error opening file
                    MessageBox.Show("Error finding file/opening file");
                }

            }
        }

        /// <summary>
        /// Method for "Exit" Tool strip item clicked
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Closing program
            Application.Exit();
        }

        /// <summary>
        /// Method for event handling which loads the data to program
        /// </summary>
        private void changeDetails(object sender, EventArgs e)
        {
            // Condition returns true if the data is loaded in to the program
            if (dataLoaded)
            {
                // listbox is cleared for storing values as per the doctor
                listBox1.Items.Clear();

                /// <summary>
                /// Object for Doctor class
                /// </summary> 
                Doctor doc = null;

                // Looping through doctorList to retrieve all the objects of the Doctor class objects
                for (int i = 0; i < doctorsList.Count; i++)

                    // Condition for checking which doctor is selected in the comboBox
                    if (doctorsList.ElementAt(i).getOrdinal() == comboBox1.SelectedIndex + 1)
                    {
                        // getting the object instance at the selected index in the comboBox
                        doc = doctorsList.ElementAt(i);
                        break;
                    }

                // diplaying the Actor's name in the "Played By" label
                textBox2.Text = doc.getActor();

                // displaying the series in "Series" label
                textBox3.Text = doc.getSeries() + "";

                // displaying age in "Age of Start" Label
                textBox4.Text = doc.getAge() + "";

                /// <summary>
                /// List for storing all objects of Companion Class for the Doctor instance
                /// </summary> 
                List<Companion> companionsResultList = new List<Companion>();

                /// <summary>
                /// List for storing all objects of Episode class for the Episode instance
                /// </summary>
                List<Episode> episodesResultList = new List<Episode>();

                // Making query to get Companion objects which has same Doctor instance
                IEnumerable<Companion> companionQuery =
                    from companion in companionsList where companion.getDoctor() == doc.getOrdinal() select companion;

                // Looping through companionQuery Enumerable object
                foreach (Companion companion in companionQuery)
                    // storing all the objects into List of companionResultList
                    companionsResultList.Add(companion);

                // Looping through list companionResultList to get all the episodes for companion instance
                for (int i = 0; i < companionsResultList.Count; i++)
                {
                    // Making query to get episode objects where 
                    IEnumerable<Episode> episodeQuery =
                        from episode in episodesList where episode.getStory() == companionsResultList[i].getDebut() select episode;

                    // looping through the IEumerable query to get all the objects of the Episode class
                    foreach (Episode episode in episodeQuery)
                        episodesResultList.Add(episode);
                }

                // Looping through the episode list to sort each time the data is loaded into the listbox
                for (int i = 0; i < episodesResultList.Count - 1; i++)
                {
                    // storing the current value of "i" into some variable
                    int tempIndex = i;

                    // companion object is stored into variable
                    Companion tempCompanion = companionsResultList.ElementAt(i);

                    // episode object is stored into variable
                    Episode tempEpisode = episodesResultList.ElementAt(i);

                    // taking flag to compare the values
                    bool flag = false;
                    for (int j = i + 1; j < episodesResultList.Count; j++)
                    {
                        // sorting the fields by year condition returns true if oneis less than antother
                        if (episodesResultList.ElementAt(j).getYear() < tempEpisode.getYear())
                        {
                            // storing the current index of "j"
                            tempIndex = j;
                            // changing the tempEpisode variable and passing new index value into it
                            tempEpisode = episodesResultList.ElementAt(j);
                            // changning the tempCompanion variable and passing new index value into it
                            tempCompanion = companionsResultList.ElementAt(j);
                            // flag is turn to true as it was succesful in sorting
                            flag = true;
                        }

                        // while sorting if the value of both the episode year is same
                        else if (episodesResultList.ElementAt(j).getYear() == tempEpisode.getYear())
                        {
                            // in this case name of the values are compared to sort
                            if (companionsResultList.ElementAt(j).getName().CompareTo(tempCompanion.getName()) == -1)
                            {
                                // storing the current index of "j"
                                tempIndex = j;
                                // changing the tempEpisode variable and passing new index value into it
                                tempEpisode = episodesResultList.ElementAt(j);
                                // changning the tempCompanion variable and passing new index value into it
                                tempCompanion = companionsResultList.ElementAt(j);
                                // flag is turn to true as it was succesful in sorting
                                flag = true;
                            }
                        }
                    }
                    // if the flag value returns true in the result of succesfull sorting
                    if (flag)
                    {
                        // values in the episodeResultList is sorted in order to display sorted result
                        episodesResultList[tempIndex] = episodesResultList.ElementAt(i);
                        // values in the episodeResultList is sorted in order to display sorted result
                        episodesResultList[i] = tempEpisode;
                        // values in the companionResultList is sorted in order to display sorted result
                        companionsResultList[tempIndex] = companionsResultList.ElementAt(i);
                        // values in the companionResultList is sorted in order to display sorted result
                        companionsResultList[i] = tempCompanion;
                    }
                }

                // displaying the year for the debut by artist
                textBox1.Text = episodesResultList.ElementAt(0).getYear() + "";
                // displaying the title of the debut
                textBox5.Text = episodesResultList.ElementAt(0).getTitle();

                // looping thourgh companionResultList to diplsay the data from the sorted list to listbox
                for (int i = 0; i < companionsResultList.Count; i++)
                {
                    // First line will be the Companion name and Actor name
                    string result1 = companionsResultList.ElementAt(i).getName() + "("
                        + companionsResultList.ElementAt(i).getActor() + ")" + System.Environment.NewLine;

                    // Second line is declared
                    string result2 = "";

                    // condition returns true if the value of the "i" is less than episodeResult length
                    if (i < episodesResultList.Count)
                    {
                        // second line is set to Episode title and Episode year
                        result2 = "\"" + episodesResultList.ElementAt(i).getTitle() + "\"("
                            + episodesResultList.ElementAt(i).getYear() + ")";
                    }

                    // result is added to listobox in order to display the content
                    listBox1.Items.Add(result1);
                    listBox1.Items.Add(result2);
                    listBox1.Items.Add("");
                }
            }
        }

        /// <summary>
        /// Method for the extracting data
        /// </summary>
        ///<param name="fileName">name of file selected by the user</param>

        private void extractData(string fileName)
        {
            // To retrieve the line from the file and store it to some variable
            string line;

            // handling the file not found exception
            try
            {
                // StreamReader reads provided file instance
                StreamReader file =
                        new StreamReader(fileName);

                // adding values to combobox
                comboBox1.Items.Add("First");
                comboBox1.Items.Add("Second");
                comboBox1.Items.Add("Third");
                comboBox1.Items.Add("Fourth");
                comboBox1.Items.Add("Fifth");
                comboBox1.Items.Add("Sixth");
                comboBox1.Items.Add("Seventh");
                comboBox1.Items.Add("Eighth");
                comboBox1.Items.Add("Ninth");
                comboBox1.Items.Add("Tenth");
                comboBox1.Items.Add("Eleventh");
                comboBox1.Items.Add("Twelfth");
                // selecting one index by default
                comboBox1.SelectedIndex = 0;

                // looping through whole file inorder to read and load lists
                while ((line = file.ReadLine()) != null)
                {
                    // condition returns true if the line has the first element starting with "D" and 
                    // to only accept the "D" as character checking the second element after the "D"
                    // must be whitespace
                    if (line.ElementAt(0) == 'D' && Char.IsWhiteSpace(line.ElementAt(1)))
                    {
                        // declaring index variable and initializing it
                        int index = 1;

                        // in the same line if the line encounters with "|" and whitespace character after
                        // it then the condition returns true
                        while (line.ElementAt(index) == '|' || Char.IsWhiteSpace(line.ElementAt(index)))
                            // index value increased by 1 everytime the loop runs
                            index++;

                        // temp variable is declared to store whole line ignoring the "|"
                        string temp = "";

                        // condition returns true if the index value is not "|"
                        if (line.ElementAt(index + 1) != '|')
                        {
                            // storing all the values into the temp variable except "|"
                            temp += line.ElementAt(index) + "" + line.ElementAt(index + 1);
                            // and index value is increased by 3 for skiping empty spaces in the file
                            index += 3;
                        }
                        else
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index);
                            // and index value is increased by 2 for skiping empty spaces in the file
                            index += 2;
                        }
                        // int ordinal is the serial nummber of doctor
                        int ordinal = int.Parse(temp);
                        // string temp to null for stroing another data
                        temp = "";
                        // looping through indexed value of the line to get the seconed value in the row
                        while (!(Char.IsWhiteSpace(line.ElementAt(index)) && Char.IsWhiteSpace(line.ElementAt(index + 1)))
                            && !(Char.IsWhiteSpace(line.ElementAt(index)) && line.ElementAt(index + 1) == '|'))
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index);
                            // increasing the value of the index in each run
                            index++;
                        }

                        // actor variable for storing temp value returned above
                        string actor = temp;
                        // delaring the temp value to null
                        temp = "";

                        // looping through indexed value of line if the line found with "|" and whitespace character
                        while (line.ElementAt(index) == '|' || Char.IsWhiteSpace(line.ElementAt(index)))
                            // index value of the line increased by 1 in every run 
                            index++;
                        // condition returns true if the line element is not "|"
                        if (line.ElementAt(index + 1) != '|')
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index) + "" + line.ElementAt(index + 1);
                            // and index value is increased by 3 for skiping empty spaces in the file
                            index += 3;
                        }
                        else
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index);
                            // and index value is increased by 2 for skiping empty spaces in the file
                            index += 2;
                        }

                        // int series is the serial number of doctor
                        int series = int.Parse(temp);
                        // string temp to null for stroing another data
                        temp = "";

                        // looping through indexed value of line if the line found with "|" and whitespace character
                        while (line.ElementAt(index) == '|' || Char.IsWhiteSpace(line.ElementAt(index)))
                            // index value of the line increased by 1 in every run 
                            index++;

                        // condition returns true if the line element is not "|"
                        if (line.ElementAt(index + 1) != '|')
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index) + "" + line.ElementAt(index + 1);
                            // and index value is increased by 3 for skiping empty spaces in the file
                            index += 3;
                        }
                        else
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index);
                            // and index value is increased by 2 for skiping empty spaces in the file
                            index += 2;
                        }

                        // int age is the age of the artist
                        int age = int.Parse(temp);
                        // string temp to null for stroing another data
                        temp = "";

                        // looping through indexed value of line if the line found with "|"
                        while (line.ElementAt(index) != '|')
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index);
                            // index value of the line increased by 1 in every run 
                            index++;
                        }
                        // with all values Anonymous Doctor object is created with Doctor class and 
                        // added to doctorList
                        doctorsList.Add(new Doctor(ordinal, actor, series, age, temp));
                    }

                    // condition returns true if the line has the first element starting with "E" and 
                    // a whitespace character
                    else if (line.ElementAt(0) == 'E' && Char.IsWhiteSpace(line.ElementAt(1)))
                    {
                        // declaring index variable and initializing it
                        int index = 1;
                        // looping through indexed value of line if the line found with "|"
                        while (line.ElementAt(index) != '|')
                            // index value of the line increased by 1 in every run 
                            index++;
                        // index value of the line increased by 1 in every run 
                        index++;

                        // temp variable is declared to store whole line ignoring the "|"
                        string temp = "";

                        // looping through data till the whitespace charcter is found
                        while (!Char.IsWhiteSpace(line.ElementAt(index)))
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index);
                            // increasing the value of the index in each run
                            index++;
                        }
                        // story variable for storing temp value returned above
                        string story = temp;
                        // delaring the temp value to null
                        temp = "";

                        // looping through indexed value of line if the line found with "|" and whitespace character
                        while (line.ElementAt(index) == '|' || Char.IsWhiteSpace(line.ElementAt(index)))
                            // index value of the line increased by 1 in every run 
                            index++;
                        // if whitespace charcter is not found then this condition returns true
                        if (!Char.IsWhiteSpace(line.ElementAt(index + 1)))
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index) + "" + line.ElementAt(index + 1);
                            // and index value is increased by 2 for skiping empty spaces in the file
                            index += 2;
                        }
                        else
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index);
                            // increasing the value of the index in each run
                            index++;
                        }

                        // int season is the episode season number
                        int season = int.Parse(temp);
                        // string temp to null for stroing another data
                        temp = "";

                        // looping through indexed value of line if the line found with "|" and whitespace shaarcter
                        while (line.ElementAt(index) == '|' || Char.IsWhiteSpace(line.ElementAt(index)))
                            // index value of the line increased by 1 in every run 
                            index++;
                        // storing all the values into the temp variable
                        temp += line.ElementAt(index) + "" + line.ElementAt(index + 1) + "" + line.ElementAt(index + 2) + "" + line.ElementAt(index + 3);
                        // int year is the year in which the episode was released
                        int year = int.Parse(temp);
                        // string temp to null for stroing another data
                        temp = "";
                        // and index value is increased by 5 for skiping empty spaces in the file
                        index += 5;

                        // looping till the end of the line
                        while (index < line.Length)
                        {
                            // storing all the values into the temp variable
                            temp += line.ElementAt(index);
                            // increasing the value of the index in each run
                            index++;
                        }
                        // all the information from the file is stored into the Episode objects and
                        // stored into list for further use
                        episodesList.Add(new Episode(story, season, year, temp));
                    }

                    // condition returns true if the line has the first element starting with "C" and 
                    // a whitespace character
                    else if (line.ElementAt(0) == 'C' && Char.IsWhiteSpace(line.ElementAt(1)))
                    {

                        // declaring index variable and initializing it
                        int index = 1;
                        // looping through indexed value of line if the line found with "|"
                        while (line.ElementAt(index) != '|')
                            // index value increased by 1 everytime the loop runs
                            index++;
                        // increasing the value of the index in each run
                        index++;
                        string temp = "";
                        // if the line encounters with some non-white space character and whitespacecharacter 
                        // and follwing that non-white space character and "|" at the same time then the
                        // condtition returns true
                        while (!(Char.IsWhiteSpace(line.ElementAt(index)) && Char.IsWhiteSpace(line.ElementAt(index + 1)))
                            && !(Char.IsWhiteSpace(line.ElementAt(index)) && line.ElementAt(index + 1) == '|'))
                        {

                            // storing all the values into the temp variable except "|"
                            temp += line.ElementAt(index);
                            // index value increased by 1 everytime the loop runs
                            index++;
                        }
                        // name variable for storing temp value from returnred above
                        string name = temp;
                        // delaring the temp value to null
                        temp = "";
                        // in the same line if the line encounters with "|" and whitespace character after
                        // it then the condition returns true
                        while (line.ElementAt(index) == '|' || Char.IsWhiteSpace(line.ElementAt(index)))
                            // index value increased by 1 everytime the loop runs
                            index++;
                        // if the line encounters non-whitespace character and white space character at the same time
                        // then the condition returns true
                        while (!(Char.IsWhiteSpace(line.ElementAt(index)) && Char.IsWhiteSpace(line.ElementAt(index + 1))))
                        {
                            // storing all the values into the temp variable except "|"
                            temp += line.ElementAt(index);
                            // index value increased by 1 everytime the loop runs
                            index++;
                        }
                        // actor variable for storing temp value returned above 
                        string actor = temp;
                        // delaring the temp value to null
                        temp = "";
                        // in the same line if the line encounters with "|" and whitespace character after
                        // it then the condition returns true
                        while (line.ElementAt(index) == '|' || Char.IsWhiteSpace(line.ElementAt(index)))
                            // index value increased by 1 everytime the loop runs
                            index++;
                        if (!Char.IsWhiteSpace(line.ElementAt(index + 1)))
                        {
                            // storing all the values into the temp variable except "|"
                            temp += line.ElementAt(index) + "" + line.ElementAt(index + 1);
                            // and index value is increased by 2 for skiping empty spaces in the file
                            index += 2;
                        }
                        else
                        {
                            // storing all the values into the temp variable except "|"
                            temp += line.ElementAt(index);
                            // index value increased by 1 everytime the loop runs
                            index++;
                        }
                        // doctor variable to store ordinal doctor number
                        int doctor = int.Parse(temp);
                        // delaring the temp value to null
                        temp = "";
                        // if the line encounters "|" and white space character in the line at the same time
                        while (line.ElementAt(index) == '|' || Char.IsWhiteSpace(line.ElementAt(index)))
                            // index value increased by 1 everytime the loop runs
                            index++;
                        // if the indexed character is non-space character
                        while (!Char.IsWhiteSpace(line.ElementAt(index)))
                        {
                            // storing all the values into the temp variable except "|"
                            temp += line.ElementAt(index);
                            // index value increased by 1 everytime the loop runs
                            index++;
                        }
                        // with all values Anonymous Companion object is created and 
                        // added to companionList 
                        companionsList.Add(new Companion(name, actor, doctor, temp));
                    }
                }
                // Closes so that data in the file is not distorted while program is processing
                file.Close();

                // Doctor object doc is declared set to null for displaying
                Doctor doc = null;

                // looping through doctorList List which has ordinal 12 doctors stored in it
                for (int i = 0; i < doctorsList.Count; i++)
                {
                    // condition returns true for the first ordinal doctor
                    if (doctorsList.ElementAt(i).getOrdinal() == 1)
                    {
                        // retrieving reference of Doctor class in Doctor List
                        // using which we can call other object references to display
                        // other objects
                        doc = doctorsList.ElementAt(i);
                        break;
                    }
                }

                // diplaying the Actor's name in the "Played By" label
                textBox2.Text = doc.getActor();

                // displaying the series in "Series" label
                textBox3.Text = doc.getSeries() + "";

                // displaying age in "Age of Start" Label
                textBox4.Text = doc.getAge() + "";

                /// <summary>
                /// List for storing all objects of Companion Class for the Doctor instance
                /// </summary> 
                List<Companion> companionsResultList = new List<Companion>();

                /// <summary>
                /// List for storing all objects of Episode class for the Episode instance
                /// </summary>
                List<Episode> episodesResultList = new List<Episode>();

                // Making query to get Companion objects which has same Doctor instance
                IEnumerable<Companion> companionQuery =
                    from companion in companionsList where companion.getDoctor() == doc.getOrdinal() select companion;

                // Looping through companionQuery Enumerable object
                foreach (Companion companion in companionQuery)
                    // storing all the objects into List of companionResultList
                    companionsResultList.Add(companion);

                // Looping through list companionResultList to get all the episodes for companion instance
                for (int i = 0; i < companionsResultList.Count; i++)
                {
                    // Making query to get episode objects where 
                    IEnumerable<Episode> episodeQuery =
                        from episode in episodesList where episode.getStory() == companionsResultList[i].getDebut() select episode;

                    // looping through the IEumerable query to get all the objects of the Episode class
                    foreach (Episode episode in episodeQuery)
                        episodesResultList.Add(episode);
                }

                // Looping through the episode list to sort each time the data is loaded into the listbox
                for (int i = 0; i < episodesResultList.Count - 1; i++)
                {
                    // storing the current value of "i" into some variable
                    int tempIndex = i;

                    // companion object is stored into variable
                    Companion tempCompanion = companionsResultList.ElementAt(i);

                    // episode object is stored into variable
                    Episode tempEpisode = episodesResultList.ElementAt(i);

                    // taking flag to compare the values
                    bool flag = false;
                    for (int j = i + 1; j < episodesResultList.Count; j++)
                    {
                        // sorting the fields by year condition returns true if oneis less than antother
                        if (episodesResultList.ElementAt(j).getYear() < tempEpisode.getYear())
                        {
                            // storing the current index of "j"
                            tempIndex = j;
                            // changing the tempEpisode variable and passing new index value into it
                            tempEpisode = episodesResultList.ElementAt(j);
                            // changning the tempCompanion variable and passing new index value into it
                            tempCompanion = companionsResultList.ElementAt(j);
                            // flag is turn to true as it was succesful in sorting
                            flag = true;
                        }

                        // while sorting if the value of both the episode year is same
                        else if (episodesResultList.ElementAt(j).getYear() == tempEpisode.getYear())
                        {
                            // in this case name of the values are compared to sort
                            if (companionsResultList.ElementAt(j).getName().CompareTo(tempCompanion.getName()) == -1)
                            {
                                // storing the current index of "j"
                                tempIndex = j;
                                // changing the tempEpisode variable and passing new index value into it
                                tempEpisode = episodesResultList.ElementAt(j);
                                // changning the tempCompanion variable and passing new index value into it
                                tempCompanion = companionsResultList.ElementAt(j);
                                // flag is turn to true as it was succesful in sorting
                                flag = true;
                            }
                        }
                    }
                    // if the flag value returns true in the result of succesfull sorting
                    if (flag)
                    {
                        // values in the episodeResultList is sorted in order to display sorted result
                        episodesResultList[tempIndex] = episodesResultList.ElementAt(i);
                        // values in the episodeResultList is sorted in order to display sorted result
                        episodesResultList[i] = tempEpisode;
                        // values in the companionResultList is sorted in order to display sorted result
                        companionsResultList[tempIndex] = companionsResultList.ElementAt(i);
                        // values in the companionResultList is sorted in order to display sorted result
                        companionsResultList[i] = tempCompanion;
                    }
                }

                // displaying the year for the debut by artist
                textBox1.Text = episodesResultList.ElementAt(0).getYear() + "";
                // displaying the title of the debut
                textBox5.Text = episodesResultList.ElementAt(0).getTitle();

                // looping thourgh companionResultList to diplsay the data from the sorted list to listbox
                for (int i = 0; i < companionsResultList.Count; i++)
                {
                    // First line will be the Companion name and Actor name
                    string result1 = companionsResultList.ElementAt(i).getName() + "("
                        + companionsResultList.ElementAt(i).getActor() + ")" + System.Environment.NewLine;

                    // Second line is declared
                    string result2 = "";

                    // condition returns true if the value of the "i" is less than episodeResult length
                    if (i < episodesResultList.Count)
                    {
                        // second line is set to Episode title and Episode year
                        result2 = "\"" + episodesResultList.ElementAt(i).getTitle() + "\"("
                            + episodesResultList.ElementAt(i).getYear() + ")";
                    }

                    // result is added to listobox in order to display the content
                    listBox1.Items.Add(result1);
                    listBox1.Items.Add(result2);
                    listBox1.Items.Add("");
                }
                // dataloaded is set to true so far the program already load up with
                // data needed to displat and program has even displayed "First" ordnial
                // which is seleceted by default by combobox
                dataLoaded = true;
            }
            catch (Exception)
            {
                // User-frienly Message box displaying that there was error opening file
                MessageBox.Show("Error finding file/opening file");
            }

        }
    }
}