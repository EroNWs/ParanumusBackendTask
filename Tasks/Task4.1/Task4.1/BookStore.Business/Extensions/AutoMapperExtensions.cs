using BookStore.Business.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Business.Extensions;

public static class AutoMapperExtension
{
    public static void ConfigureAllDtoAutoMapper(this IServiceCollection services)
    {

        services.AddAutoMapper(typeof(BookProfile));

    }
}
