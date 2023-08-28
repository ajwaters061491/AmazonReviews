using AmazonReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AmazonReviews.Pages
{
    public class IndexModel : PageModel
    {
        private readonly string fullPath = "https://localhost:5001/api/ReviewsController/Generate";
        static HttpClient HttpClient = new HttpClient();
        [BindProperty]
        public Reviews Reviews { get; set; }

        public async Task OnGet()
        {
            Reviews = new Reviews();
        }

        public async Task <IActionResult> OnPost()
        {
            //API GET to the Generate endpoint in the ReviewsController 
            HttpResponseMessage response = await HttpClient.GetAsync(fullPath);
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();

                Reviews = JsonConvert.DeserializeObject<Reviews>(jsonContent);
            } else
            {
                Console.WriteLine(response.StatusCode);
            }
            return Page();
        }
    }
}