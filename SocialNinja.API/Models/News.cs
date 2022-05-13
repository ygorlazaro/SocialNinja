using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNinja.API.Models;

[Table("news")]
public class News
{
    [Key]
    [Column("id")] 
    public int Id {get;set;}

    [Column("post_message")]
    public string PostMessage {get;set;} = default!;

    [Column("user_id")]
    public int UserId {get;set;}

    public virtual User? User {get;set;} = default!;

    public News(int id, string postMessage, User user)
    {
        Id = id;
        PostMessage = postMessage;
        User = user;
    }
}
