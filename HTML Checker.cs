
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Lab4B
{
    public partial class Form1 : Form
    {
        Stack htmlLines; // Stack for reading the file data
        /// <summary>
        /// First Initialization of Form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";       // label2 is set to null
        }
        /// <summary>
        /// Form load Method
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            checkTagsToolStripMenuItem.Enabled = false;     // Check Tags in menu is set to enabled as per the needs
        }
        /// <summary>
        /// Method for Load file in menu
        /// </summary>
        /// <param name="openFileDialog">Object for OpenFileDialog</param>
        /// <param name="stream">User's menu option</param>
        private void LoadFile(object sender, EventArgs e)
        {
            
            label1.Text = "";                       //  label is set to null as per the need
            label2.Text = "";                       // label2 is set to null as per the need 
            listBox1.Items.Clear();                 // listBox is emptied
            Stream stream = null;                   // Stream is called to get of sequence bytes
            OpenFileDialog openFileDialog = new OpenFileDialog();   // displays dialog box with file explorer

            openFileDialog.Filter = "HTML files (*.html)|*.html"; // filters the file in file explorer
            openFileDialog.RestoreDirectory = true;     // restores the directory that was opened last

            if (openFileDialog.ShowDialog() == DialogResult.OK) // if the user selects "OK" on the dialog box
            {
                try
                {
                    // opened file is not empty
                    if ((stream = openFileDialog.OpenFile()) != null) 
                    {
                        // stream that has whole the data of file
                        using (stream)          
                        {
                            // enabled as per the need
                            checkTagsToolStripMenuItem.Enabled = true;

                            // Declaring stack for storing the file while reading
                            htmlLines = new Stack();

                            // line is declared for storing whole line in the file
                            string line;

                            // StreamReader reads provided file instance
                            StreamReader file = new StreamReader(openFileDialog.FileName);

                            // retrieves file name and label1 is set to file name
                            label1.Text = openFileDialog.SafeFileName;

                            // reads the file till end
                            while ((line = file.ReadLine()) != null)    
                            {
                                // stack is filled with data in the file
                                htmlLines.Push(line);       
                            }
                            // Closes so that data in the file is not distorted while program is processing
                            file.Close();               
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
        /// Method for closing form
        /// </summary>
        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Method for html line filtering to TAG
        /// </summary>
        /// <param name="outputString">string for printing it to form</param>
        /// <param name="outRHTML">handling string with remaining line of code</param>
        /// <param name="tempHTMLTag">string with remaining line of code</param>
        /// <param name="deleteTag">deletes tag that has already been read from the line</param>
        /// <param name="data">string for filtering passed as argument</param>
        /// <param name="remainingHTML">string passed as "out" in argument whose value should be stored in this method</param>
        private string HtmlLineProcess(string data, out string remainingHTML)
        {
            string outputString = "";
            string outRHTML = "";
            string tempHTMLTag = "";
            string deleteTag = "";
            int endingIndex = 0;
            int startingIndex = 0;
            if (data.IndexOf("<") >= 0)
            {
                // notes the index of "<"
                startingIndex = data.IndexOf("<");
                // notes the the difference between tags "<>"
                endingIndex = data.IndexOf(">") - startingIndex + 1;
                // tag is filtered with the difference found
                tempHTMLTag = data.Substring(startingIndex, endingIndex);
                // tag is stored for deleting
                 deleteTag = tempHTMLTag;

                // Filtering the if statement for non-container tag
                if (tempHTMLTag.Contains("/>") || tempHTMLTag.Contains("img") || tempHTMLTag.Contains("meta") || tempHTMLTag.Contains("input"))
                {
                    // splits the screen from the space found
                    string[] tempTagHandling = tempHTMLTag.Split(' ');
                    // outputstring is created for output
                    outputString += "Found non-conatiner tag: ";
                    // length of the tag is determined for processing the tag as per the size
                    switch (tempTagHandling[0].Length)
                    {
                        case 2:
                            tempHTMLTag = tempHTMLTag.Substring(0, 2);
                            break;
                        case 3:
                            tempHTMLTag = tempHTMLTag.Substring(0, 3);
                            break;
                        case 4:
                            tempHTMLTag = tempHTMLTag.Substring(0, 4);
                            break;
                        case 5:
                            tempHTMLTag = tempHTMLTag.Substring(0, 5);
                            break;
                        case 6:
                            tempHTMLTag = tempHTMLTag.Substring(0, 6);
                            break;
                        case 7:
                            tempHTMLTag = tempHTMLTag.Substring(0, 7);
                            break;
                        default:
                            break;
                    }
                    outputString += tempHTMLTag + "/>";
                }
                // filtering the tag for closing
                else if (tempHTMLTag.Contains("</"))
                {

                    outputString += "Found closing tag: ";
                    outputString += tempHTMLTag;
                }
                // filtering for tag which have inclass styling in their code
                else if ((tempHTMLTag.Length) > 7 && !tempHTMLTag.Contains("</"))
                {
                    // splits the string and stores for processing
                    string[] tempTagHandling = tempHTMLTag.Split(' ');
                    outputString += "Found opening tag: ";
                    // length of the tag is determined for processing the tag as per the size
                    switch (tempTagHandling[0].Length)
                    {
                        case 2:
                            tempHTMLTag = tempHTMLTag.Substring(0, 2);
                            break;
                        case 3:
                            tempHTMLTag = tempHTMLTag.Substring(0, 3);
                            break;
                        case 4:
                            tempHTMLTag = tempHTMLTag.Substring(0, 4);
                            break;
                        case 5:
                            tempHTMLTag = tempHTMLTag.Substring(0, 5);
                            break;
                        case 6:
                            tempHTMLTag = tempHTMLTag.Substring(0, 6);
                            break;
                        case 7:
                            tempHTMLTag = tempHTMLTag.Substring(0, 7);
                            break;
                        default:
                            break;

                    }
                    outputString += tempHTMLTag + ">";
                    
                }
                // filtering the tags for remaining non container tag differently beacuse 
                // these are variables that any string can have
                else if (tempHTMLTag.Contains("hr") || tempHTMLTag.Contains("br"))
                {
                    outputString += "Found non-conatiner tag: ";
                    tempHTMLTag = data.Substring(startingIndex, 3);
                    outputString += tempHTMLTag + "/>";
                }
                // for all regular opening tags
                else
                {
                    outputString += "Found opening tag: ";
                    outputString += tempHTMLTag;
                }
            }
            // filtering the tags and storing it as remaining HTML tags
            if (tempHTMLTag.Length != 0)
            {
                outRHTML = data.Replace(deleteTag, "");
            }
            remainingHTML = outRHTML;
            // outputs the string for printing
            return outputString;
        }

        /// <summary>
        /// Method for tool strip menu item clicked
        /// </summary>
        private void checkTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Stack initializtion for storing
            Stack tempHTMLTagStack = new Stack();
            // looping through stack and popping out at the same time
            while (htmlLines.Count > 0)
            {
                // variable which stores the html line 
                string tempItem = (string)htmlLines.Pop();

                // stores number for number of times it encounters "<"
                int tagcount = tempItem.Split('<').Length - 1;

                // Filtering the Doctype comment
                if (tempItem.Contains("<!--"))
                {
                    tempHTMLTagStack.Push("<!--to>");
                }
                // Filtering Comments in HTML
                else if (tempItem.Contains("<!"))
                {
                    tempHTMLTagStack.Push("<!doctype>");
                }
                // filtering all the remaining code if it contains "<"
                else if (tempItem.IndexOf("<") >= 0)
                {
                    // loops through number of times the tagCount
                    for (int i = 0; i < tagcount; i++)
                    {
                        // TAG is stored in new variable declared
                        string processedTag = HtmlLineProcess(tempItem, out tempItem);

                        // Filtering the is the string is not empty
                        if (processedTag != "")
                        {
                            // stores the string into new stack created
                            tempHTMLTagStack.Push(processedTag);
                        }
                        
                    }
                }
            }

            // looping through stack
            foreach (string item in tempHTMLTagStack)
            {
                // adds to items to Listbox
                listBox1.Items.Add(item);
            }

            // returns boolean value checking whether the code is balanced or not
            if (checkCorrespondingTags(tempHTMLTagStack))
            {
                // sets the label2 to balanced tags
                label2.Text = ": Has balanced tags";
            }
            else
            {
                // sets the label2 to unbalanced tags
                label2.Text = ": Has unbalanced tags";
            }
        }
        /// <summary>
        /// Method for checking corresponding tags
        /// </summary>
        public bool checkCorrespondingTags(Stack st)
        {
            Stack checkOpenTags = new Stack();
            Stack checkCloseTags = new Stack();
            Stack notFoundTags = new Stack();
            while (st.Count > 0)
            {
                string search = (string) st.Pop();
                int searchStartingIndex = search.IndexOf("<") + 1;
                int searchEndingIndex = search.IndexOf(">") - searchStartingIndex;
                string tempString = "";
                
                if (search.Contains("/>") || search.Contains("<!"))
                {

                }
                // checks the ending tags
                else if (search.Contains("/"))
                {
                    tempString = search.Substring(searchStartingIndex + 1, searchEndingIndex - 1);
                    checkCloseTags.Push(tempString.ToLower());
                }
                // for all opening tags
                else
                {
                    tempString = search.Substring(searchStartingIndex, searchEndingIndex);
                    checkOpenTags.Push(tempString.ToLower().Trim());
                }
            }
            // checks all opentags are equal to closing tags
            if (checkOpenTags.Count == checkCloseTags.Count)
            {
                // loops through openingtags data
                while (checkOpenTags.Count > 0)
                {
                    // if the closingtags has the opening tags is remvoes
                    if (checkCloseTags.Contains(checkOpenTags.Peek()))
                    {
                        checkOpenTags.Pop();
                    }
                    // stores the removed tag to new stack to check it as unbalanced tags
                    else
                    {
                        notFoundTags.Push(checkOpenTags.Pop());
                    }
                }
            }
            // if the count is not similar then returns false0
            else
            {
                return false;
            }
            // if the new stack is null then return true          
            if (notFoundTags.Count == 0)
            {
                return true;
            }
            // then return false
            else
            {
                return false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
