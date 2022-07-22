using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Akfny.Data;
using Repository;
using Data.Entities;
using Microsoft.OData.Edm;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

using AutoMapper;
using AkfnyServices.Mapping;
using AkfnyServices.MediatR.TrainerEntity.Commands;
using MediatR;
using AkfnyServices.Business;
using AkfnyData.Entities;
using AkfnyServices.MediatR.CourseEntity.Commands;
using AkfnyServices.MediatR.CourseSuggestionEntity.Commands;
using AkfnyServices.MediatR.TraineeEntity.Commands;
using AkfnyServices.Model;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AkfnyPresentation.Helper;

namespace AkfnyPresentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Country>("Country");
            odataBuilder.EntitySet<Nationality>("Nationality");
            odataBuilder.EntitySet<Course>("Course");
            odataBuilder.EntitySet<Lecturer>("Trainer");            
            odataBuilder.EntitySet<Trainer>("Trainee");
            odataBuilder.EntitySet<Course>("Course");
            odataBuilder.EntitySet<Sector>("Sector");
            odataBuilder.EntitySet<Field>("Field");
            odataBuilder.EntitySet<MajorInterest>("MajorInterest");
            odataBuilder.EntitySet<SubInterest>("SubInterest");
            odataBuilder.EntitySet<CourseTargeted>("CourseTargeteds");
            odataBuilder.EntitySet<CourseSuggestion>("CourseSuggestion");
            odataBuilder.EntitySet<ProfferStatu>("ProfferStatus");
            odataBuilder.EntitySet<NumberType>("NumberType");
            odataBuilder.EntitySet<Sex>("Sex");
            odataBuilder.EntitySet<City>("City");
            odataBuilder.EntitySet<QualificationDefine>("QualificationDefine");
            return odataBuilder.GetEdmModel();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            
            services.AddCors();
            services.AddControllersWithViews();
            services.AddOData();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddRazorPages();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddMediatR(typeof(AddCourseCommand).Assembly);
            services.AddMediatR(typeof(EditCourseCommand).Assembly);
            services.AddMediatR(typeof(AddCourseSuggestionCommand).Assembly);
            services.AddMediatR(typeof(EditCourseSuggestionCommand).Assembly);
            services.AddMediatR(typeof(ChangeCourseSuggestionCommand).Assembly);
            services.AddMediatR(typeof(AddLecturerCommand).Assembly);
            services.AddMediatR(typeof(EditLecturerCommand).Assembly);
            services.AddMediatR(typeof(ChangeLecturerStatusCommand).Assembly);
            services.AddMediatR(typeof(AddTraineeCommand).Assembly);
            services.AddMediatR(typeof(EditTraineeCommand).Assembly);
            services.AddMediatR(typeof(ChangeTraineeStatusCommand).Assembly);

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(ILecturerBusiness), typeof(LecturerBusiness));
            services.AddTransient(typeof(ITraineeBusiness), typeof(TraineeBusiness));
            services.AddTransient(typeof(ICourseBusiness), typeof(CourseBusiness));
            services.AddTransient(typeof(ICourseSuggestionBusiness), typeof(CourseSuggestionBusiness));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.Use(async (context, next) =>
            //{
            //    var token = context.Session.GetString("Token");
            //    if (!string.IsNullOrEmpty(token))
            //    {
            //        context.Request.Headers.Add("Authorization", "Bearer " + token);
            //    }
            //    await next();
            //});
            app.UseCors("cors");
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"UploadedFiles")),
                RequestPath = new PathString("/UploadedFiles")
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

   //         app.UseCors(builder => builder
   //   .WithOrigins("http://localhost:3000")
   //.AllowAnyMethod()
   //.AllowAnyHeader()
   //.AllowCredentials());

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.Select().Expand().Filter().OrderBy().Count().MaxTop(10);
                endpoints.MapODataRoute("odata", "odata", GetEdmModel());

            });

        }
    }
}
