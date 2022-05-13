using Microsoft.AspNetCore.Mvc;
using SocialNinja.API.Contexts;
using SocialNinja.API.Models;

namespace SocialNinja.API.Controllers;

[Route("api/[controller]")]
public class UserController: ControllerBase
{

    // /*
    //      post para cadastrar usuário
    //      get para ler um usuário
    //      put para atualizar um usuário
    // /*

    public UserController(DefaultContext context)
    {
        Context = context;
    }

    private DefaultContext Context { get; }

    [HttpPost]
    public ActionResult CreateUser([FromBody]User user)
    {
        Context.Add(user);

        Context.SaveChanges();

        return Created("api/user", user);
    }

    // [HttpPut("{id}")]
    // public ActionResult UpdateUser([FromBody] User user, [FromRoute] int id)
    // {
    //     var existingUser = Context.Users.Any(user => user.Id == id);

    //     if (!existingUser)
    //     {
    //         return NotFound(new { Message = "Usuário não encontrado" });
    //     }

    //     user.Id = id;

    //     Context.Entry(user).State = EntityState.Modified;
    //     Context.SaveChanges();

    //     return Created("api/user", user);
    // }

    [HttpGet("{id}")]
    public ActionResult GetById([FromRoute] int id)
    {
        var user = Context.Users.FirstOrDefault(user => user.Id == id);

        if (user is null)
        {
            return NotFound(new{Message = "Usuário não encontrado"});
        }

        return Ok(user);
    }

    [HttpGet("{id}/news")]
    public ActionResult GetNewsByUserId([FromRoute] int id)
    {
        var user = Context.Users.FirstOrDefault(user => user.Id == id);

        if (user is null)
        {
            return NotFound(new { Message = "Usuário não encontrado" });
        }

        var news = Context.News.Where(news => news.UserId == id);

        return Ok(news);
    }
}
