using ThirdPartyApiInteraction.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient("First API", httpClient => httpClient.BaseAddress = new("http://localhost:5132"));
builder.Services.AddHttpClient("Second API", httpClient => httpClient.BaseAddress = new("http://localhost:5016"));
builder.Services.AddHttpClient<HttpClientWrapperClass>(httpClient => httpClient.BaseAddress = new("http://localhost:5132"));

builder.Services.AddTransient<FirstMiddleware>();
builder.Services.AddTransient<SecondMiddleware>();
builder.Services.AddHttpClient("HttpClient with Middleware", httpClient => httpClient.BaseAddress = new("http://localhost:5016"))
       .AddHttpMessageHandler<FirstMiddleware>()
       .AddHttpMessageHandler<SecondMiddleware>();

builder.Services.AddHttpClient<InterfereByHttpClientWrapperClass>(httpClient => httpClient.BaseAddress = new("http://localhost:5016"));

builder.Services.AddHttpClient("InterfereWithHttpClientExtension", httpClient => httpClient.BaseAddress = new("http://localhost:5132"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
