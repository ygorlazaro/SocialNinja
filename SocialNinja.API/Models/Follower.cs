using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialNinja.API.Models;

[Table("followers")]
public class Follower
{
    [Key]
    [Column("id")] 
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [JsonIgnore]
    public virtual User User { get; set; } = default!;

    [Column("follower_id")]
    public int FollowerId { get; set; }

    [JsonIgnore]
    public virtual User Following { get; set; } = default!;
}
