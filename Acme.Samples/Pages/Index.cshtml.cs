﻿using Acme.Samples.Select;
using EasyAbp.Abp.TagHelperPlus.EasySelector;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Samples.Pages;

public class IndexModel : AbpPageModel
{
    [EasySelector(
        getListedDataSourceUrl: "/api/app/audit-log-select",
        getSingleDataSourceUrl: "/api/app/audit-log-select/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public Guid EntityId { get; set; } 
        = Guid.Parse("285cf911-8988-7c57-98d5-3a08fd68db24");


    [EasySelector(
        getListedDataSourceUrl: "/api/app/user-select",
        getSingleDataSourceUrl: "/api/app/user-select/{id}",
        keyPropertyName: "id",
        textPropertyName: "displayName",
        itemListPropertyName: "items",
        hideSubText: false,
        runScriptOnWindowLoad: true)]
    public Guid UserId { get; set; } = Guid.Parse("6681ad2f-7e06-8de9-92d1-3a08fd1ad53c");
    
    public IndexModel()
    {
    }
}