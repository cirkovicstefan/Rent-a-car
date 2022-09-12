using Business.Abstract;
using Business.Concrate;
using Core.Utilities.Security.JWT;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProizvodjacAutomobilaService, ProizvodjacAutomobilaManager>();
builder.Services.AddScoped<IProizvodjacDal, EfProizvodjacDal>();
builder.Services.AddScoped<IModelAutomobilaService, ModelAutomobilaManager>();
builder.Services.AddScoped<IModelAutomobilaDal, EfModelAutomobilaDal>();
builder.Services.AddScoped<IAutomobilService, AutomobilManager>();
builder.Services.AddScoped<IAutomobilDal, EfAutomobilDal>();
builder.Services.AddScoped<IKorisnikService, KorisnikManager>();
builder.Services.AddScoped<IKorisnikDal, EfKorisnikDal>();

builder.Services.AddScoped<IRezervacijaAutomobilaService, RezervacijaAutomobilaManager>();
builder.Services.AddScoped<IRezervacijaAutomobilaDal, EfRezervacijaAutomobilaDal>();
builder.Services.AddScoped<ICenaIznajmljivanjaPoDanuService, CenaIznajmljivanjaPoDanuMenager>();
builder.Services.AddScoped<ICenaPoDanuDal, EfCenaIznajmljivanjaPoDanuDal>();
builder.Services.AddScoped<IUgovorIznajmljivanjaDal, EfUlovorIznajmljivanjaDal>();
builder.Services.AddScoped<IUgovorIznajmljivanjaService, UgovorIznajmljivanjaMenager>();
builder.Services.AddScoped<IIstorijaIznajmljivanjaDal, EfIstorijaIznajmljivanjaDal>();
builder.Services.AddScoped<IIstorijaIznajmljivanjaService, IstorijaIznajmljivanjaMenager>();

builder.Services.AddScoped<IAuthService, AuthManager>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();
builder.Services.AddScoped<ISlikaAutomobilaDal, EfSlikaAutomobilaDal>();
builder.Services.AddScoped<ISlikeAutomobilaService, SlikeAutomobilaManager>();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));
builder.Services.AddCors();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()
                                                 .AllowAnyMethod()
                                                 .AllowAnyHeader());
});

var app = builder.Build();








// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options => options.
                                         AllowAnyMethod()
                                          .AllowAnyHeader()
                                          .AllowCredentials()
                                          .SetIsOriginAllowed((host) => true)

                                          );

app.UseCors("CorsPolicy");

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"upload_images")),
    RequestPath = new PathString("/upload_images")
});
app.UseAuthorization();

app.MapControllers();

app.Run();
