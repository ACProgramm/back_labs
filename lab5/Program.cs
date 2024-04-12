using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseFileServer(new FileServerOptions
{
    EnableDirectoryBrowsing = true,
    EnableDefaultFiles = false
});


app.Run();
