using System.Reflection;
using Application.Modules.Core.Interfaces;
using Application.Modules.Core.Persistence;
using Application.Modules.Users.Services;
using FluentValidation;
using HotChocolate.Data.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Entity Framework.
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services
    .AddPooledDbContextFactory<ApplicationDbContext>(
        options => options
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .EnableDetailedErrors(builder.Environment.IsDevelopment())
            .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
            .UseSnakeCaseNamingConvention());

// Fluent Validation.
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Hot Chocolate.
builder.Services
    .AddGraphQLServer()
    .InitializeOnStartup()
    .ModifyRequestOptions(
        options => options.IncludeExceptionDetails = builder.Environment.IsDevelopment())
    .AddConvention<IFilterConvention>(new FilterConvention(descriptor =>
    {
        descriptor
            .AddDefaults()
            .Configure<StringOperationFilterInputType>(d => d.Ignore(DefaultFilterOperations.Contains)) // no?
            .Configure<StringOperationFilterInputType>(d => d.Operation(DefaultFilterOperations.Contains).Ignore()); // no?
    }))
    .AddErrorInterfaceType<IUserError>()
    .AddMutationConventions()
    .RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
    .AddApplicationTypes()
    .AddQueryType()
    .AddMutationType()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

// ...scruter/extension method?
builder.Services.AddTransient<UserService>();

var app = builder.Build();

app.MapGraphQL();

await app.RunAsync();
