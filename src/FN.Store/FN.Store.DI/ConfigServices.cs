using FN.Store.Data.EF;
using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FN.Store.DI
{
    public static class ConfigServices
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Instancia única em todo o projeto
            // services.AddSingleton<>();

            // Por requisição
            // services.AddScoped<>();

            // Por chamada
            // services.AddTransient<>();


            services.AddScoped<StoreDataContext>();
            services.AddTransient<IProdutoRepository, ProdutoRepositoryEF>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryEF>();

        }
    }
}
