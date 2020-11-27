using System;

namespace HashTable
{
    class Program
    {
        // Function to generate hash value from a string
        static int hashFunction(String s)
        {
            const int poly = 37; // prime values in polynomial calculation give a better distribution
            const int size = 50; // hash table size
            int total = 0;

            // loop through each character c in the string s
            for (int i = 0; i < s.Length; i++)
            {
                // s[i] is the next character; a is the polynomial; r the result 
                total += poly * total + (int)s[i]; // Cascaded evaluation of the polynoimal (Horner's Rule trick)
            }

            // c# has no int overflow, so deal with error case
            total = total % size;
            if (total < 0)
            {
                total += size;
            }

            return (total);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hashing!\n");

            // Declaring a string array of 50 items 
            string[] values = new string[50];
            string str;

            // Values of the keys stored 
            string[] keys = new string[] {"Florida", "Alabama",
                 "Delaware", "California", "Georgia","Texas","London","York","Hull","Brighton"};

            for (int i = 0; i < keys.Length; i++)
            {
                str = keys[i];
                values[hashFunction(str)] = str;
            }

            // Displaying Hashcodes along with key values 
            for (int i = 0; i < (values.Length); i++)
            {
                Console.WriteLine(i + " " + values[i]);
            }

        }
    }
}
