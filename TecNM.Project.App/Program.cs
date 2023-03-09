using TecNM.Project.App.Repositories;
using TecNM.Project.App.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IProductCategoryRepository, InMemoryProductCategoryRepository>();
builder.Services.AddSingleton<IArticleCategoryRepository, InMemoryArticleCategoryRepository>();
builder.Services.AddSingleton<IArticleRepository, InMemoryArticleRepository>();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<IImageRepository, InMemoryImageRepository>();
builder.Services.AddSingleton<IArticleSubCategoryRepository, InMemoryArticleSubCategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();