namespace SimpleBookList.BLL.Infrastructure
{
    using AutoMapper;

    /// <summary>
    /// AutoMapper Configuration
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static MapperConfiguration Configuration { get; private set; }

        /// <summary>
        /// 
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