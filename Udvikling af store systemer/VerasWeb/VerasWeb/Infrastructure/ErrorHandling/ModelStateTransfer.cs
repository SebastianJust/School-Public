using Microsoft.AspNetCore.Mvc.Filters;

namespace VerasWeb.Infrastructure.ErrorHandling
{
    public abstract class ModelStateTransfer : ActionFilterAttribute
    {
        protected const string Key = nameof(ModelStateTransfer);
    }
}