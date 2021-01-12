using ControleVeicular.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using static ControleVeicular.Web.Enums.Enum;

namespace ControleVeicular.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        public void Alert(string message, NotificationType notificationType)
        {
            //@Html.Raw(TempData["notification"])
            var msg = "'" + notificationType.GetDescriptionAttr() + "', '" + message + "','" + notificationType + "'" + "";
            TempData["notification"] = msg;
        }
    }
}
