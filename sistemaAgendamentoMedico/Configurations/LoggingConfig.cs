using Serilog;

namespace sistemaAgendamentoMedico.Configurations
{
    public static class LoggingConfig
    {
        public static void AddSerigLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Debug()
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}
