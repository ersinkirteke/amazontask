using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AmazonTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] reviews = new string[6] {
                "newshop is providing good services in the city;everyone should use newshop",
                "best services by newshop",
                "fashionbeats has great services mymarket int the city",
                "i am proud to have fashionbeats",
                "mymarket has awesome services",
                "Thanks NewShop for the quick delivery"
            };

            Dictionary<string, int> dic = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);

            for (int i = 0; i < reviews.Length; i++)
            {
                string review = Regex.Replace(reviews[i], @"[^0-9a-zA-Z]+", " "); ;
                string[] splittedReview = review.Split(' ');
                for (int j = 0; j < splittedReview.Length; j++)
                {
                    if (!dic.ContainsKey(splittedReview[j]))
                    {
                        dic.Add(splittedReview[j], 1);
                    }
                    else
                    {
                        dic[splittedReview[j]]++;
                    }
                }
            }

            string[] competitors = new string[6] { "newshop", "shopnow", "afshion", "fashionbeats", "mymarket", "tcellular" };

            OrderedDictionary competitorsCount = new OrderedDictionary();

            for (int i = 0; i < competitors.Length; i++)
            {
                if (dic.ContainsKey(competitors[i]))
                {

                    competitorsCount.Add(competitors[i], dic[competitors[i]]);
                }
            }


            int counter = 0;

            string s = "";

            foreach (DictionaryEntry item in competitorsCount)
            {
                if (counter == 2)
                    break;

                s += "\"" + item.Key + "\",";
                counter++;
            }
            s = s.Substring(0, s.Length - 1);

            Console.WriteLine(string.Format("[{0}]",s));

            
            Console.ReadLine();
        }
    }
}
