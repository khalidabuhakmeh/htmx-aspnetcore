using Exercises.Models;
using Lib.AspNetCore.ServerSentEvents;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// add dependencies to services collection
builder.Services.AddHttpClient();
builder.Services.AddRazorPages(o => {
    // this is to make demos easier
    // don't do this in production
    o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
}).AddRazorRuntimeCompilation();

// dependencies for server sent events
// Lib.AspNetCore.ServerSentEvents
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