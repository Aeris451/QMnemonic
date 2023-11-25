using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using QMnemonic.Domain.Entities;
using QMnemonic.Domain.Identity;


namespace QMnemonic.Infrastructure.Identity;


public class ApplicationUser : IdentityUser, IApplicationUser
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string UserName { get; set;}
    public List<int> CoursesId {get; set;}
    public List<int> GroupsId { get; set; }
}
