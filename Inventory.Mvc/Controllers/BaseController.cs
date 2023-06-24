using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Inventory.Mvc.Controllers;
public class BaseController : Controller
{
    protected IMediator mediator
    => HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected IApplicationDbContext _context
        => HttpContext.RequestServices.GetRequiredService<IApplicationDbContext>();

    protected IWebHostEnvironment _webHostEnvironment
        => HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>();

    protected ICurrentUser _currentUser
        => HttpContext.RequestServices.GetRequiredService<ICurrentUser>();

}
