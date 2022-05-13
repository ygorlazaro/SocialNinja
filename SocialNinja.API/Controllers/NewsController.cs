using Microsoft.AspNetCore.Mvc;
using SocialNinja.API.Contexts;
using SocialNinja.API.Models;

namespace SocialNinja.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsController: ControllerBase
{
    public NewsController(DefaultContext context)
    {
        Context = context;
    }

    private DefaultContext Context { get; }

    [HttpPost]
    public ActionResult CreateNews([FromBody] News news)
    {
        Context.Add(news);

        Context.SaveChanges();

        return Created("api/News", news);
    }
}
