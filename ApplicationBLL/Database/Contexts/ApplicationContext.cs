using Microsoft.EntityFrameworkCore;

namespace ApplicationBLL.Database.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() => Database.EnsureCreated();
    }
}
