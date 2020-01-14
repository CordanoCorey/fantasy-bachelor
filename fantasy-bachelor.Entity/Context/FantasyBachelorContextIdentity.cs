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
                        Email = "es2531@ymail.com",
                        EmailConfirmed = false,
                        FirstName = "Evan",
                        LastName = "Simon",
                        LockoutEnabled = false,
                        NormalizedEmail = "es2531@ymail.com",
                        NormalizedUserName = "es2531@ymail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "es2531@ymail.com"
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
                        Email = "andreamariko1k@yahoo.com",
                        EmailConfirmed = false,
                        FirstName = "Andrea",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "andreamariko1k@yahoo.com",
                        NormalizedUserName = "andreamariko1k@yahoo.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "andreamariko1k@yahoo.com"
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
                        LastName = "McMahan",
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
                        LastName = "Phelan",
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
                    },
                    new ApplicationUser
                    {
                        Id = 21,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "nkroof@yahoo.com",
                        EmailConfirmed = false,
                        FirstName = "Gram",
                        LastName = "Roof",
                        LockoutEnabled = false,
                        NormalizedEmail = "nkroof@yahoo.com",
                        NormalizedUserName = "nkroof@yahoo.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "nkroof@yahoo.com"
                    },
                    new ApplicationUser
                    {
                        Id = 22,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "felecia.williamson@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Felecia",
                        LastName = "Williamson",
                        LockoutEnabled = false,
                        NormalizedEmail = "felecia.williamson@gmail.com",
                        NormalizedUserName = "felecia.williamson@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "felecia.williamson@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 23,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "mxr8@pct.edu",
                        EmailConfirmed = false,
                        FirstName = "Michayla",
                        LastName = "Roberts",
                        LockoutEnabled = false,
                        NormalizedEmail = "mxr8@pct.edu",
                        NormalizedUserName = "mxr8@pct.edu",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "mxr8@pct.edu"
                    },
                    new ApplicationUser
                    {
                        Id = 24,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "cnkford18@yahoo.com",
                        EmailConfirmed = false,
                        FirstName = "Chad",
                        LastName = "Kendrick",
                        LockoutEnabled = false,
                        NormalizedEmail = "cnkford18@yahoo.com",
                        NormalizedUserName = "cnkford18@yahoo.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "cnkford18@yahoo.com"
                    },
                    new ApplicationUser
                    {
                        Id = 25,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "taberangela@me.com",
                        EmailConfirmed = false,
                        FirstName = "Angela",
                        LastName = "Taber",
                        LockoutEnabled = false,
                        NormalizedEmail = "taberangela@me.com",
                        NormalizedUserName = "taberangela@me.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "taberangela@me.com"
                    },
                    new ApplicationUser
                    {
                        Id = 26,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "cgcostalas@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Courtney",
                        LastName = "Costalas",
                        LockoutEnabled = false,
                        NormalizedEmail = "cgcostalas@gmail.com",
                        NormalizedUserName = "cgcostalas@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "cgcostalas@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 27,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "bmorgan16@embarqmail.com",
                        EmailConfirmed = false,
                        FirstName = "Beth",
                        LastName = "Morgan",
                        LockoutEnabled = false,
                        NormalizedEmail = "bmorgan16@embarqmail.com",
                        NormalizedUserName = "bmorgan16@embarqmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "bmorgan16@embarqmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 28,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "kmp18@pct.edu",
                        EmailConfirmed = false,
                        FirstName = "Kaitlin",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "kmp18@pct.edu",
                        NormalizedUserName = "kmp18@pct.edu",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "kmp18@pct.edu"
                    },
                    new ApplicationUser
                    {
                        Id = 29,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "amanda.benfer@yahoo.com",
                        EmailConfirmed = false,
                        FirstName = "Amanda",
                        LastName = "Benfer",
                        LockoutEnabled = false,
                        NormalizedEmail = "amanda.benfer@yahoo.com",
                        NormalizedUserName = "amanda.benfer@yahoo.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "amanda.benfer@yahoo.com"
                    },
                    new ApplicationUser
                    {
                        Id = 30,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "ipeleg@hotmail.com",
                        EmailConfirmed = false,
                        FirstName = "Peleg",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "ipeleg@hotmail.com",
                        NormalizedUserName = "ipeleg@hotmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "ipeleg@hotmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 31,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "addieorndorff@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Addie",
                        LastName = "Orndorff",
                        LockoutEnabled = false,
                        NormalizedEmail = "addieorndorff@gmail.com",
                        NormalizedUserName = "addieorndorff@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "addieorndorff@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 32,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "rmo104@psu.edu",
                        EmailConfirmed = false,
                        FirstName = "Bob",
                        LastName = "Orndorff",
                        LockoutEnabled = false,
                        NormalizedEmail = "rmo104@psu.edu",
                        NormalizedUserName = "rmo104@psu.edu",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "rmo104@psu.edu"
                    },
                    new ApplicationUser
                    {
                        Id = 33,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "megangodfrey97@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Megan",
                        LastName = "Godfrey",
                        LockoutEnabled = false,
                        NormalizedEmail = "megangodfrey97@gmail.com",
                        NormalizedUserName = "megangodfrey97@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "megangodfrey97@gmail.com"
                    },
                    new ApplicationUser
                    {
                        Id = 34,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "donna@dgodfreylaw.com",
                        EmailConfirmed = false,
                        FirstName = "Donna",
                        LastName = "Godfrey",
                        LockoutEnabled = false,
                        NormalizedEmail = "donna@dgodfreylaw.com",
                        NormalizedUserName = "donna@dgodfreylaw.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "donna@dgodfreylaw.com"
                    },
                    new ApplicationUser
                    {
                        Id = 35,
                        AccessFailedCount = 0,
                        ConcurrencyStamp = "b39b7fd6-391c-4d74-ae0c-14a75b78866d",
                        Email = "morgan.ciecierski10@gmail.com",
                        EmailConfirmed = false,
                        FirstName = "Morgan",
                        LastName = "",
                        LockoutEnabled = false,
                        NormalizedEmail = "morgan.ciecierski10@gmail.com",
                        NormalizedUserName = "morgan.ciecierski10@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==",
                        SecurityStamp = "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB",
                        UserName = "morgan.ciecierski10@gmail.com"
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
