using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

//Autofac Kullan�m� i�in gerekli olan kodlar
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

//--------------------------------------------------------------------------------
//Bu k�s�mda her birini burada tan�mlamak yerine Autofac isimli k�t�phaneyi kulland�k 
//Bu k�s�mda sadece bunu kulland���m�z� belirtmemiz yeterli olacakt�r.
//builder.Services.AddSingleton<IOperationClaimService, OperationClaimManager>();
//builder.Services.AddSingleton<IOperationClaimDal, EfOperationClaimDal>();
//--------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
