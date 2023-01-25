using System.ComponentModel.DataAnnotations;

namespace Acme.Samples.Services.Dtos;

public class UpdateDatosSolDto
{
    [Required]
    public string User { get; set; }
    [Required]
    public string Password { get; set; }
}