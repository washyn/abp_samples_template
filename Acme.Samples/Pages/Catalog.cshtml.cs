using System.ComponentModel.DataAnnotations;
using Acme.Samples.Select;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;

namespace Acme.Samples.Pages;
// TODO: add grouper for selects
public class Catalog : PageModel
{
    public void OnGet()
    {
        
    }
}

public class CatalogModule : AbpModule
{
    
}

// agregar y editar para un child...
public class CatalogEntityAppService : CrudAppService<CatalogEntity, CatalogEntityDto, int, CatalogFilter>
{
    public CatalogEntityAppService(IRepository<CatalogEntity, int> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<CatalogEntity>> CreateFilteredQueryAsync(CatalogFilter input)
    {
        var data = await Repository.GetQueryableAsync();
        return data.Where(entity => entity.ParentCode == input.Code);
        // return data.WhereIf(!string.IsNullOrEmpty(input.Code), entity => entity.Code == input.Code);
    }
    
    // public async Task<PagedResultDto<CatalogEntityDto>> GetListParentsAsync(CatalogFilter input)
    // {
    //     var queryab = await Repository.GetQueryableAsync();
    //     var data = queryab.Where(a => a.ParentCode == null
    //                                   || a.ParentCode == "");
    //     var count = data.LongCount();
    //     var dataResult = await data.ToListAsync();
    //     return new PagedResultDto<CatalogEntityDto>(count, ObjectMapper.Map<List<CatalogEntity>, List<CatalogEntityDto>>(dataResult));
    // }
}

public class CatalogFilter : PagedAndSortedResultRequestDto
{
    [CanBeNull] public string Code { get; set; }

    // public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
    //     base.Validate(validationContext);
    //     if (string.IsNullOrEmpty(Code))
    //     {
    //         Code = "";
    //     }
    //     return new List<ValidationResult>();
    // }
}

public class CatalogEntityDto : EntityDto<int>
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string Grouper { get; set; }
    public string ParentCode { get; set; }
    public string ExtraDescription { get; set; }
    public int DisplayOrder { get; set; }
}

public class CatalogEntity : Entity<int>
{
    public string Code { get; set; }
    public string Description { get; set; }
    /// <summary>
    /// Agrupador para motrar todos los de este codigo en un select.
    /// </summary>
    public string Grouper { get; set; }
    public string ParentCode { get; set; }
    public string ExtraDescription { get; set; }
    public int DisplayOrder { get; set; }
}

public class CatalogDataSeed : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<CatalogEntity, int> _repository;

    public CatalogDataSeed(IRepository<CatalogEntity, int> repository)
    {
        _repository = repository;
    }
    
    public async Task SeedAsync(DataSeedContext context)
    {
        if (!await _repository.AnyAsync())
        {
            await _repository.InsertAsync(new CatalogEntity()
            {
                Code = nameof(TipoTributo),
                Description = "Tipo Tributo",
            });
            
            await _repository.InsertAsync(new CatalogEntity()
            {
                Code = nameof(TipoUnidadMedidaComercial),
                Description = "Tipo Unidad Medida Comercial"
            });
            
            await _repository.InsertManyAsync(TipoTributo.GetValues().Select(a => new CatalogEntity()
            {
                Code = a.Codigo,
                Description = a.Nombre,
                ExtraDescription = a.Descripcion,
                Grouper = nameof(TipoTributo),
                ParentCode = nameof(TipoTributo)
            }));
            
            await _repository.InsertManyAsync(TipoUnidadMedidaComercial.GetValues().Select(a => new CatalogEntity()
            {
                Code = a.Codigo,
                Description = a.Descripcion,
                Grouper = nameof(TipoUnidadMedidaComercial),
                ParentCode = nameof(TipoUnidadMedidaComercial),
            }));
        }    
    }
}

public class AcmeMapperProfile : Profile
{
    public AcmeMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CatalogEntity, CatalogEntityDto>().ReverseMap();
        CreateMap<CatalogEditViewModel, CatalogEntityDto>().ReverseMap();
        CreateMap<CreateCatalogViewModel, CatalogEntityDto>().ReverseMap();
    }
}