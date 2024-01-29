/* I implemented a program that
  Users can organize their personal book library management system with the aid of this program. 
  It has functions like adding books, deleting books by ID, searching by title, and showing all books. 
  The input validation process is ensured by the user-friendly architecture of the system. 
  Book data is kept in a basic data structure. The organization and accessibility of 
  people's personal libraries is made simpler by this effort.
 */

//Needed libraries:
using System;
using System.Collections.Generic;

namespace LibraryProject //My namespace
{//namespace block
    class Library //My LibraryProjectTMA class
    {//class block
        static void Main(string[] args)//My main header
        {//main method block
            welcomeAndMenu();//Invoke welcomeAndMenu method
        }//end main method

        //*** Fields: 

        //Declaring a List of lists to store the books and their info:
        static List<List<String>> libraryBooks = new List<List<String>>(); //string libraryBooks<<>>

        //Declaring an initializing lists for constraints:
        static String[] the_Choices = { "1", "2", "3", "4", "5" }; //string the_Choices [] array
        static char[] validInputDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };//char validInputDigits [] array
        static String[] validInputID = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };//string validInputID [] array


        //*** Validation Methods:
        static bool ValidateEnteredChoice(string enteredChoice)
        {//Validate user's choice by checking if it's in the_Choices list
            return the_Choices.Contains(enteredChoice);
        }//End of ValidateEnteredChoice method

        static bool ValidateEnteredID(string enteredID)
        {//Validate enterd bookk's ID by checking if it's in validInputID list
            return validInputID.Contains(enteredID);
        }//End of ValidateEnteredChoice method

        static bool ValidateEnteredYear(string enteredYear)
        {//Validate user's choice by checking if it's in the_Choices list
            if (enteredYear.Length != 4)//check enteredYear's digits no
            {
                Console.WriteLine("You entered an invalid year.");//Display error message
                return false;//not valid
            }//end if

            for (int y = 0; y < enteredYear.Length; y++)//iterate each digit of enteredYear
            {
                char enteredDigit = enteredYear[y];//let enteredDigit be digit of enteredYear 
                if (!validInputDigits.Contains(enteredDigit))//check validation
                {
                    Console.WriteLine("You entered an invalid year.");//Display error message
                    return false;//not valid
                }//end if
            }//end for
            return true;//valid
        }//End of ValidateEnteredYear method

        //*** Operation Methods:
        static void welcomeAndMenu()//method header
        { //Method to greet users once they lunch the app then offering menu of choices
            //Using this method to display the greeting to user's screen
            Console.WriteLine("Welcome to Personal Library Management System!\n");

            //Initializing bool var Exiting
            bool exiting = false; //Boolean variable to check if the user wants to exit or not
            while (!exiting)//if the value of Exiting true, then continue
            {//while block

                Console.WriteLine(""); //Line space
                Console.WriteLine("1. Add a book"); //Asking to insert a book to library
                Console.WriteLine("2. Search for books by title"); //Asking to search for a book in library
                Console.WriteLine("3. Delete a book by ID"); //Asking to delete a book from library
                Console.WriteLine("4. Display all books"); //Asking to print all books in library
                Console.WriteLine("5. Exit");//Asking the user if wants to exit the menu
                //Prompt the user to enter the operation needed (choice)
                Console.WriteLine("\nEnter your choice (1-5):\n"); //Number represents the operation

                string userChoice = Console.ReadLine();//Assign user input to userCoice
                int aChoice = ValidateEnteredChoice(userChoice) ? Convert.ToInt32(userChoice) : 0;//Check if userChoice is valid

                switch (aChoice)
                {//Which choice the user entered?
                    case 1://Isert a book to library?
                        Console.WriteLine(""); //Line space
                        insertABook();//Invoke IsertABook() method
                        break;//Exit the swich
                    case 2://Search for books in library?
                        Console.WriteLine(""); //Line space
                        searchForBooksByTheTitle();//Invoke searchForBooksByTheTitle() method
                        break;//Exit the swich
                    case 3://Delete a book from library?
                        Console.WriteLine(""); //Line space
                        deleteABook();//Invoke deleteABook() method
                        break;//Exit the swich
                    case 4://Display all the bookd in library?
                        Console.WriteLine(""); //Line space
                        displayAllTheBooks();//Invoke displayAllTheBooks() method
                        break;//Exit the swich
                    case 5://Exit the program?
                        Console.WriteLine(""); //Line space
                        Console.WriteLine("\nExiting you from the program...");//Display that user exited program
                        return;//Done
                    default://Other?
                        Console.WriteLine("\nInvalid choice! Please try again.");//Display that entry is invalid
                        break;//Exit the switch
                        Console.WriteLine("\n");//Break with two lines
                }//End of switch
            }//End of while iteration
        }//End of Welcom Method

        static void insertABook()//method header
        {//Inserting a book - operation

            Console.WriteLine("\nEnter the book's identifier:");//prompt the user to enter book id
            string enteredID = Console.ReadLine();//assign input as enteredID
            if (FindABookByTheID(enteredID) != null)//check if FindABookByTheID() not returning null
            {//if block
                Console.WriteLine("\nThe entered book ID already exists! Please try again with a unique ID.");//Display error with entry
            }//end if
            else if (!ValidateEnteredID(enteredID))//check if enteredID is valid
            {//else if block
                Console.WriteLine("\nInvalid book ID.! Please enter a numeric value.");//Display invalid entry
            }//end else if

            Console.WriteLine("\nEnter the book's title:");//Prompt the user to enter title of book
            string enteredTitle = Console.ReadLine();//assign input as enteredTitle

            Console.WriteLine("\nEnter the book's author:");//Prompt the user to enter author of book
            string enteredAuthor = Console.ReadLine();//assign input as enteredAuthor

            string enteredYear;//variable for publication year entry
            do//execute
            {
                Console.WriteLine("\nEnter the book's publication year:");//Prompt the user to enter year of book
                enteredYear = Console.ReadLine();//assign input as enteredYear
            }
            while (!ValidateEnteredYear(enteredYear));//iteration while entry is not valid

            //Isert book info to newBook list then to libraryBooks list:
            List<string> newBook = new List<string> { enteredID, enteredTitle, enteredAuthor, enteredYear };//insert new book
            libraryBooks.Add(newBook);//new book inserted to the library
            Console.WriteLine("\nBook added successfully!");//Display success statement
        }//End of insertABook method

        static void searchForBooksByTheTitle()//method header
        {//Searching for all matched books by their title - operation
            Console.WriteLine("\nEnter the book's title to search for matchings:");//Prompt the user to enter book's title
            string enteredTitle = Console.ReadLine();//Assign user input to enteredTitle

            Console.WriteLine("\nAll matching books:");//Display matchings

            bool bookThere = false;//Boolean variable bookThere
            foreach (List<string> bookTitles in libraryBooks)//To display all books with info 
            {//foreach block 
                string[] titleFirstWord = bookTitles[1].Split(' ');//split the first word of all titles and assign it to titleFirstWord[]
                if (titleFirstWord[0] == enteredTitle)//Is titleFirstWord value matches enteredTitle?
                {//if block
                    Console.WriteLine("\nID: {0}, Title: {1}, Author: {2}, Publication Year: {3}",
                                       bookTitles[0], bookTitles[1], bookTitles[2], bookTitles[3]);// Display book info
                    bookThere = true;//set bookThere to true
                }//end block
            }//end foreach
            if (!bookThere)
            {//if block
                Console.WriteLine("\nThere is no books found with the specified title you provided!");// Display error, books not found
            }//end if 
        }//End of searchForBooksByTheTitle method

        static List<string> FindABookByTheID(string enteredID)//method header
        {//Finding a book by it's id - operation
            return libraryBooks.FirstOrDefault(thisBook => thisBook[0] == enteredID);//book id there or not
        }//End of FindABookByTheID method

        static void deleteABook()//method header
        {//Deleting a book by it's id - operation
            Console.WriteLine("\nEnter the book's ID to delete it from the library:");//Prompt the user to enter book id
            string enteredID = Console.ReadLine();//Assign input to enteredID

            List<string> deleteBook = FindABookByTheID(enteredID);//Initialize deleteBook list
            if (deleteBook != null)//Check if deleteBook not null
            {//if block
                libraryBooks.Remove(deleteBook);//Discard the book from libraryBooks
                Console.WriteLine("\nBook deleted successfully!");//Display success statement
            }//end if
            else//if null
            {//else block
                Console.WriteLine("\nBook ID not found! Please try again.");//Display error with entry
            }//end else 
        }//End of deleteABook method

        static void displayAllTheBooks()//method header
        {//Displaying (printing) all the book entered the library - operation
            if (libraryBooks.Count == 0)//Check libraryBooks is empty or not
            {//if block
                Console.WriteLine("\nThere is no books to display!");//Display no books there
            }//end if
            else//books there
            {//else block
                Console.WriteLine("\nAll the books in the library:");//Display all the books in library

                foreach (List<string> eachBook in libraryBooks)//Iteration through libraryBooks
                {//foreach block
                    Console.WriteLine("\nID: {0}, Title: {1}, Author: {2}, Publication Year: {3}",
                                       eachBook[0], eachBook[1], eachBook[2], eachBook[3]);// Display book info
                }//end foreach
            }//end else
        }//End of displayAllTheBooks method
    }//End of class
}//End of namespace

/*
 I am offering an intuitive interface for adding, finding, deleting, and displaying all books, 
 the Personal Library Management System improves the management of library of books and helps users to easily access the library.
 */
