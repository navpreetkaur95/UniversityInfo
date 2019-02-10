using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UniversityInfo.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public string[] existingInfo;
        public string[] localData = new string[4];

        public List<string> roll = new List<string> { };
        public List<string> name = new List<string> { };
        public List<string> city = new List<string> { };
        public List<string> phone = new List<string> { };

        public void OnGet()
        {
            existingInfo = System.IO.File.ReadAllLines("data.dat");


            foreach (var line in existingInfo)
            {
                localData = line.Split(",");

                roll.Add(localData[1]);
                name.Add(localData[2]);
                city.Add(localData[3]);
                phone.Add(localData[4]);
            }

        }
    }
}
