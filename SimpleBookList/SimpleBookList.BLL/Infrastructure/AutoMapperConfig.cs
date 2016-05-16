namespace SimpleBookList.BLL.Infrastructure
{
    using AutoMapper;

    /// <summary>
    /// AutoMapper Configuration
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Gets or Sets Automapper Configuration
        /// </summary>
        public static MapperConfiguration Configuration { get; private set; }

        /// <summary>
        /// Register Mappings Configuration
        /// </summary>
        public static void RegisterMappings()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
        }
    }
}