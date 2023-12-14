using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp1.Models;

namespace WebApp1.Pages
{
    [Authorize(policy: "BestyrelsesRettigheder")]
    public class AddDocumentModel : PageModel
    {
        private DocumentModel document;
        private readonly IHttpClientFactory httpClientFactory;

        public AddDocumentModel(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //user.identity.name would be used, however it only works with authenticated users
            var client = httpClientFactory.CreateClient("apiClient");
            var appendUri = new Uri(client.BaseAddress, "/api/document");
            var response = await client.PostAsJsonAsync(appendUri, document);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
