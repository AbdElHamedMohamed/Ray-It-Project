
using AutoMapper;
using BLL.Dapper;
using BLL.Helper.Filters;
using BLL.ResourceFiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		readonly string MyAllowSpecificOrigins = "CorsPolicy";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			#region Configure DataBase Connection String
			//services.AddDbContext<AppDbContext>(option =>
			//{
			//	option.UseOracle(Configuration.GetConnectionString("MasterConnection"));
			//});
			#endregion

			#region Configure Swagger UI
			services.AddSwaggerGen(c =>
			{
				var jwtSecurityScheme = new OpenApiSecurityScheme
				{
					Scheme = "bearer",
					BearerFormat = "JWT",
					Name = "JWT Authentication",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

					Reference = new OpenApiReference
					{
						Id = JwtBearerDefaults.AuthenticationScheme,
						Type = ReferenceType.SecurityScheme
					}
				};

				c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{ jwtSecurityScheme, Array.Empty<string>() }
				});
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "FasterApi", Version = "v1" });
			});
			#endregion

			#region Add Injection Scops
			services.AddScoped<IDapperService, DapperService>();
			#endregion

			#region Configure Cors
			services.AddCors(o =>
			{
				o.AddPolicy(name: MyAllowSpecificOrigins,
					builder =>
					{
						builder.AllowAnyOrigin()
					   .AllowAnyHeader().AllowAnyMethod();
					});
			});
			#endregion

			#region Disable Auto Validation
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});
			#endregion

			services.AddControllers();

			services.AddAutoMapper();

			#region Configure Bearer Token            
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(
				option =>
				{
					option.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ray-It Secret Key 2022")),
						ValidateIssuer = false,
						ValidateAudience = false,
					};
					option.Events = new JwtBearerEvents
					{
						OnAuthenticationFailed = async (context) =>
						{
							context.Response.StatusCode = 401;
							await context.Response.WriteAsync(Messages.UnAuthrized);
						}
					};
				});
			#endregion

			#region configure Filters
			services.AddControllers(config =>
			{
				config.Filters.Add(new LanguageFilter());
				config.Filters.Add(new CustomValidationResponseFilter());
			});
			#endregion
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseStaticFiles();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmacy v1"));
			}

			#region Configure the localization options
			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US")),
				SupportedCultures = new List<CultureInfo> { new CultureInfo("ar-SA"), new CultureInfo("en-US") },
				SupportedUICultures = new List<CultureInfo> { new CultureInfo("ar-SA"), new CultureInfo("en-US") }
			});
			#endregion

			app.UseHttpsRedirection();

			#region Exception Handler Middleware 
			app.UseExceptionHandler(c => c.Run(async context =>
			{
				var exception = context.Features
					.Get<IExceptionHandlerPathFeature>()
					.Error;
				var response = exception.Message;
				await context.Response.WriteAsJsonAsync(response);
			}));
			#endregion

			app.UseRouting();

			app.UseCors(MyAllowSpecificOrigins);
			app.UseAuthentication();            // Added For Authentication
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
