using Microsoft.OpenApi.Models;
using WebApi.Data.Repository;
using WebApi.Business;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region :: Acesso a Dados / Dapper ::
builder.Services.AddTransient<ApiDAO>();
#endregion

#region :: Business ::
builder.Services.AddTransient<ApiBusiness>();
#endregion

#region :: Swagger ::
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    });
}
#endregion

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
