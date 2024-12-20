using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public AppDbContext(DbContextOptions opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(x =>
            {
                x.HasKey(y => y.Code);
                x.HasIndex(y => y.Name).IsUnique();
                x.Property(y => y.Code).IsFixedLength(true).HasMaxLength(2);
                x.Property(y => y.Name).IsRequired().HasMaxLength(32);
                x.Property(x => x.Icon).HasMaxLength(3000);
                x.HasData(new Language
                {
                    Code = "az",
                    Name = "Azerbaycan",
                    Icon="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAAqFBMVEX///8AueQ/nDXtKTkAv+wAtOI1oDU7mjBfrle1SV6ZYDfyIznxJTXtJze16PbD3sFKokH5vsLuNUQLvub71tnsGy7vRVL97/DxIzPwUl3xZ3DwXmj1lJvxYm3++Pjzg4rjx863Vmv6zND83d/uOkj96+zsDSX4t7z95ObxbXXczMGfakLM5Mpqs2LyNEH2nqTyeH/3sLX2p6zziI/5vMDrABzsDSjvS1fLufzYAAADfUlEQVR4nO3Z6VKjQBSGYZzMbp9RkGYPKCEJuBBINN7/nU1IExwn/LR76jDfU6WWZZUnr7GbzbIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAApufXxZdpuvh1Kry5mKYbFLKHQv5QyB8K+UMhfyjkD4X8oZA/FPKHQv5QyB8K+UMhfyjkD4X8oZC//6rw8zQNhbd3P6bp7rYvtJ1AaBZISXVxUAsptU87DXXsoZBmWlFQx9lmnbtu3iZNSELvuGGssUIhqnZhDdxtLDX/SRVjhTJsy37S0rVt2/XLbRHonNgzVEiycdWY1N5Foed5YbRbP8+lvpHDaCOFFGRLNSWPCiGoI0QRJZH+xWikkETjH2f4CYm3KUR15Glfi0YKRawCl9Hq/QwSxfGLzkwThVTnaglW+/OfdR+eznfSRKHM1IRkdT6++ySSRAzffDgDhRSow0R+nkCOEDMqbLugw/FSzwswUCgrNaA63zcp3MxXMvL9SK7iTci1cKVWYV6c/36i3LfDnWXtQtvP9Ww4+gtppjbSZCwgqFIrTa3uI630nOHoLxTzVG2kYwH0kp9OVPMXrjuNzI6Fi3hkGQYzLzkVJt4s0PEKDBQmx8J8ZB95bTZ5eipM803zqmH+Py2cPw996iXMNcw3VuieF5ITZtvhknHRZrGOl2CgsDkWlvORdXhYiG/rcBYInuvwdNrdjF0L0v7tPdxz3UtJqkvDzdh5Z7fR+oeTutK30kzP5bCBc5r9+vj73ZELiMNVR5l0J+aZ3JV5zfSc5vBvqgZkIwsxzhwp4rKMhXSamGsh7dUtmsXIgO6Sn5zn58OPSMs+Y+b6MIjUhHY1PkFkI2/vhzFyjU9tf0A4Szx+T8XIZcfHTTdyJ+pV/Z+mfyfSbBr3abrNpj/srQsx5BCRV03kXtvhuDfvbwiXu9e6f2RSh7tNOJH7pbPupr7dn2UvtlkVx3GVbfO2MPB0xthzC1En7ukEzS8XZZrmmabjw3vmnj2RDBN7eYos17tiYs+eulmBF2XJtm23SRM7ZvreF17qFwSXtVPX3VdjhsL7h5/T9HDfF15df52m66uh8NM0oZA/FPKHQv5QyB8K+UMhfyjkD4X8oZA/FPKHQv5QyB8K+UMhfyjkD4X8/VH4bZqGwsen79P09GgBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAATM9v2kkv/OMmoHkAAAAASUVORK5CYII="
                });
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
