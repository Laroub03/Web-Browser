using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebBrowser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the URL of the website, you want to enter:");
            string url = Console.ReadLine();

            try
            {
                string htmlContent = await GetWebPageContent(url);
                string textContent = RemoveHtmlTags(htmlContent);

                Console.WriteLine("\nText contents:");
                Console.WriteLine(textContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        // Gets Web Page Content using HttpClient
        static async Task<string> GetWebPageContent(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        // Removes Html tags using Regex
        static string RemoveHtmlTags(string html)
        {
            return Regex.Replace(html, "<.*?>", string.Empty);
        }
    }
}
    

