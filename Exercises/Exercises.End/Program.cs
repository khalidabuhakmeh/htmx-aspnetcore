using System.Security.Cryptography;
using Exercises.Models;
using Lib.AspNetCore.ServerSentEvents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// add dependencies to services collection
builder.Services.AddHttpClient();
builder.Services.AddRazorPages(o => {
    o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
}).AddRazorRuntimeCompilation();

// dependencies for server sent events
builder.Services.AddServerSentEvents();
builder.Services.AddHostedService<ServerEventsWorker>();

// define asp.net request pipeline
var app = builder.Build();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

// the connection for server events
app.MapServerSentEvents("/rn-updates");
app.MapRazorPages();

app.Run();