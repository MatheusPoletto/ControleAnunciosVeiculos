using System.ComponentModel;

namespace ControleVeicular.Web.Enums
{
    public static class Enum
    {
        public enum NotificationType
        {
            [Description("Erro!")]
            error,
            [Description("Sucesso!")]
            success,
            [Description("Atenção!")]
            warning,
            [Description("Info")]
            info
        }
        
    }
}
