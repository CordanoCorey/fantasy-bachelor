using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using fantasy_bachelor.Entity.DataClasses;

namespace fantasy_bachelor.Entity.Context
{
    public partial class FantasyBachelorContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public void OnModelCreating_Identity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(e =>
            {
                e.ToTable("User", "Auth");

                e.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(e => e.LastName)
                    .HasMaxLength(100);

                e.Property(e => e.PasswordResetCode)
                    .HasMaxLength(100);

                e.HasData(
                    new ApplicationUser
                    {
                        Id = 1,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "f605120f-716d-40c3-9dbd-8ff473410823",
                        Email = "gelbaughcm@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "System",
                        LastName = "Administrator",
                        LockoutEnabled = false,
                        NormalizedEmail = "gelbaughcm@gmail.com",
                        NormalizedUserName = "gelbaughcm@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "dfafd561-8cef-40ad-8c7a-339dc67529d0",
                        UserName = "gelbaughcm@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 2,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "f605120f-716d-40c3-9dbd-8ff473410823",
                        Email = "corey@cordanosports.com",
                        EmailConfirmed = false,
                        FirstName = "Corey",
                        LastName = "Gelbaugh",
                        LockoutEnabled = false,
                        NormalizedEmail = "corey@cordanosports.com",
                        NormalizedUserName = "corey@cordanosports.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "dfafd561-8cef-40ad-8c7a-339dc67529d0",
                        UserName = "corey@cordanosports.com"
                    },
                    new ApplicationUser
                    {
                        Id = 3,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "jbrent21@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Julie",
                        LastName = "Gelbaugh",
                        LockoutEnabled = false,
                        NormalizedEmail = "jbrent21@gmail.com",
                        NormalizedUserName = "jbrent21@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "jbrent21@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 4,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "es2531@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Evan",
                        LastName = "Simon",
                        LockoutEnabled = false,
                        NormalizedEmail = "es2531@gmail.com",
                        NormalizedUserName = "es2531@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "es2531@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 5,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "maryzell4@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Mary",
                        LastName = "Zell",
                        LockoutEnabled = false,
                        NormalizedEmail = "maryzell4@gmail.com",
                        NormalizedUserName = "maryzell4@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "maryzell4@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 6,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "adreamarikolk@yahoo.com",
                        EmailConfirmed = false,
                        FirstName = "Andrea",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "adreamarikolk@yahoo.com",
                        NormalizedUserName = "adreamarikolk@yahoo.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "adreamarikolk@yahoo.com"
                    },
                    new ApplicationUser
                    {
                        Id = 7,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "skyelee91@icloud.com",
                        EmailConfirmed = false,
                        FirstName = "Skye",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "skyelee91@icloud.com",
                        NormalizedUserName = "skyelee91@icloud.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "skyelee91@icloud.com"
                    },
                    new ApplicationUser
                    {
                        Id = 8,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "janmcmahan@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Jan",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "janmcmahan@gmail.com",
                        NormalizedUserName = "janmcmahan@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "janmcmahan@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 9,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "jeffs99285@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Jeff",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "jeffs99285@gmail.com",
                        NormalizedUserName = "jeffs99285@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "jeffs99285@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 10,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "deschenmann@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Denise",
                        LastName = "Eschenmann",
                        LockoutEnabled = false,
                        NormalizedEmail = "deschenmann@gmail.com",
                        NormalizedUserName = "deschenmann@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "deschenmann@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 11,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "ceschenman19@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Cara",
                        LastName = "Eschenmann",
                        LockoutEnabled = false,
                        NormalizedEmail = "ceschenman19@gmail.com",
                        NormalizedUserName = "ceschenman19@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "ceschenman19@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 12,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "kwoy1508@yahoo.com",
                        EmailConfirmed = false,
                        FirstName = "Kyleigh",
                        LastName = "Woy",
                        LockoutEnabled = false,
                        NormalizedEmail = "kwoy1508@yahoo.com",
                        NormalizedUserName = "kwoy1508@yahoo.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "kwoy1508@yahoo.com"
                    },
                    new ApplicationUser
                    {
                        Id = 13,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "kabrent51@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Kelly",
                        LastName = "Brent",
                        LockoutEnabled = false,
                        NormalizedEmail = "kabrent51@gmail.com",
                        NormalizedUserName = "kabrent51@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "kabrent51@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 14,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "er1293@messiah.edu",
                        EmailConfirmed = false,
                        FirstName = "Emily",
                        LastName = "Reisinger",
                        LockoutEnabled = false,
                        NormalizedEmail = "er1293@messiah.edu",
                        NormalizedUserName = "er1293@messiah.edu",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "er1293@messiah.edu"
                    },
                    new ApplicationUser
                    {
                        Id = 15,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "mw681275@sju.edu",
                        EmailConfirmed = false,
                        FirstName = "Maddie",
                        LastName = "Wargins",
                        LockoutEnabled = false,
                        NormalizedEmail = "mw681275@sju.edu",
                        NormalizedUserName = "mw681275@sju.edu",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "mw681275@sju.edu"
                    },
                    new ApplicationUser
                    {
                        Id = 16,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "lydiaphelan1@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Lydia",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "lydiaphelan1@gmail.com",
                        NormalizedUserName = "lydiaphelan1@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "lydiaphelan1@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 17,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "kylie.mcmahan@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Kylie",
                        LastName = "McMahan",
                        LockoutEnabled = false,
                        NormalizedEmail = "kylie.mcmahan@gmail.com",
                        NormalizedUserName = "kylie.mcmahan@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "kylie.mcmahan@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 18,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "keirakapner03@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Keira",
                        LastName = "Kapner",
                        LockoutEnabled = false,
                        NormalizedEmail = "keirakapner03@gmail.com",
                        NormalizedUserName = "keirakapner03@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "keirakapner03@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 19,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "rkbrent1111@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Katelin",
                        LastName = "Brent",
                        LockoutEnabled = false,
                        NormalizedEmail = "rkbrent1111@gmail.com",
                        NormalizedUserName = "rkbrent1111@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "rkbrent1111@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 20,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "t_bear25@icloud.com",
                        EmailConfirmed = false,
                        FirstName = "Tyler",
                        LastName = "Bear",
                        LockoutEnabled = false,
                        NormalizedEmail = "t_bear25@icloud.com",
                        NormalizedUserName = "t_bear25@icloud.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "t_bear25@icloud.com"
                    }
                  );
            });

            modelBuilder.Entity<ApplicationRole>(e =>
            {
                e.ToTable("Role", "Auth");
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(e =>
            {
                e.ToTable("UserClaim", "Auth");
            });
            modelBuilder.Entity<IdentityUserLogin<int>>(e =>
            {
                e.ToTable("UserLogin", "Auth");
                e.HasKey(x => new { x.ProviderKey, x.LoginProvider });
            });
            modelBuilder.Entity<IdentityUserToken<int>>(e =>
            {
                e.ToTable("UserToken", "Auth");
                e.HasKey(x => new { x.UserId, x.Value, x.LoginProvider });
            });
            modelBuilder.Entity<IdentityUserRole<int>>(e =>
            {
                e.ToTable("UserRole", "Auth");
                e.HasKey(x => new { x.RoleId, x.UserId });
            });
            modelBuilder.Entity<IdentityRoleClaim<int>>(e =>
            {
                e.ToTable("RoleClaim", "Auth");
            });
        }
    }
}
