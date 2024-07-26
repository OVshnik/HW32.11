using Microsoft.AspNetCore.Http;
using MVCapp.Models.Db.Entity;
using MVCapp.Models.Db.Repository;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVCapp.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogRepository _repo;

        public LoggingMiddleware(RequestDelegate next, ILogRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);

            await AddLogInDB(context);

            await _next.Invoke(context);
        }
        public void LogConsole(HttpContext context)
        {
            Console.WriteLine($@"[{DateTime.Now}]:New request to http:\\{context.Request.Host.Value + context.Request.Path}");
        }
        public async Task AddLogInDB(HttpContext context)
        {
            var newRequest = new Request();
            newRequest.Url = $"http:\\{context.Request.Host.Value + context.Request.Path}";
            await _repo.AddRequest(newRequest);
        }
    }
}
