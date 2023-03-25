using System.ComponentModel.DataAnnotations;
using EasyAbp.Abp.TagHelperPlus.EasySelector;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.VirtualFileSystem;

namespace Acme.Samples.Pages.Catalog;

public class Index : PageModel
{
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C01",
        getSingleDataSourceUrl: "/api/app/C01/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Tipo de documento")]
    //[InputInfoText("N° 01 - Tipo de documento")]
    public string C01_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C02",
        getSingleDataSourceUrl: "/api/app/C02/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Tipo de monedas")]
    //[InputInfoText("N° 02 - Tipo de monedas")]
    public string C02_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C03",
        getSingleDataSourceUrl: "/api/app/C03/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Tipo de unidad de medida comercial")]
    //[InputInfoText("N° 03 - Tipo de unidad de medida comercial")]
    public string C03_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C04",
        getSingleDataSourceUrl: "/api/app/C04/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de país")]
    //[InputInfoText("N° 04 - Código de país")]
    public string C04_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C05",
        getSingleDataSourceUrl: "/api/app/C05/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipos de tributos y otros conceptos")]
    //[InputInfoText("N° 05 - Código de tipos de tributos y otros conceptos")]
    public string C05_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C06",
        getSingleDataSourceUrl: "/api/app/C06/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de documento de identidad")]
    //[InputInfoText("N° 06 - Código de tipo de documento de identidad")]
    public string C06_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C07",
        getSingleDataSourceUrl: "/api/app/C07/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de afectación del IGV")]
    //[InputInfoText("N° 07 - Código de tipo de afectación del IGV")]
    public string C07_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C08",
        getSingleDataSourceUrl: "/api/app/C08/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipos de sistema de cálculo del ISC")]
    //[InputInfoText("N° 08 - Código de tipos de sistema de cálculo del ISC")]
    public string C08_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C09",
        getSingleDataSourceUrl: "/api/app/C09/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Códigos de tipo de nota de crédito electrónica")]
    //[InputInfoText("N° 09 - Códigos de tipo de nota de crédito electrónica")]
    public string C09_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C10",
        getSingleDataSourceUrl: "/api/app/C10/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Códigos de tipo de nota de débito electrónica")]
    //[InputInfoText("N° 10 - Códigos de tipo de nota de débito electrónica")]
    public string C10_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C11",
        getSingleDataSourceUrl: "/api/app/C11/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Códigos de tipo de valor de venta (Resumen diario de boletas y notas)")]
    //[InputInfoText("N° 11 - Códigos de tipo de valor de venta (Resumen diario de boletas y notas)")]
    public string C11_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C12",
        getSingleDataSourceUrl: "/api/app/C12/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de documentos relacionados tributarios")]
    //[InputInfoText("N° 12 - Código de documentos relacionados tributarios")]
    public string C12_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C14",
        getSingleDataSourceUrl: "/api/app/C14/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de otros conceptos tributarios")]
    //[InputInfoText("N° 14 - Código de otros conceptos tributarios")]
    public string C14_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C15",
        getSingleDataSourceUrl: "/api/app/C15/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Códigos de elementos adicionales en la factura y boleta electrónica")]
    //[InputInfoText("N° 15 - Códigos de elementos adicionales en la factura y boleta electrónica")]
    public string C15_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C16",
        getSingleDataSourceUrl: "/api/app/C16/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de precio de venta unitario")]
    //[InputInfoText("N° 16 - Código de tipo de precio de venta unitario")]
    public string C16_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C17",
        getSingleDataSourceUrl: "/api/app/C17/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de operación")]
    //[InputInfoText("N° 17 - Código de tipo de operación")]
    public string C17_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C18",
        getSingleDataSourceUrl: "/api/app/C18/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de modalidad de transporte")]
    //[InputInfoText("N° 18 - Código de modalidad de transporte")]
    public string C18_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C19",
        getSingleDataSourceUrl: "/api/app/C19/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de estado del ítem (resumen diario)")]
    //[InputInfoText("N° 19 - Código de estado del ítem (resumen diario)")]
    public string C19_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C20",
        getSingleDataSourceUrl: "/api/app/C20/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de motivo de traslado")]
    //[InputInfoText("N° 20 - Código de motivo de traslado")]
    public string C20_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C21",
        getSingleDataSourceUrl: "/api/app/C21/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de documentos relacionados (sólo guía de remisión electrónica)")]
    //[InputInfoText("N° 21 - Código de documentos relacionados (sólo guía de remisión electrónica)")]
    public string C21_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C22",
        getSingleDataSourceUrl: "/api/app/C22/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de regimen de percepciones")]
    //[InputInfoText("N° 22 - Código de regimen de percepciones")]
    public string C22_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C23",
        getSingleDataSourceUrl: "/api/app/C23/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de regimen de retenciones")]
    //[InputInfoText("N° 23 - Código de regimen de retenciones")]
    public string C23_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C24",
        getSingleDataSourceUrl: "/api/app/C24/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tarifa de servicios públicos")]
    //[InputInfoText("N° 24 - Código de tarifa de servicios públicos")]
    public string C24_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C26",
        getSingleDataSourceUrl: "/api/app/C26/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Tipo de préstamo (créditos hipotecarios)")]
    //[InputInfoText("N° 26 - Tipo de préstamo (créditos hipotecarios)")]
    public string C26_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C27",
        getSingleDataSourceUrl: "/api/app/C27/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Indicador de primera vivienda")]
    //[InputInfoText("N° 27 - Indicador de primera vivienda")]
    public string C27_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C51",
        getSingleDataSourceUrl: "/api/app/C51/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de operación")]
    //[InputInfoText("N° 51 - Código de tipo de operación")]
    public string C51_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C52",
        getSingleDataSourceUrl: "/api/app/C52/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Códigos de leyendas")]
    //[InputInfoText("N° 52 - Códigos de leyendas")]
    public string C52_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C53",
        getSingleDataSourceUrl: "/api/app/C53/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Códigos de cargos, descuentos y otras deducciones")]
    //[InputInfoText("N° 53 - Códigos de cargos, descuentos y otras deducciones")]
    public string C53_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C54",
        getSingleDataSourceUrl: "/api/app/C54/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Códigos de bienes y servicios sujetos a detracciones")]
    //[InputInfoText("N° 54 - Códigos de bienes y servicios sujetos a detracciones")]
    public string C54_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C55",
        getSingleDataSourceUrl: "/api/app/C55/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de identificación del concepto tributario")]
    //[InputInfoText("N° 55 - Código de identificación del concepto tributario")]
    public string C55_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C56",
        getSingleDataSourceUrl: "/api/app/C56/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de servicio público")]
    //[InputInfoText("N° 56 - Código de tipo de servicio público")]
    public string C56_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C57",
        getSingleDataSourceUrl: "/api/app/C57/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de servicio públicos - telecomunicaciones")]
    //[InputInfoText("N° 57 - Código de tipo de servicio públicos - telecomunicaciones")]
    public string C57_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C58",
        getSingleDataSourceUrl: "/api/app/C58/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de medidor (recibo de luz)")]
    //[InputInfoText("N° 58 - Código de tipo de medidor (recibo de luz)")]
    public string C58_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C59",
        getSingleDataSourceUrl: "/api/app/C59/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Medios de Pago")]
    //[InputInfoText("N° 59 - Medios de Pago")]
    public string C59_Id { get; set; }
    
    [EasySelector(
        getListedDataSourceUrl: "/api/app/C60",
        getSingleDataSourceUrl: "/api/app/C60/{id}",
        textPropertyName: "displayName",
        runScriptOnWindowLoad: true
    )]
    [Required]
    [Display(Name = "Código de tipo de dirección")]
    //[InputInfoText("N° 60 - Código de tipo de dirección")]
    public string C60_Id { get; set; }
    
    
    public void OnGet()
    {
    }
}