using System;
using Microsoft.AspNetCore.Mvc;
using SuperAwesome.AuthServer.Presentation.WebApi.Models;

namespace SuperAwesome.AuthServer.Presentation.WebApi.Services
{
    public sealed class RequestHandler<T>
    {
        public Response<T> Handle(Func<T> request)
        {
            try
            {
                return new Response<T>(request());
            }
            catch (Exception ex)
            {
                return new Response<T>(ex.Message);
            }
        }
    }
}
