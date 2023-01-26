using AutoMapper;
using EasyAbp.LoggingManagement.Web.EasyAbp.LoggingManagement.SystemLogs;
using Volo.Abp.AuditLogging;

namespace EasyAbp.LoggingManagement
{
    public class LoggingManagementApplicationAutoMapperProfile : Profile
    {
        public LoggingManagementApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<AuditLogDto, AuditLog>().ReverseMap();
        }
    }
}