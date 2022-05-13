using Microsoft.AspNetCore.Mvc;
using SocialNinja.API.Contexts;
using SocialNinja.API.Models;

namespace SocialNinja.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedController:ControllerBase
{
    public FeedController(DefaultContext context)
    {
        Context = context;
    }

    private DefaultContext Context { get; }

    [HttpGet("{id}")]
    public ActionResult GetFeed([FromRoute] int id)
    {
        var feed = from news in Context.News
                    join creator in Context.Users on news.UserId equals creator.Id
                    where news.UserId == id
                        || creator.Followings.Any(following => following.UserId == id)
                    orderby news.Id descending
                    select new News(news.Id, news.PostMessage, creator);

        return Ok(feed);
    }

}
