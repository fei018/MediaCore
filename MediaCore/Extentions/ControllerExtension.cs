using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WalkingTec.Mvvm.Mvc;

namespace MediaCore.Extentions
{
    public static class ControllerExtension
    {
        [NonAction]
        public static ViewResult ErrorView(this Controller controller, string error)
        {
            var viewData = new ViewDataDictionary<string>(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            viewData = new ViewDataDictionary<string>(viewData, error);

            ViewResult vr = new ViewResult
            {
                ViewName = "Error",
                ViewData = viewData,
            };

            return vr;
        }

        [NonAction]
        public static ViewResult ErrorView(this BaseController controller, string error)
        {
            var viewData = new ViewDataDictionary<string>(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            viewData = new ViewDataDictionary<string>(viewData, error);

            ViewResult vr = new ViewResult
            {
                ViewName = "Error",
                ViewData = viewData,
            };

            return vr;
        }
    }
}
