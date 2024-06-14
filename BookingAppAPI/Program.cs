using System.Text;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;



using Repository.JwtRepository;
using Repository.UserRepository;

using Repository.CommentRepository;
using Repository.RepositoryHotel;
using Repository.ReviewRepository;
using Repository.CompliantBookRepository;
using Repository.RatingRepository;
using Repository.MediaRepository;
using Repository.DataTypeRepository;

using Service.CommentService;
using Service.ServiceHotel;
using Service.ReviewService;
using Service.CompliantBookService;
using Service.RatingService;
using Service.MediaService;
using Service.DataTypeService;
using Service.UserService;
using Service.JwtService;


using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;





var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")); //  Постройка связи моделей с базой данных DefaultConnection
});
builder.Services.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));  // Добавление в зону видимости программы репозитория книг для возможности управлени содержимым в нем через сервис книг
builder.Services.AddTransient<ICommentService, CommentService>(); // Добавление в зону видимости программы сервиса книг для управления содержимым репозитория книг
builder.Services.AddScoped(typeof(IRepositoryHotel), typeof(RepositoryHotel));
builder.Services.AddTransient<IServiceHotel, ServiceHotel>();
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddScoped(typeof(ICompliantBookRepository), typeof(CompliantBookRepository));
builder.Services.AddTransient<ICompliantBookService, CompliantBookService>();
builder.Services.AddScoped(typeof(IRatingRepository), typeof(RatingRepository));
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddScoped(typeof(IMediaRepository), typeof(MediaRepository));
builder.Services.AddTransient<IMediaService, MediaService>();
builder.Services.AddScoped(typeof(IDataTypeRepository), typeof(DataTypeRepository));
builder.Services.AddTransient<IDataTypeService, DataTypeService>();
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped(typeof(IJwtRepository), typeof(JwtRepository));
builder.Services.AddTransient<IJwtService, JwtService>();




builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.UseSecurityTokenValidators = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = "bookapilan",
            ValidIssuer = "bookapilan",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("8b0fa5c39bcc9d22a9d4c8d42ba40fd73c85488b4c43d74b1b26122fe4301700"))
        };
    });

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    }); 
});






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();