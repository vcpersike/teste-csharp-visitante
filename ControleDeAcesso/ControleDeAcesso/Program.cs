using ControleDeAcesso;
using Departamento;
using Departamento.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using Visitante;
using Visitante.BLL;
using Visitante.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDepartamentoBLL, DepartamentoBLL>();
builder.Services.AddScoped<IDepartamentoDAL, DepartamentoDAL>();
builder.Services.AddScoped<IVisitanteBLL, VisitanteBLL>();
builder.Services.AddScoped<IVisitanteDAL, VisitanteDAL>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.TagActionsBy(api => api.HttpMethod);
    c.OrderActionsBy(api => api.RelativePath);
});

builder.Services.Configure<Config>(builder.Configuration.GetSection("Config"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.DefaultModelRendering(ModelRendering.Example);
        c.DefaultModelExpandDepth(0);
        c.DefaultModelsExpandDepth(-1);
        c.DocExpansion(DocExpansion.None);
        c.SupportedSubmitMethods(new[] { SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Delete });
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
