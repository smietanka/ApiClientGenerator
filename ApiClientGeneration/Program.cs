using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiClientGeneration;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            });
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "ApiClient Service",
                Version = "v1",
            });
        });


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.EnableDeepLinking();
            });
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
