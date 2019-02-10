using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UniversityInfo.Pages
{
    public class DeleteModel : PageModel
    {
        public string Message { get; set; }
        public string[] existingInfo;
        public string[] localData = new string[4];

        public List<string> roll = new List<string> { };
        public List<string> name = new List<string> { };
        public List<string> city = new List<string> { };
        public List<string> phone = new List<string> { };
        public int toDelete = 0;

        public void OnGet()
        {
            string ID = Request.QueryString.Value;
            if (ID == null){
            	Message = "Deleted";
            }
            else{

                existingInfo = System.IO.File.ReadAllLines("data.dat");

                foreach (var line in existingInfo)
                {
                    localData = line.Split(",");

                    roll.Add(localData[1]);
                    name.Add(localData[2]);
                    city.Add(localData[3]);
                    phone.Add(localData[4]);
                }

               int counter = 0;
               foreach (string id in roll)
                {
                    if (id==ID.Split("=")[1])
                    {
                        toDelete = counter;
                        break;
                    }
                    counter++;
                }
                
                if (toDelete == counter)
                {
                    Message = "Success! Go to Manage Data to view this update.";
                    List<string> lines = System.IO.File.ReadAllLines("data.dat").ToList();
                    lines.RemoveAt(counter);
                    System.IO.File.WriteAllLines("data.dat", lines);
                }
                else
                {
                    Message = "No such enrollment no. exists! Attempt failed.";
                }

            }
        }
    }
}
