using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UniversityInfo.Pages
{
    public class CreateModel : PageModel
    {
        public string Message { get; set; }
        public string[] attributes;

        public void OnGet()
        {
            string userEntry = Request.QueryString.Value;
            if (userEntry == null)
            {
            }
            else
            {
                Message = "Go to Manage Data to view this update.";
                string[] lines = System.IO.File.ReadAllLines("data.dat");

                attributes = new string[4];
                attributes = userEntry.Split("&");

                string Data = (lines.Length+1).ToString();
                foreach (string item in attributes)
                {
                    Data = Data+","+item.Split("=")[1];
                }

                System.IO.File.AppendAllText("data.dat", Data + Environment.NewLine);
            }
        }
    }
}
