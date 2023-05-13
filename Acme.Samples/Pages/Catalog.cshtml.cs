using System.ComponentModel.DataAnnotations;
using Acme.Samples.Data;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Validation;

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

// TODO: add test for validate... use cases...add folder test
// agregar y editar para un child...
// se puede mejorar, removiendo este app service y teniendo solo el appservice para implementarlo en el controller y usar el repo para insertar en el controller.
// [Authorize]
public class CatalogEntityAppService : CrudAppService<CatalogEntity, CatalogEntityDto, int, CatalogFilter>, ICatalogEntityAppService
{
    private readonly ICatalogRepository _repository;

    public CatalogEntityAppService(ICatalogRepository repository) : base(repository)
    {
        _repository = repository;
    }
    public async Task<List<CatalogEntityChildDto>> GetChildAsync(string rootCode)
    {
        return await _repository.GetChildAsync(rootCode);
    }
    public async Task<List<CatalogEntityRootDto>> GetRootAsync()
    {
        return await _repository.GetRootAsync();
    }
    public async Task CreateRootAsync(CreateEntityRoot root)
    {
        await _repository.InsertRootAsync(root);
    }
    public async Task CreateChildAsync(string code, CreateEntityChild child)
    {
        await _repository.InsertChildAsync(code, child);
    }
    
    protected override async Task<IQueryable<CatalogEntity>> CreateFilteredQueryAsync(CatalogFilter input)
    {
        var data = await Repository.GetQueryableAsync();
        return data.Where(entity => entity.ParentCode == input.Code);
        // return data
        // .WhereIf(!string.IsNullOrEmpty(input.Code), entity => entity.Code == input.Code)
        // .WhereIf(!string.IsNullOrEmpty(input.Grouper), entity => entity.Grouper == input.Grouper)
        // .WhereIf(!string.IsNullOrEmpty(input.ParentCode), entity => entity.ParentCode == input.ParentCode)
        // ;
    }
}

public interface ICatalogEntityAppService : ICrudAppService<CatalogEntityDto, int, CatalogFilter>
{
    Task<List<CatalogEntityChildDto>> GetChildAsync(string code);
    Task<List<CatalogEntityRootDto>> GetRootAsync();
    Task CreateRootAsync(CreateEntityRoot root);
    Task CreateChildAsync(string code, CreateEntityChild child);
}

[Route("api/catalog")]
public class CatalogController:AbpController,ICatalogEntityAppService
{
    private readonly ICatalogEntityAppService _service;

    public CatalogController(ICatalogEntityAppService service)
    {
        _service = service;
    }   
    
    [HttpGet]
    [Route("{id}")]
    public Task<CatalogEntityDto> GetAsync([Required]int id)
    {
        return _service.GetAsync(id);
    }
    
    [HttpGet]
    public Task<PagedResultDto<CatalogEntityDto>> GetListAsync(CatalogFilter input)
    {
        return _service.GetListAsync(input);
    }
    [HttpPost]
    public Task<CatalogEntityDto> CreateAsync(CatalogEntityDto input)
    {
        return _service.CreateAsync(input);
    }
    
    [HttpPut]
    [Route("{id}")]
    public Task<CatalogEntityDto> UpdateAsync([Required]int id, CatalogEntityDto input)
    {
        return _service.UpdateAsync(id, input);
    }
    
    [HttpDelete]
    public Task DeleteAsync(int id)
    {
        return _service.DeleteAsync(id);
    }
    
    [HttpGet]
    [Route("child")]
    public Task<List<CatalogEntityChildDto>> GetChildAsync([Required]string code)
    {
        return _service.GetChildAsync(code);
    }
    
    [HttpGet]
    [Route("root")]
    public Task<List<CatalogEntityRootDto>> GetRootAsync()
    {
        return _service.GetRootAsync();
    }
    
    [HttpPost]
    [Route("root")]
    public Task CreateRootAsync(CreateEntityRoot root)
    {
        return _service.CreateRootAsync(root);
    }
    
    [HttpPost]
    [Route("child/{code}")]
    public Task CreateChildAsync([Required]string code, CreateEntityChild child)
    {
        return _service.CreateChildAsync(code, child);
    }
}

public class CatalogFilter : PagedAndSortedResultRequestDto
{
    [CanBeNull] public string Code { get; set; }
    [CanBeNull] public string Grouper { get; set; }
    [CanBeNull] public string ParentCode { get; set; }
}

public class CreateEntityChild
{
    [Required]
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }
    public string ExtraDescription { get; set; }
    public int DisplayOrder { get; set; }
}
public class CreateEntityRoot
{
    [Required]
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }
    public string ExtraDescription { get; set; }
    public int DisplayOrder { get; set; }
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

