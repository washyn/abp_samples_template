using AutoMapper;
using EasyAbp.LoggingManagement.SystemLogs.Dtos;
using Volo.Abp.AuditLogging;

namespace EasyAbp.LoggingManagement.Web
{
    public class LoggingManagementWebAutoMapperProfile : Profile
    {
        public LoggingManagementWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AuditLog, SystemLogDto>()
                .ForMember(log => log.Time, expression => expression.MapFrom(dto => dto.ExecutionTime))
                .ForMember(log => log.Level, expression => expression.MapFrom(dto => dto.UserName))
                .ForMember(log => log.LogName, expression => expression.MapFrom(dto => dto.HttpMethod))
                .ForMember(log => log.LogValue, expression => expression.MapFrom(dto => dto.BrowserInfo));
            
            CreateMap<SystemLogDto,AuditLog>()
                .ForMember(log => log.ExecutionTime, expression => expression.MapFrom(dto => dto.Time))
                .ForMember(log => log.UserName, expression => expression.MapFrom(dto => dto.Level))
                .ForMember(log => log.HttpMethod, expression => expression.MapFrom(dto => dto.LogName))
                .ForMember(log => log.BrowserInfo, expression => expression.MapFrom(dto => dto.LogValue));
        }
    }
}