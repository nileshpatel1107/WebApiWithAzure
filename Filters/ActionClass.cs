using Microsoft.AspNetCore.Mvc.Filters;

namespace NileshWebApi.Filters
{
    public class ActionClass : Attribute, IActionFilter
    {
        private readonly string? _name;
        public  ActionClass(string? name)
        {
            _name = name;
        }

        public ActionClass()
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting"+ _name);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted"+ _name);
        }


    }
}
