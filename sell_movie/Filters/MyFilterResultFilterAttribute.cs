using Microsoft.AspNetCore.Mvc.Filters;

namespace sell_movie.Filters
{
    public class MyFilterResultFilterAttribute : Attribute, IResultFilter
    {
        private readonly ILogger<MyFilterResultFilterAttribute> _logger;

        public MyFilterResultFilterAttribute(ILogger<MyFilterResultFilterAttribute> logger)
        {
            _logger = logger;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("Ket qua bo loc - sau");
         }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("Ket qua bo loc - truoc");
        }
    }
}
