﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ch19_P11_MyEBookReader
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static void GetBook()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
               // theEBook = eArgs.Result;
                Console.WriteLine("Download complete.");
                GetStats();
            };
            // The Project Gutenberg EBook of A Tale of Two Cities, by Charles Dickens
            // You might have to run it twice if you’ve never visited the site before, since the first
            // time you visit there is a message box that pops up, and breaks this code.
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }

        static void GetStats()
        {
            // Get the words from the e-book.
           // string[] words = theEBook.Split(new char[]
           // { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
           // StringSplitOptions.RemoveEmptyEntries);
            // Now, find the ten most common words.
          //  string[] tenMostCommon = FindTenMostCommon(words);
            // Get the longest word.
         //   string longestWord = FindLongestWord(words);
            // Now that all tasks are complete, build a string to show all stats.
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
           // foreach (string s in tenMostCommon)
            {
             //   bookStats.AppendLine(s);
            }
           // bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();
            Console.WriteLine(bookStats.ToString(), "Book info");
        }

        private string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;
            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }
        private string FindLongestWord(string[] words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }
    }
}
