using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace FirstApplicationClass.CustomValidationAttribute
{
    public class ValidationModel: ActionFilterAttribute {


        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestResult();
            }
            base.OnActionExecuted(context);
        }
    
    }

}

