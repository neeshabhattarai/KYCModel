using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FirstApplicationClass;

public class ConfigureSwaggerGen : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider provider;

    public ConfigureSwaggerGen(IApiVersionDescriptionProvider provider)
    {
        this.provider = provider;
    }
    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }

    public void Configure(SwaggerGenOptions options)
    {
       foreach(var descriptor in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(descriptor.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Api Versoning",
                Description = descriptor.GroupName.ToUpperInvariant()
            });
        }
    }
}

