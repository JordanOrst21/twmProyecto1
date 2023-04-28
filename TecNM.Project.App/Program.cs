using Dapper;
using Dapper.Contrib.Extensions;
using TecNM.Project.App.DataAccess;
using TecNM.Project.App.DataAccess.Interfaces;
using TecNM.Project.App.Repositories;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services;
using TecNM.Project.App.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IProductCategoryRepository, InMemoryProductCategoryRepository>();
//builder.Services.AddSingleton<IArticleCategoryRepository, ArticleCategoryRepositories>();
//builder.Services.AddSingleton<IArticleRepository, ArticleRepositories>();
//builder.Services.AddSingleton<IUserRepository, UserRepositories>();
//builder.Services.AddSingleton<IImageRepository, ImageRepositories>();
//builder.Services.AddSingleton<IArticleSubCategoryRepository, ArticleSubCategoryRepositories>();

//Ahora con interfaces y services
// builder.Services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepositories>();
// builder.Services.AddScoped<IArticleRepository, ArticleRepositories>();
// builder.Services.AddScoped<IUserRepository, UserRepositories>();
// builder.Services.AddScoped<IImageRepository, ImageRepositories>();
builder.Services.AddScoped<IArticleSubCategoryRepository, ArticleSubCategoryRepositories>();
builder.Services.AddScoped<IArticleRepository, ArticleRepositories>();
builder.Services.AddScoped<IArticleSubCategoryService, ArticleSubCategoryService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepositories>();
builder.Services.AddScoped<IImageRepository, ImageRepositories>();
builder.Services.AddScoped<IUserRepository, UserRepositories>();
builder.Services.AddScoped<IArticleCategoryService, ArticleCategoryService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IDbContext, DbContext>();
//Singleton es generador de instancias
//Con AddSconped se pierde
SqlMapperExtensions.TableNameMapper = entityType =>
{
    var name = entityType.ToString();
    if (name.Contains("TecNM.Project.Core.Entities."))
        name = name.Replace("TecNM.Project.Core.Entities.", "");
    var letters = name.ToCharArray();
    letters[0] = char.ToUpper(letters[0]);
    return new string(letters);
};

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