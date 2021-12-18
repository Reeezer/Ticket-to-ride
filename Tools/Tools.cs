using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_to_ride.ToolsNs
{
    public static class Tools<T>
    {
        public static void Shuffle(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = 0; i < n; ++i)
            {
                int k = random.Next(n + 1);

                T temp = list[i];
                list[i] = list[k];
                list[k] = temp;
            }
        }

        public static List<T> Pop(List<T> list, int count)
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
    }
}
