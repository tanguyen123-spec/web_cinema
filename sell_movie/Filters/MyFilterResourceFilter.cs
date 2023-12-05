using Microsoft.AspNetCore.Mvc.Filters;
using System.Xml.Linq;

namespace sell_movie.Filters
{
    public class MyFilterResourceFilter : Attribute, IResourceFilter
    {
        private readonly string _name;

        public MyFilterResourceFilter(String name) 
        {
            _name = name;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Nguon bo loc  -Truoc {_name} ");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Nguon bo loc  -Sau {_name} ");
        }

    }
}
