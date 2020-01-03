namespace Samples.Http.TestAPI.Results
{
    using System.Net;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Core;
    using Microsoft.AspNetCore.Mvc;
    using System.Net.Mime;

    public class MyBadRequestResult : OkResult
    {
        private readonly string[] _reasons;
        
        private readonly string _strBody = string.Empty;

        public MyBadRequestResult(string[] reasons, object body)
        : this(reasons)
        {
            if (body != null)
            {
                _strBody = JsonConvert.SerializeObject(body);
            }
        }

        public MyBadRequestResult(string[] reasons)
        {
            _reasons = reasons;
        }

        public override async System.Threading.Tasks.Task ExecuteResultAsync(ActionContext context)
        {
            base.ExecuteResult(context);
            
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;

            context.HttpContext.Response.Headers.Add(HttpHeaders.ReasonHeader, _reasons);

            context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;

            await context.HttpContext.Response.WriteAsync(_strBody, Encoding.UTF8);
        }
    }
}