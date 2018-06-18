using AutoMapper;

namespace Contacts.Api.Http
{
    public static class AutoMapper
    {
        static bool isMapped = false;
        public static IMapper Mapper;

        public static void AutoMapClasses()
        {
            if (!isMapped)
            {
                MapClasses();
                isMapped = true;
            }
        }

        public static void MapClasses()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.Contact, Contacts.Model.Contact>();
                cfg.CreateMap<Contacts.Model.Contact, Model.Contact>();
            });

            Mapper = config.CreateMapper();
        }
    }
}