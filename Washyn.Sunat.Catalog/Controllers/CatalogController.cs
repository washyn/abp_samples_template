using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Washyn.Abp.Select2;

namespace Washyn.Sunat.Catalog.Controllers;


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C01")]
public class C01Controller : AbpController, IC01AppService
{
    private IC01AppService _C01AppService;

    public C01Controller(IC01AppService appService)
    {
        _C01AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C01AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C01AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C02")]
public class C02Controller : AbpController, IC02AppService
{
    private IC02AppService _C02AppService;

    public C02Controller(IC02AppService appService)
    {
        _C02AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C02AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C02AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C03")]
public class C03Controller : AbpController, IC03AppService
{
    private IC03AppService _C03AppService;

    public C03Controller(IC03AppService appService)
    {
        _C03AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C03AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C03AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C04")]
public class C04Controller : AbpController, IC04AppService
{
    private IC04AppService _C04AppService;

    public C04Controller(IC04AppService appService)
    {
        _C04AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C04AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C04AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C05")]
public class C05Controller : AbpController, IC05AppService
{
    private IC05AppService _C05AppService;

    public C05Controller(IC05AppService appService)
    {
        _C05AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C05AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C05AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C06")]
public class C06Controller : AbpController, IC06AppService
{
    private IC06AppService _C06AppService;

    public C06Controller(IC06AppService appService)
    {
        _C06AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C06AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C06AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C07")]
public class C07Controller : AbpController, IC07AppService
{
    private IC07AppService _C07AppService;

    public C07Controller(IC07AppService appService)
    {
        _C07AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C07AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C07AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C08")]
public class C08Controller : AbpController, IC08AppService
{
    private IC08AppService _C08AppService;

    public C08Controller(IC08AppService appService)
    {
        _C08AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C08AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C08AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C09")]
public class C09Controller : AbpController, IC09AppService
{
    private IC09AppService _C09AppService;

    public C09Controller(IC09AppService appService)
    {
        _C09AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C09AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C09AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C10")]
public class C10Controller : AbpController, IC10AppService
{
    private IC10AppService _C10AppService;

    public C10Controller(IC10AppService appService)
    {
        _C10AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C10AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C10AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C11")]
public class C11Controller : AbpController, IC11AppService
{
    private IC11AppService _C11AppService;

    public C11Controller(IC11AppService appService)
    {
        _C11AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C11AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C11AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C12")]
public class C12Controller : AbpController, IC12AppService
{
    private IC12AppService _C12AppService;

    public C12Controller(IC12AppService appService)
    {
        _C12AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C12AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C12AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C14")]
public class C14Controller : AbpController, IC14AppService
{
    private IC14AppService _C14AppService;

    public C14Controller(IC14AppService appService)
    {
        _C14AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C14AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C14AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C15")]
public class C15Controller : AbpController, IC15AppService
{
    private IC15AppService _C15AppService;

    public C15Controller(IC15AppService appService)
    {
        _C15AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C15AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C15AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C16")]
public class C16Controller : AbpController, IC16AppService
{
    private IC16AppService _C16AppService;

    public C16Controller(IC16AppService appService)
    {
        _C16AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C16AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C16AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C17")]
public class C17Controller : AbpController, IC17AppService
{
    private IC17AppService _C17AppService;

    public C17Controller(IC17AppService appService)
    {
        _C17AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C17AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C17AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C18")]
public class C18Controller : AbpController, IC18AppService
{
    private IC18AppService _C18AppService;

    public C18Controller(IC18AppService appService)
    {
        _C18AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C18AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C18AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C19")]
public class C19Controller : AbpController, IC19AppService
{
    private IC19AppService _C19AppService;

    public C19Controller(IC19AppService appService)
    {
        _C19AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C19AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C19AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C20")]
public class C20Controller : AbpController, IC20AppService
{
    private IC20AppService _C20AppService;

    public C20Controller(IC20AppService appService)
    {
        _C20AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C20AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C20AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C21")]
public class C21Controller : AbpController, IC21AppService
{
    private IC21AppService _C21AppService;

    public C21Controller(IC21AppService appService)
    {
        _C21AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C21AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C21AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C22")]
public class C22Controller : AbpController, IC22AppService
{
    private IC22AppService _C22AppService;

    public C22Controller(IC22AppService appService)
    {
        _C22AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C22AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C22AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C23")]
public class C23Controller : AbpController, IC23AppService
{
    private IC23AppService _C23AppService;

    public C23Controller(IC23AppService appService)
    {
        _C23AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C23AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C23AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C24")]
public class C24Controller : AbpController, IC24AppService
{
    private IC24AppService _C24AppService;

    public C24Controller(IC24AppService appService)
    {
        _C24AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C24AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C24AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C26")]
public class C26Controller : AbpController, IC26AppService
{
    private IC26AppService _C26AppService;

    public C26Controller(IC26AppService appService)
    {
        _C26AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C26AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C26AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C27")]
public class C27Controller : AbpController, IC27AppService
{
    private IC27AppService _C27AppService;

    public C27Controller(IC27AppService appService)
    {
        _C27AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C27AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C27AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C51")]
public class C51Controller : AbpController, IC51AppService
{
    private IC51AppService _C51AppService;

    public C51Controller(IC51AppService appService)
    {
        _C51AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C51AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C51AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C52")]
public class C52Controller : AbpController, IC52AppService
{
    private IC52AppService _C52AppService;

    public C52Controller(IC52AppService appService)
    {
        _C52AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C52AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C52AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C53")]
public class C53Controller : AbpController, IC53AppService
{
    private IC53AppService _C53AppService;

    public C53Controller(IC53AppService appService)
    {
        _C53AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C53AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C53AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C54")]
public class C54Controller : AbpController, IC54AppService
{
    private IC54AppService _C54AppService;

    public C54Controller(IC54AppService appService)
    {
        _C54AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C54AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C54AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C55")]
public class C55Controller : AbpController, IC55AppService
{
    private IC55AppService _C55AppService;

    public C55Controller(IC55AppService appService)
    {
        _C55AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C55AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C55AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C56")]
public class C56Controller : AbpController, IC56AppService
{
    private IC56AppService _C56AppService;

    public C56Controller(IC56AppService appService)
    {
        _C56AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C56AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C56AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C57")]
public class C57Controller : AbpController, IC57AppService
{
    private IC57AppService _C57AppService;

    public C57Controller(IC57AppService appService)
    {
        _C57AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C57AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C57AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C58")]
public class C58Controller : AbpController, IC58AppService
{
    private IC58AppService _C58AppService;

    public C58Controller(IC58AppService appService)
    {
        _C58AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C58AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C58AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C59")]
public class C59Controller : AbpController, IC59AppService
{
    private IC59AppService _C59AppService;

    public C59Controller(IC59AppService appService)
    {
        _C59AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C59AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C59AppService.GetListAsync(input);
    }
}


[ResponseCache(Duration = 60 * 60 * 24 * 30 * 12)]
[Route("/api/catalog/C60")]
public class C60Controller : AbpController, IC60AppService
{
    private IC60AppService _C60AppService;

    public C60Controller(IC60AppService appService)
    {
        _C60AppService = appService;
    }
    [Route("{id}")]
    [HttpGet]
    public Task<LookupDto<string>> GetAsync(string id)
    {
        return _C60AppService.GetAsync(id);
    }
    [HttpGet]
    public Task<PagedResultDto<LookupDto<string>>> GetListAsync(LookupRequestDto input)
    {
        return _C60AppService.GetListAsync(input);
    }
}