using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.Tools
{
    /// <summary>
    /// List of usefull methods to apply on lists
    /// </summary>
    public static class ToolBox
    {
        /// <summary>
        /// Apply a shuffle on a list
        /// </summary>
        /// <typeparam name="T">Template</typeparam>
        /// <param name="list">List</param>
        public static void Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = 0; i < n; ++i)
            {
                int k = random.Next(n);

                T temp = list[i];
                list[i] = list[k];
                list[k] = temp;
            }
        }

        /// <summary>
        /// Pop an amount of element in a list
        /// </summary>
        /// <typeparam name="T">Template</typeparam>
        /// <param name="list">List</param>
        /// <param name="count">Number</param>
        /// <returns>List</returns>
        public static List<T> Pop<T>(List<T> list, int count)
        {
            List<T> poppedElements = new List<T>();

            for (int i = 0; i < count; ++i)
            {
                T selectedCard = list[0];
                list.RemoveAt(0);
                poppedElements.Add(selectedCard);
                
                if (!list.Any())
                {
                    break;
                }
            }

            return poppedElements;
        }

        /// <summary>
        /// Pop an amount of element in a ObservableCollection
        /// </summary>
        /// <typeparam name="T">Template</typeparam>
        /// <param name="list">List</param>
        /// <param name="count">Number</param>
        /// <returns>ObservableCollection</returns>
        public static ObservableCollection<T> PopOnCollection<T>(List<T> collection, int count)
        {
            ObservableCollection<T> poppedElements = new ObservableCollection<T>();

            for (int i = 0; i < count; ++i)
            {
                T selectedCard = collection[0];
                collection.RemoveAt(0);
                poppedElements.Add(selectedCard);

                if (!collection.Any())
                {
                    break;
                }
            }

            return poppedElements;
        }

        /// <summary>
        /// Sort a list
        /// </summary>
        /// <typeparam name="T">Template</typeparam>
        /// <param name="list">List</param>
        public static void Sort<T>(ObservableCollection<T> collection) where T : IComparable
        {
            List<T> sorted = collection.OrderBy(x => x).ToList();
            for (int i = 0; i < sorted.Count(); i++)
            {
                collection.Move(collection.IndexOf(sorted[i]), i);
            }
        }
    }
}
