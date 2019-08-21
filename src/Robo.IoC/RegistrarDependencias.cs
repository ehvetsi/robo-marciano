using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Robo.Aplicacao.Comandos;

namespace Robo.IoC
{
    public static class RegistrarDependencias
    {
        public static void Registrar(IServiceCollection servicos)
        {
            servicos.TryAddScoped<IMovimentarRobo, MovimentarRobo>();
        }
    }
}