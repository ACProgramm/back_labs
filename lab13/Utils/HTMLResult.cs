using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Utils
{
    public class HtmlResult : IActionResult
    {
        private string html;

        public HtmlResult(string html)
        {
            this.html = html;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            string fullHtmlCode = "<!DOCTYPE html><html><head>";
            fullHtmlCode += "<title>MainPage</title>"; 
            fullHtmlCode += "<meta charset=utf-8 />";
            fullHtmlCode += "</head> <body>";
            fullHtmlCode += html; 
            fullHtmlCode += "</body></html>";

            await context.HttpContext.Response.WriteAsync(fullHtmlCode);
        }
    }
}
