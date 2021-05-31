using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IoC
{
    public class SwaggerContainer
    {
        public static void RegisterSwagger(IServiceCollection services, string backendVersion)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = backendVersion,
                    Title = "Golden Question",
                    Description = "Golden Question Team",
                    Contact = new OpenApiContact
                    {
                        Name = "Hossein Kohzadi",
                        Email = "kohzadi_hossein@yahoo.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Golden Technique",
                        Url = new Uri("http://goldentechnique.ca/")
                    }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>()
                    }
                });
            });


            //Add Swagger Generator --------------------
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Swagger Demo",
            //        Description = "Swagger Demo - angular-netcore.ir",
            //        TermsOfService = new Uri("http://www.angular-netcore.ir"),
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Mohammad Moein Fazeli",
            //            Username = "mmfazeli372@gmail.com",
            //            Url = new Uri("http://www.angular-netcore.ir")
            //        }
            //    });
            //    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //    //{
            //    //    Description = "JWT Authorization header {token}",
            //    //    Name = "Authorization",
            //    //    In = ParameterLocation.Header,
            //    //    Type = SecuritySchemeType.ApiKey
            //    //});
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "Bearer"
            //                },
            //                Scheme = "oauth2",
            //                Name = "Bearer",
            //                In = ParameterLocation.Header,

            //            },
            //            new List<string>()
            //        }
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {new OpenApiSecurityScheme(), new List<string>()}
            //    });
            //});
            //------------------------------
        }
    }
}