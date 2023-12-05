﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace sell_movie.Filters
{
    public class MyFilterAtribute : Attribute, IActionFilter,IOrderedFilter
    { 
        private readonly string _name;

        public int Order { get; set; }

        public MyFilterAtribute(string name, int order = 0 ) { 
        _name=name;
            Order = order;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Bo loc khoi dong -Truoc {_name} {Order}");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Bo loc khoi dong - sau-{_name} {Order}");

        }

       
    }
}
