using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialNinja.API.Models;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    public string Username { get; set; } = default!;

    [Column("password")]
    [JsonIgnore]
    public string Password {get; set;}= default!;

    [Column("email")]
    public string Email {get; set;}= default!;

    [JsonIgnore]
    public virtual List<News> News {get;set;} = new();

    [JsonIgnore]
    public virtual List<Follower> Followings {get;set;} = new();

    public User(int id, string username, string email)
    {
        Id = id;
        Username = username;
        Email = email;
    }
}
