using System.Reflection.Metadata.Ecma335;
using QMnemonic.Domain.Entities;

namespace QMnemonic.Domain.Identity
{
    public interface IApplicationUser
    {
        string Id { get; set; }
        string UserName { get; set; }
        string FirstName {get; set;}
        string LastName {get; set;}
        string Email {get; set;}

        List<int> CoursesId {get; set;}
        List<int> GroupsId {get; set;}

    }
}
