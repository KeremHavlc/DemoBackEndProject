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

//Autofac Kullanýmý için gerekli olan kodlar
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

//--------------------------------------------------------------------------------
//Bu kýsýmda her birini burada tanýmlamak yerine Autofac isimli kütüphaneyi kullandýk 
//Bu kýsýmda sadece bunu kullandýðýmýzý belirtmemiz yeterli olacaktýr.
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
