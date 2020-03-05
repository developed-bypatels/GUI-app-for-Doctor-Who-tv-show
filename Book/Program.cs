using System;
using System.Collections;

namespace Book
{
    class MainClass
    {
        // boolean flag for file to check whether the file existed or not
        private static bool fileExistance;

        /* ArrayLists for all Media Objects in different categories*/

        // MediaList for all Media Objects regardless of category
        private static ArrayList mediaList = new ArrayList();

        // BookList for all objects of Book Class
        private static ArrayList bookList = new ArrayList();

        // SongList for all objecets of Song Class
        private static ArrayList songList = new ArrayList();

        // MovieList for all movieList of Movie Class
        private static ArrayList movieList = new ArrayList();

        static void Main(string[] args)
        {
            // Option for choices
            String numericArray = "123456";

            // declaring and intializing chocie variable
            String choice = "";

            // Invoking the READ Method
            Read();

            // Condition checks that boolean flag file is present or not
            if (fileExistance)
            {

                // To stop the console program if user enters 6
                while (choice != "6")
                {
                    // Clears the console screen and displays the heading
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Frank's Media Collection\n=========================");
                    Console.ForegroundColor = ConsoleColor.White;

                    // Displays option on to the console program
                    Console.WriteLine("1. List All Books\n2. List All Movies\n3. List All " +
                        "Songs\n4. List All Media\n5. Search All Media by Title\n\n6. Exit Program");

                    // Asks for user input of choice
                    Console.Write("\nEnter your choice: ");
                    choice = Console.ReadLine();
                    Console.WriteLine();

                    // Condition checks if the choice returns empty
                    if (choice == "")
                    {
                        Console.WriteLine("\n**Please enter something.\nPress any key to continue ...");
                        Console.ReadKey();
                    }

                    // Condition checks if choice returns one of the option
                    else if (numericArray.Contains(choice))
                    {
                        // Condition checks if the choice returns 1
                        if (Convert.ToInt32(choice) == 1)
                        {
                            // Iterates through BookList containing Book objects
                            foreach (Book b in bookList)
                            {
                                // Prints ToString object of Book Class which returns Title and Year of the Book
                                Console.WriteLine(b.ToString());
                            }
                        }
                        else if (Convert.ToInt32(choice) == 2)
                        {
                            // Iterates through MovieList containing Movie objects
                            foreach (Movie m in movieList)
                            {
                                // Prints ToString object of Movie Class which returns Title and Year of the Movie
                                Console.WriteLine(m.ToString());
                            }
                        }
                        else if (Convert.ToInt32(choice) == 3)
                        {
                            // Iterates through SongList containing Song objects
                            foreach (Song s in songList)
                            {
                                // Prints ToString object of Song Class which returns Title and Year of the Song
                                Console.WriteLine(s.ToString());
                            }
                        }
                        else if (Convert.ToInt32(choice) == 4)
                        {
                            // Iterates through MediaList containing all objects
                            foreach (Media m in mediaList)
                            {
                                // Prints ToString object respective objects which returns of Title and Year of respective Classes
                                Console.WriteLine(m.ToString());
                            }
                        }

                        // Condition checks if the choice returns 5 
                        else if (Convert.ToInt32(choice) == 5)
                        {
                            // Asks for the user to enter the search string
                            Console.Write("Enter a search string: ");
                            string searchString = Console.ReadLine();

                            // Iterates through all Media Objects
                            foreach (Media m in mediaList)
                            {
                                // Condition checks if the search string is the substring of Title of any Media
                                if (m.Search(searchString))
                                {
                                    // Prints the ToString objects of respective classes
                                    Console.WriteLine("\n" + m.ToString());

                                    // Condition checks if the object either of Book or Movie
                                    if (m is Book || m is Movie)
                                    {
                                        // Prints GetSummary mehod of respected object
                                        Console.WriteLine(m.GetSummary());
                                    }

                                    Console.WriteLine("--------------------");
                                }
                            }
                        }
                        // Constion checks if the choice returns 6 then close the program
                        else if (Convert.ToInt32(choice) == 6)
                        {

                        }
                        Console.WriteLine("\n\nPress any key to continue ...");
                        Console.ReadKey();
                    }

                    // Runs if choice does not matches with any of the choices
                    else
                    {
                        Console.WriteLine("**Input is Wrong.\nPress enter key to continue");
                        Console.ReadKey();
                    }
                }
            }

            // Runs if the choice returns something that's not the option
            else
            {
                Console.WriteLine("File does not existed");
                Console.ReadKey();
            }
        }

