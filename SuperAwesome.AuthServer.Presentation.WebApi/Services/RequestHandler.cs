using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAwesome.AuthServer.Presentation.WebApi.Models;

namespace SuperAwesome.AuthServer.Presentation.WebApi.Services
{
    public sealed class RequestHandler<T>
    {
        public async Task<Response<T>> HandleAsync(Func<Task<T>> request)
        {
            try
            {
                return new Response<T>(await request());
            }
            catch (Exception ex)
            {
                return new Response<T>(ex.Message);
            }
        }
    }
}
