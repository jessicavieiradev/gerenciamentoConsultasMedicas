using Microsoft.AspNetCore.Mvc;

namespace sistemaAgendamentoMedico.Controllers
{
    public abstract class BaseController<T> : ControllerBase
    {
        private ILogger<T>? _logger;

        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetRequiredService<ILogger<T>>()!;
    }
}
