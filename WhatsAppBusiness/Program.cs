using Microsoft.OpenApi.Models;
using WhatsAppBusiness.Services.ClientService.IServices;
using WhatsAppBusiness.Services.ClientService.Services;
using WhatsAppBusiness.Services.DCServices.IServices;
using WhatsAppBusiness.Services.DCServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WhatsApp APIs",
        Version = "v1",
        Description = "An APIs to performs WhatsApp site operations",
    });
});
builder.Services.AddHttpContextAccessor();
//Register Client
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IClientService, ClientService>();
//Register Services
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IMessageService, MessageService>();


var app = builder.Build();
//Add Dependence Injection 
app.UseSwagger(x => x.SerializeAsV2 = true);
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WhatsApp API V1");
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Message}/{action=Index}/{id?}");

app.Run();
