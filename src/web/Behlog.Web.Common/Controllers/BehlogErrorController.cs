using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Behlog.Services.Contracts.System;
using Behlog.Core.Extensions;
using Behlog.Services.Dto.System;
using Behlog.Web.Core.Models;

namespace Behlog.Web.Common.Controllers {

    /// <summary>
    /// Behlog ErrorController, use it to implement ErrorController 
    /// in End-user website project to catch and handle errors.
    /// </summary>
    public abstract class BehlogErrorController: Controller {

        private readonly IErrorLogService _errorLogService;

        public BehlogErrorController(IErrorLogService errorLogService) {
            errorLogService.CheckArgumentIsNull(nameof(errorLogService));
            _errorLogService = errorLogService;
        }

        private string _ReturnUrl {
            get {
                var routeVlaues = new RouteValueDictionary {
                    { "controller", "Home" },
                    { "action", "Index" }
                };
                return Url.RouteUrl(routeVlaues);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet(Name = "Error")]
        public async Task<IActionResult> Index() {
            IExceptionHandlerPathFeature handler = HttpContext
                .Features.Get<IExceptionHandlerPathFeature>();
            string message = "متاسفیم که عملیات با مشکل مواجه شده. بهتره به خانه برگردین! :)";

            if (handler != null) {
                string requestPath = handler.Path;
                Exception exception = handler.Error;
                var errorData = new CreateErrorLogDto {
                    Exception = exception,
                    StatusCode = 0,
                    RequestUrl = requestPath
                };

                try {
                    //If database is not availabe, we must catch exception and log error in a diffrent storage
                    await _errorLogService.CreateAsync(errorData);
                }
                catch (Exception ex) {
                    //Log error in another storage, 
                    //instead of Database, because database is not available.
                    Console.WriteLine($"Fatal-Error: {ex.GetBaseException().Message}");
                    return await Task.FromResult(
                        View(new ErrorViewModel {
                            Message = message,
                            Help = ex.GetBaseException().Message,
                            ReturnUrl = _ReturnUrl
                        })
                    );
                }

                var routeVlaues = new RouteValueDictionary {
                    { "controller", "Home" },
                    { "action", "Index" }
                };
                var model = new ErrorViewModel {
                    Message = message,
                    ReturnUrl = _ReturnUrl
                };

                return await Task.FromResult(View(model));
            }

            return await Task.FromResult(View());
        }

        [HttpGet("/Error/Status/{statusCode}")]
        public async Task<IActionResult> Status(int statusCode) {
            var iStatusCodeReExecuteFeature = HttpContext
                .Features.Get<IStatusCodeReExecuteFeature>();

            return await Task.FromResult(View("NotFound"));
        }
    }
}