        // Read method will read whole file
        private static void Read()
        {
            // String Array - mediaCheck is declared to store Title and Year of the Media objects 
            string[] mediaCheck = new string[5];

            // String - row is declared for storing the line returned from the file
            string row;
            try
            {
                // Opens the file for reading
                System.IO.StreamReader file = new System.IO.StreamReader("data.txt");

                // Stores the line returned from the file and checks whether it is null or not
                while ((row = file.ReadLine()) != null)
                {
                    // mediaCheck array is populated with Type, Title, Year, Author/Album/Artist
                    mediaCheck = row.Split('|');

                    /* Condition checks the type of the Media*/

                    // IF Type returns BOOK
                    if (mediaCheck[0].ToLower() == "book")
                    {
                        // Creates the Book Object and passes Title and Year in the argument
                        Book book = new Book(mediaCheck[1], Convert.ToInt32(mediaCheck[2]));
                        // Invokes the Author method and passes Author Name as a argument
                        book.Author(mediaCheck[3]);

                        // Iterates through the file until it finds this string
                        while ((row = file.ReadLine()) != "-----")
                        {
                            // Invokes the SetSummary method and passes the string in to the argument
                            book.SetSummary(row + "\n");
                        }

                        // Add method is invoked on the ArrayList - BookList and Book method is added to it
                        bookList.Add(book);
                        // Add method is invoked on the ArrayList - mediaList and Book method is added to it
                        mediaList.Add(book);
                    }

                    // IF Type returns SONG
                    if (mediaCheck[0].ToLower() == "song")
                    {
                        // Creates the Song Object and passes Title and Year in the argument
                        Song song = new Song(mediaCheck[1], Convert.ToInt32(mediaCheck[2]));
                        // Invokes the Album method and passes Album Name as a argument
                        song.Album(mediaCheck[3]);
                        // Invokes the Artist method and passes Artist Name as a argument
                        song.Artist(mediaCheck[4]);

                        // Add method is invoked on the ArrayList - SongList and Song method is added to it
                        songList.Add(song);
                        // Add method is invoked on the ArrayList - MediaList and Song method is added to it
                        mediaList.Add(song);
                    }

                    // IF Type returns MOVIE
                    if (mediaCheck[0].ToLower() == "movie")
                    {
                        // Creates the Movie Object and passes Title and Year in the argument
                        Movie movie = new Movie(mediaCheck[1], Convert.ToInt32(mediaCheck[2]));
                        // Invokes the Director method and passes Director Name as a argument
                        movie.Director(mediaCheck[3]);

                        // Stores the line returned from the file and checks whether it is null or not
                        while ((row = file.ReadLine()) != "-----")
                        {
                            // Invokes the SetSummary method and passes the string in to the argument
                            movie.SetSummary(row + "\n");
                        }

                        // Add method is invoked on the ArrayList - MovieList and Movie method is added to it 
                        movieList.Add(movie);
                        // Add method is invoked on the ArrayList - MediaList and Movie method is added to it
                        mediaList.Add(movie);
                    }
                }
                // Populates fileExistace as TRUE - means Program found the file
                fileExistance = true;
                // file must be closed once it read and stored so that external command can not change the file content
                file.Close();
            }
            catch
            {
                // Populates fileExistance as FALSE - means Program was not able to found the file
                fileExistance = false;
            }


        }

    }
}
