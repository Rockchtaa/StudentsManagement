using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentManagamentShared.StudentRepository;
using StudentsManagement.Client;
using StudentsManagement.Client.Repository;
using StudentsManagement.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();



builder.Services.AddScoped<IStudentRepository, StudentService>();
builder.Services.AddScoped<ICountryRepository, CountryService>();
builder.Services.AddScoped<ISystemCodeRepository, SystemCodeService>();
builder.Services.AddScoped<ISystemCodeDetailsRepository, SystemCodeDetailService>();
builder.Services.AddScoped<IParentRepository, ParentService>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!)
});

await builder.Build().RunAsync();
