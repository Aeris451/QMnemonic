using Microsoft.AspNetCore.Identity;
using QMnemonic.Domain.Entities;


namespace QMnemonic.Infrastructure.Identity;


public class ApplicationUser : IdentityUser
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string UserName { get; set;}

}
