using System;
using System.Globalization;

namespace ConsoleApp
{
    class Program
    {

        static void Main(String[] args)
        {
            MainMenu(); // call the MainMenu function
        }


        static void MainMenu()
        {
            Console.Clear(); // clears the menu 
            Console.WriteLine("Welcome to my app");
            Console.WriteLine("");
            Console.WriteLine("Option 1. Convert a string to uppercase");
            Console.WriteLine("Option 2. Reverse a string");
            Console.WriteLine("Option 3. Count the number of vowels in a string");
            Console.WriteLine("Option 4. Count the number of words in a string");
            Console.WriteLine("Option 5. Convert a string to title case");
            Console.WriteLine("Option 6. Check if a string is a palindrome");
            Console.WriteLine("Option 7. Find the longest and shortest words in a string");
            Console.WriteLine("Option 8. Find the most frequent words in a string");
            Console.WriteLine("Option 9. Exit");
            Console.WriteLine("");
            Console.WriteLine("Please type the number of Option to Execute");

            
            string myoptions = Console.ReadLine(); // reads the input of the user
            switch (myoptions) // we use switch to determin the action the user wants
            {
                case "1":
                    Console.WriteLine("Type the word you want to convert to uppercase");
                    Console.WriteLine("your word to uppercase is: "+ ToUppercase(Read()));
                    Exit();
                    break;
                case "2":
                    Console.WriteLine("Type the word you want to reverse");
                    Console.WriteLine("your word in reverse is : "+ Reverse(Read()));
                    Exit();
                    break;
                case "3":
                    Console.WriteLine("Enter a string");
                    Console.WriteLine("The number of vowels in your string are: " + NumberOfVowels(Read()));
                    Exit();
                    break;
                case "4":
                    Console.WriteLine("Enter a string");
                    Console.WriteLine("The total words are: " + NumberOfWords(Read()));
                    Exit();
                    break;
                case "5":
                    Console.WriteLine("Enter a string");
                    Console.WriteLine("Your string to titleCase is: " + TitleCase(Read()));
                    Exit();
                    break;
                case "6":
                    Console.WriteLine("Enter a String");
                    Console.WriteLine(Palindrome(Read()));
                    Exit();
                    break;
                case "7":
                    Console.WriteLine("Enter your string");
                    string[] result = LongestShortest(Read());
                    Console.WriteLine("Shortest Word is: " + result[0]);
                    Console.WriteLine("Longest Word is: " + result[1]);
                    Exit();
                    break;
                case "8":
                    Console.WriteLine("Enter your string");
                    Console.WriteLine("the most most frequent word is:" + Mostfrequent(Read()));
                    Exit();
                    break;
                case "9":
                    System.Environment.Exit(0); // if the user presses 9 the aplication exits
                    break;
            }
            MainMenu();
        }

        static string ToUppercase(string read) // function to convert the string to uppercase
        {
            string myStr = read;
            string result = string.Empty;
            for (int i = 0; i < myStr.Length; i++)
            {
                if(myStr[i]>='a' && myStr[i]<= 'z') // if the character of the index i is alphabetical we conver it to char
                {
                    result += (char) (myStr[i] - 32);
                }
                else
                {
                    result += myStr[i];
                }
            }
            return result;
        }

        static string Reverse(string read) // function to reverse a string
        {
            string myStr = read;
            string result = string.Empty;
            for(int i = myStr.Length -1; i >= 0; i--)
            {
                if (myStr[i] >='a' && myStr[i] <= 'z') // if char at index of i in myStr is from a-z we add it to the first place 
                {
                    result += myStr[i];
                }
                else
                {
                    result += myStr[i];  // else we add the character or space to the string result
                }
            }

            return result;
        }

        static int NumberOfVowels(string read)
        {
            string myStr = read;
            int vcount = 0;
            foreach(char c in myStr) // we loop though the character in the myStr
            {
                if((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    if(c=='a' || c=='e' || c=='i' || c== 'o' || c == 'u')
                    {
                        vcount++;
                    }else if(c=='A' || c=='E' || c=='I' || c=='O' || c == 'U')
                    {
                        vcount++;
                    }
                }
            }
            return vcount;
        }

        static int NumberOfWords(string read)
        {
            string myStr = read;
            int count = 1, len = 0;

            while (len <= myStr.Length - 1)
            {
                if (myStr[len] == ' ' || myStr[len] == '\n' || myStr[len] == '\t')
                {
                    count++;
                }
                len++;
            }
            return count;
        }

        static string TitleCase(string read) 
        {
            string myStr = read;
            TextInfo info = new CultureInfo("en-En", false).TextInfo; // we imported System.Globalization to use CultureInfo
            string result = info.ToTitleCase(myStr);
            return result;
        }

        static string Palindrome(string read)
        {
            
            string str = read;
            string result = "";
            char[] arr = str.ToCharArray(); // we converted our string to a char array and added to the the arr array
            Array.Reverse(arr); // we reversed the array 
            string str_reverse =  new string(arr);
            if (str.Equals(str_reverse))
            {
                result = "Your string is a Palindrome";
            }
            else
            {
                result = "Your string is not a Palindrome";
            }
            return result;
        }

        static String[] LongestShortest(string read)
        {
       
            string str = read;

            int len = str.Length;

            string k = "",max = "" , min = "";
            char ch;

            int p, max1 = 0;
            int min1 = len;

            for(int i = 0; i < len; i++)
            {
                ch = str[i];

                if(ch != ' ')
                {
                    k = k + ch;
                }
                else
                {
                    p = k.Length;

                    if (p < min1)
                    {
                        min1 = p;
                        min = k;
                    }
                    if(p > max1)
                    {
                        max1 = p;
                        max = k;
                    }

                    k = "";
                }
            }
            String[] result = new String[2];
            result[0] = min;
            result[1] = max;

            return result;
        }

        static string Mostfrequent(string read)
        {
           
            string str = read;
            int count;
            int max = 0;
            str = str.ToLower();
            string result = "";
            string[] words = str.Split(' ');

            for(int i = 0;i < words.Length; i++)
            {
                count = 1;
                for(int j = i + 1; j < words.Length; j++)
                {
                    if(words[i] == words[j])
                    {
                        count++;
                    }
                }

                if(count > max)
                {
                    max = count;
                    result = words[i];
                }
            }
            return result;
        }

        static void Exit()
        {
            Console.WriteLine("");
            Console.WriteLine("Press e to exit Exit application");
            Console.WriteLine("Press a to return to main Menu");
            string myStr = Console.ReadLine();
            if(myStr == "a")
            {
                MainMenu();
            }
            else if(myStr == "e")
            {
                System.Environment.Exit(0);
            }

        }


        static string Read()
        {
            return Console.ReadLine();
        }
       
    }
}