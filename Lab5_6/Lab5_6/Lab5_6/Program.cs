using Lab5_6.Data;
using Lab5_6.Mappings;
using Lab5_6.Repository;
using Lab5_6.Repository.Impl;
using Lab5_6.Services.Impl;
using Lab5_6.Services;
using Microsoft.EntityFrameworkCore;

namespace Lab5_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var Configuration = builder.Configuration;
            builder.Services.AddDbContext<PatientInfoContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IPatientService, PatientService>();

            builder.Services.AddAutoMapper(typeof(PatientProfile));
            builder.Services.AddAutoMapper(typeof(DiagnosisProfile));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}