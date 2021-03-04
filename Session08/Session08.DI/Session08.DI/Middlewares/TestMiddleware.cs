using Microsoft.AspNetCore.Http;
using Session08.DI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session08.DI.Middlewares
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPersonRepository _personRepository;
        private readonly PersonService _personService;

        public TestMiddleware(RequestDelegate next,IPersonRepository personRepository, PersonService personService)
        {
            _next = next;
            _personRepository = personRepository;
            _personService = personService;
        }
        public async Task Invoke(HttpContext httpContext, IEnumerable<int> list,IEnumerable<string> s)
        {
            var type = _personRepository.GetType();
            await httpContext.Response.WriteAsync($"{type.FullName}\n");
            await httpContext.Response.WriteAsync($"{_personService.GetType().FullName}\n");
           await _next(httpContext);
        }
    }
}
