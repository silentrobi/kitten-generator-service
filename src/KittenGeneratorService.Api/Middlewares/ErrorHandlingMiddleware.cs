using KittenGeneratorService.Api.Responses;
using KittenGeneratorService.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace KittenGeneratorService.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ErrorResponse() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case ValidationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        break;
                    case ItemNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        break;
                    case UserAuthenticationFailException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        break;
                    case ExternalServiceException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Message = e.Message;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
