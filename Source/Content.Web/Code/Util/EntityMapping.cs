using AutoMapper;
//
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Util
{
    public class EntityMapping
    {
        public static void ConfigureAutomapper()
        {
            Mapper.CreateMap<DataAccess.Sql.Dbml.HtmlContent, HtmlContent>() // Repository => Domain
                .ForMember(d => d.AvailableTransitions, o => o.Ignore())
                .ForMember(d => d.ApplicationId, o => o.Ignore())
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.CreatedDate, o => o.Ignore())
                .ForMember(d => d.IsExpired, o => o.Ignore())
                .ForMember(d => d.ItemStateMachineState, o => o.Ignore())
                .ForMember(d => d.OwnerUserId, o => o.Ignore());
            Mapper.CreateMap<HtmlContent, HtmlContent>() // Domain => Domain
                .ForMember(d => d.Application, o => o.Ignore())
                .ForMember(d => d.ApplicationId, o => o.Ignore())
                .ForMember(d => d.ContentData, o => o.ResolveUsing<Resolvers.HtmlContent>().FromMember(s => s.ContentData))
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.CreatedDate, o => o.Ignore());
            Mapper.CreateMap<HtmlContent, DataAccess.Sql.Dbml.HtmlContent>() // Domain => Repository
                .ForMember(d => d.Application, o => o.Ignore())
                .ForMember(d => d.ApplicationId, o => o.Ignore())
                .ForMember(d => d.ItemState, o => o.MapFrom(s => (int)s.ItemState))
                .ForMember(d => d.CreatedBy, o => o.Ignore())
                .ForMember(d => d.CreatedDate, o => o.Ignore());

            Mapper.AssertConfigurationIsValid();
        }
    }
}
