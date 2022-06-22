using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Interxarifado.Repositories;

namespace Interxarifado

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IEstoqueRepository, EstoqueSqlRepository>();
            builder.Services.AddTransient<IFuncionarioRepository, FuncionarioSqlRepository>();
            builder.Services.AddTransient<IRequisicaoRepository, RequisicaoSqlRepository>();
            builder.Services.AddTransient<IProdutoRequisicaoRepository, ProdutoRequisicaoSqlRepository>();
            builder.Services.AddTransient<IResponsavelRepository, ResponsavelSqlRepository>();
            builder.Services.AddTransient<ISetoresRepository, SetoresSqlRepository>();
            builder.Services.AddSession();

            var app = builder.Build();
            app.UseSession();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }    
}