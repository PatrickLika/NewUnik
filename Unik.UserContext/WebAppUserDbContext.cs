using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Unik.UserContext;

public class WebAppUserDbContext : IdentityDbContext<IdentityUser>
{

    public WebAppUserDbContext(DbContextOptions<WebAppUserDbContext> options) : base(options)
    {

    }
}