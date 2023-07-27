namespace PlaneSpotterApi.Extensions
{
    public static class CorsExtension
    {
        /// <summary>
        /// Adding cors policy. Unless the client won't be able to get access api methods same origin policy.
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
    }
}
