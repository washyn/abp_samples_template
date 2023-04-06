using System.ComponentModel.DataAnnotations;
using Acme.Identity.Others;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Security.Encryption;

namespace Acme.Identity.IdentityUser;

#region User models

public class User : Entity<int>
{
    public string UserName { get; private set; }
    /// <summary>
    /// Gets or sets a salted and hashed representation of the password for this user.
    /// </summary>
    [DisableAuditing]
    public string PasswordHash { get; private set; }
    
    [CanBeNull] public string Email { get; private set; }
    [CanBeNull] public string Name { get; set; }
    [CanBeNull] public string Surname { get; set; }
    [CanBeNull] public string PhoneNumber { get; set; }

    
    public string RolName { get; private set; }

    protected User()
    {
    }

    public User(string userName, string encriptedPassword, string rolName, string email)
    {
        UserName = Check.NotNullOrEmpty(userName, nameof(userName));
        PasswordHash = Check.NotNullOrEmpty(encriptedPassword, nameof(encriptedPassword));
        Email = Check.NotNullOrEmpty(email, nameof(email));
        
        SetRole(rolName);
    }

    public void SetRole(string rolName)
    {
        Check.NotNullOrEmpty(rolName, nameof(rolName));

        if (rolName != Consts.RolConsts.Administrador && rolName != Consts.RolConsts.Usuario)
        {
            throw new ArgumentException($"Rol value only be set as {Consts.RolConsts.Administrador} or {Consts.RolConsts.Usuario}");
        }

        RolName = rolName;
    }
}

public class UserDto : EntityDto<int>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string RolName { get; set; }
}

public class UpdateUserDto
{
    [Display(Name = "Correo")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Display(Name = "Nombre")] public string Name { get; set; }

    [Display(Name = "Apellido")] public string Surname { get; set; }

    [Display(Name = "Cel")] public string PhoneNumber { get; set; }

    [Display(Name = "Rol")]
    [EnumDataType(typeof(Consts.Roles))]
    public Consts.Roles Roles { get; set; }
}

public class CreateUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsActive { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }

    [Display(Name = "Rol")]
    [EnumDataType(typeof(Consts.Roles))]
    public Consts.Roles Roles { get; set; }
}

#endregion

#region Services

[Authorize(Roles = Consts.RolConsts.Administrador)]
public class UserAppService : CrudAppService<User, UserDto, int, PagedAndSortedResultRequestDto, CreateUserDto,
    UpdateUserDto>
{
    private readonly UserManager _userManager;
    private readonly IStringEncryptionService _encryptionService;

    public UserAppService(IRepository<User, int> repository,
        UserManager userManager,
        IStringEncryptionService encryptionService) :
        base(repository)
    {
        _userManager = userManager;
        _encryptionService = encryptionService;
    }

    public override async Task<UserDto> CreateAsync(CreateUserDto input)
    {
        var newUser = await _userManager.CreateUser(input);
        var result = await this.Repository.InsertAsync(newUser);
        return ObjectMapper.Map<User, UserDto>(result);
    }

    public override async Task<UserDto> UpdateAsync(int id, UpdateUserDto input)
    {
        var user = await Repository.GetAsync(id);
        user.Name = input.Name;
        user.Surname = input.Surname;
        var result = await this.Repository.UpdateAsync(user);
        return ObjectMapper.Map<User, UserDto>(result);
    }
}


public class UserManager : DomainService
{
    private readonly IStringEncryptionService _encryptionService;

    public UserManager(IStringEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
    }

    public async Task<User> CreateUser(CreateUserDto userDto)
    {
        var encriptedPasswd = _encryptionService.Encrypt(userDto.Password);
        var newUser = new User(userName: userDto.UserName, encriptedPasswd, userDto.Roles.ToString(), userDto.Email)
        {
            Name = userDto.Name,
            Surname = userDto.Surname,
            PhoneNumber = userDto.PhoneNumber,
        };
        return newUser;
    }
}
#endregion