using Bjay.Api.Host;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositoryLayer(builder.Configuration);

builder.Services.AddServiceLayer();

builder.Services.AddPresentationLayer();

var app = builder.Build();

app.UseExceptionHandler();
app.UseHsts();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerSetup();
}

app.UseHttpsRedirection();

app.MapVersionEndpoint();
app.MapAccountsEndpoints();
app.MapActivitiesEndpoint();

await app.RunAsync();

public partial class Program { }