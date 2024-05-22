
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Tomnaia.Data;
using Tomnaia.Entities;
using Tomnaia.Helpers;
using Tomnaia.Interfaces;
using Tomnaia.Mapper;
using Tomnaia.Services.Mail;
using Tomnaia.Services.Services;
using Tomnaia.Services.Authentication;
using Tomnaia.IGenericRepository;
using Tomnaia.GenericRepository_UOW;

namespace Tomnaia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region Connection String
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Identity
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            //reset password
            builder.Services.Configure<DataProtectionTokenProviderOptions>
                (options => options.TokenLifespan = TimeSpan.FromHours(1));

            #endregion
            #region Firebase

            #endregion
            #region Add Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }
                ).AddJwtBearer(o =>
                {
                    o.IncludeErrorDetails = true;
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                        ValidAudience = builder.Configuration["JWT:ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                    };
                });
            #endregion

            #region Dependency Injection
            //builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IUserHelpers, UserHelpers>();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork >();
            builder.Services.AddScoped<IMailingService, MailingService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // builder.Services.AddTransient< IAuthService, AuthService>();
            //builder.Services.AddReposetoriesServices();
            #endregion

            #region mailing
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("Mailing"));
            builder.Services.Configure<IdentityOptions>(opts => opts.SignIn.RequireConfirmedEmail = true);
            #endregion
            #region swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo", Version = "v1" });
            });
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This?is?to?generate?the?Default?UI?of?Swagger?Documentation????
                swagger.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET?5?Web?API",
                    Description = " ITI Projrcy"
                });

                //?To?Enable?authorization?using?Swagger?(JWT)????
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter?'Bearer'?[space]?and?then?your?valid?token?in?the?text?input?below.\r\n\r\nExample:?\"Bearer?eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            #endregion
            #region Cors policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();

                });
            });
            #endregion
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
        }
    }
}