public class CatalogEntityRootDto
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string ExtraDescription { get; set; }
    public int DisplayOrder { get; set; }
}

public class CatalogEntityChildDto
{
    public string Code { get; set; }
    public string Description { get; set; }
    public string ExtraDescription { get; set; }
    public int DisplayOrder { get; set; }
}

// improve, changing code as pk string
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
        // if (!await _repository.AnyAsync())
        // {
        //     await _repository.InsertAsync(new CatalogEntity()
        //     {
        //         Code = nameof(TipoTributo),
        //         Description = "Tipo Tributo",
        //     });
        //     
        //     await _repository.InsertAsync(new CatalogEntity()
        //     {
        //         Code = nameof(TipoUnidadMedidaComercial),
        //         Description = "Tipo Unidad Medida Comercial"
        //     });
        //     
        //     await _repository.InsertManyAsync(TipoTributo.GetValues().Select(a => new CatalogEntity()
        //     {
        //         Code = a.Codigo,
        //         Description = a.Nombre,
        //         ExtraDescription = a.Descripcion,
        //         Grouper = nameof(TipoTributo),
        //         ParentCode = nameof(TipoTributo)
        //     }));
        //     
        //     await _repository.InsertManyAsync(TipoUnidadMedidaComercial.GetValues().Select(a => new CatalogEntity()
        //     {
        //         Code = a.Codigo,
        //         Description = a.Descripcion,
        //         Grouper = nameof(TipoUnidadMedidaComercial),
        //         ParentCode = nameof(TipoUnidadMedidaComercial),
        //     }));
        // }    
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

public class CatalogMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        context.Menu.Items.Insert(0,
            new ApplicationMenuItem("Washyn.Catalog.Module", "Catalog managment", "~/catalog"));
    }
}

public class CatalogRepository : EfCoreRepository<SamplesDbContext, CatalogEntity, int>, ICatalogRepository
{
    public CatalogRepository(IDbContextProvider<SamplesDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    
    public async Task<List<CatalogEntityRootDto>> GetRootAsync()
    {
        var items = await GetQueryableAsync();
        return await items
            .Where(a => string.IsNullOrEmpty(a.ParentCode))
            .Where(a => string.IsNullOrEmpty(a.Grouper))
            .Select(a => new CatalogEntityRootDto
            {
                Code = a.Code,
                DisplayOrder = a.DisplayOrder,
                Description = a.Description,
                ExtraDescription = a.ExtraDescription,
            })
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<List<CatalogEntityChildDto>> GetChildAsync(string rootCode)
    {
        var dbSet = await GetQueryableAsync();
        var root = dbSet.FirstOrDefault(a => a.Code == rootCode);
        if (root == null)
        {
            throw new EntityNotFoundException();
        }
        return await dbSet.Where(a => a.ParentCode == root.Code)
            .Select(a => new CatalogEntityChildDto
            {
                Code = a.Code,
                DisplayOrder = a.DisplayOrder,
                Description = a.Description,
                ExtraDescription = a.ExtraDescription,
            })
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task InsertRootAsync(CreateEntityRoot root)
    {
        var roots = await GetRootAsync();
        if (roots.Any(a => a.Code == root.Code))
        {
            throw new AbpValidationException(new List<ValidationResult>()
            {
                new ValidationResult("El codigo ya existe.", new []{nameof(CreateEntityRoot.Code)})
            });
        }
        await this.InsertAsync(new CatalogEntity()
        {
            Code = root.Code,
            Description = root.Description,
            ExtraDescription = root.ExtraDescription,
            DisplayOrder = root.DisplayOrder,
        });
    }
    public async Task InsertChildAsync(string rootCode, CreateEntityChild child)
    {
        var root = await this.FirstOrDefaultAsync(a => a.Code == rootCode);
        if (root == null)
        {
            throw new EntityNotFoundException();
        }

        var rootChilds = await GetChildAsync(rootCode);
        if (rootChilds.Any(a => a.Code == child.Code))
        {
            throw new AbpValidationException(new List<ValidationResult>()
            {
                new ValidationResult("El codigo ya existe.", new []{nameof(CreateEntityChild.Code)})
            });
        }
        
        await InsertAsync(new CatalogEntity()
        {
            Code = child.Code,
            Description = child.Description,
            ExtraDescription = child.ExtraDescription,
            DisplayOrder = child.DisplayOrder,
            ParentCode = root.Code,
            Grouper = $"{root.Code}.Child"
        });
    }
}

public interface ICatalogRepository : IRepository<CatalogEntity, int>
{
    Task<List<CatalogEntityRootDto>> GetRootAsync();
    Task<List<CatalogEntityChildDto>> GetChildAsync(string rootCode);
    Task InsertRootAsync(CreateEntityRoot root);
    Task InsertChildAsync(string rootCode, CreateEntityChild child);
}