using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkboxes.Models
{
    public class Decor
    {

        public int ID { get; set; }

        public bool IsRedChecked { get; set; }

        public bool IsBlueChecked { get; set; }

        public bool IsGreenChecked { get; set; }

        public int GetNumberOfColours ()
        {

            int count = 0;

            if (IsRedChecked)
            {
                count++;
            }
            if (IsBlueChecked)
            {
                count++;
            }
            if (IsGreenChecked)
            {
                count++;
            }

            return count;

        }
    }
}
