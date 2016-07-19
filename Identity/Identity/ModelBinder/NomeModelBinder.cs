using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Identity.ModelBinder
{
    public class NomeModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var modelState = new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                actualValue = "Sr. " + valueResult.AttemptedValue;
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }
            //bindingContext.ModelState.Add( bindingContext.ModelName, modelState );
            return actualValue;
        }
    }
}