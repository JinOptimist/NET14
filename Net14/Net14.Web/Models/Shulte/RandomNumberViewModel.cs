using System;
using System.Linq;

namespace Net14.Web.Models.Shulte
{
    public class RandomNumberViewModel
    {
        public int[] Random()
        {
            var array = Enumerable.Range(1,25).ToArray();
            var random = new Random();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int j = random.Next(i);
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;

        }

    }
}
