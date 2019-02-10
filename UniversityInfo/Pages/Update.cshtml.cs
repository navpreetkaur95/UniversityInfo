using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UniversityInfo.Pages
{
    public class UpdatedModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            string Name = Request.QueryString.Value;
            if (Name == null){
            	Message = "Deleted";
            }
            else{
                // System.IO.File.AppendAllText("data.txt",Name + Environment.NewLine);
            }
        }
    }
}
