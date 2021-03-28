using System;
using System.Collections.Generic;

namespace HarryStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //This is a coding excercise solution for: https://codingdojo.org/kata/Potter/
            //To run this excercise, run the tests.
        }

        /// <summary>
        /// Calculates the total cost of the basket.
        /// </summary>
        /// <param name="bookSKUs"></param>
        /// <returns>Total sum</returns>
        public decimal CalculateTotalBasket(int[] bookSKUs)
        {
            //We will put each book's SKU (unique ID) in to a set.
            //Set is not allowed to have duplicate books for discount calculations.

            List<List<int>> bookSets = new List<List<int>>();

            //Create first empty set.
            bookSets.Add(new List<int>());

            //We take a book (sku)
            foreach (var sku in bookSKUs)
            {
                List<int> desinationBookSet = null;

                //We try to put it in a set which doesnt contain this book.
                foreach (var bookSet in bookSets)
                {
                    if (bookSet.Contains(sku) == false)
                    {
                        //We go through each book set, and see if we can add the book to the set.
                        //We don't stop after finding a suitable set.
                        //We look if there is a better set to put this book in (contains less books for greater discount)
                        if (desinationBookSet == null || desinationBookSet.Count > bookSet.Count)
                            desinationBookSet = bookSet;
                    }
                }
                if (desinationBookSet == null)
                {
                    //If we did not find a suitable set, we create a new book set and put the book in it.
                    bookSets.Add(new List<int>() { sku });
                }
                else
                {
                    //Once a suitable bookset is found, we add the book to it.
                    desinationBookSet.Add(sku);
                }
            }

            //Once all book have been put in correct pricing sets, we calculate the total.
            decimal total = 0;
            foreach (var bookSet in bookSets)
            {
                total += GetSetSum(bookSet.Count);
            }

            return total;
        }
        private decimal GetSetSum(int numberOfUniqueBooks)
        {
            decimal bookPrice = 8;
            //2 different books 5% discount on those books.
            //3 different books 10% discount on those books.
            //4 different books 20% discount on those books.
            //5 different books 25 % discount on those books.
            switch (numberOfUniqueBooks)
            {
                case 1:
                    return bookPrice;
                case 2:
                    return ApplyDiscount(bookPrice * 2, 5);
                case 3:
                    return ApplyDiscount(bookPrice * 3, 10);
                case 4:
                    return ApplyDiscount(bookPrice * 4, 20);
                case 5:
                    return ApplyDiscount(bookPrice * 5, 25);
                default:
                    throw new Exception("invalid number of books in a set");
            }
        }
        public decimal ApplyDiscount(decimal amount, decimal discount)
        {
            return amount - (amount / 100 * discount);
        }
    }
}