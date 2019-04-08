using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace checkboxes.Models
{
    public class Decor
    {

        public int ID { get; set; }


        // the list of colours will be stored in the database
        // and can be used when displaying the data
        // but is not bound so cannot be used when the 
        // data is being updated.

        [BindNever]
        public string Colours { get; set; } = "";



        //this returns a boolean list based on the colours which are stored
        // and the list of colour choices which are passed in as a parameter.
        public List<bool> GenerateBooleanList (List<string> colourChoices)
        {
            List<bool> isPickedList = new List<bool> { };

            foreach (string colour in colourChoices)
            {
                isPickedList.Add(Colours.Contains(colour));
            }

            return isPickedList;
        }



        // this saves the colours chosen as a comma separated string
        //the two parameters must be lists of the same length.
        public void GenerateColoursString 
            (List<string> colourChoices, List<bool> ColoursPicked )
        {

            for(int i=0; i<colourChoices.Count(); i++)
            {
                if (ColoursPicked[i])
                {
                    if (Colours == "")
                    {
                        Colours = colourChoices[i];
                    }
                    else
                    {
                        Colours += "," + colourChoices[i];
                    }
                }
            }
        }







    }
}
