using Portfolio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Bulky.Models;

namespace Portfolio.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<ProjectLogo> ProjectLogos { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //string id = Environment.GetEnvironmentVariable("IU_ADMIN_ID");
            ////string id = Environment.GetEnvironmentVariable();

            //Console.WriteLine("TST:");
            //Console.WriteLine(id);
            //modelBuilder.Entity<IdentityUser>().HasData(
            //    new IdentityUser
            //    {
            //        //Id = id
            //        Id = Env.IU_ADMIN_ID.ToString(),
            //        UserName = Env.IU_ADMIN_USERNAME,
            //        NormalizedUserName = Env.IU_ADMIN_USERNAME.ToUpper(),
            //        Email = Env.IU_ADMIN_EMAIL,
            //        NormalizedEmail = Env.IU_ADMIN_EMAIL.ToUpper(),
            //        //EmailConfirmed = true,
            //        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, Env.IU_ADMIN_EMAIL),
            //        //SecurityStamp = string.Empty,
            //        ConcurrencyStamp = Env.IU_ADMIN_CONCURRENCY_STAMP,
            //    });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Image = "restaurant-app.jpg",
                    ImageAltText = "Restaurant app landing page",
                    Title = "Restaurant App",
                    Description = "A mock e-commerce site that allows users to order one or more dishes from a variety of restaurants. This project utilizes NextJS, GraphQL + Prisma, Redis cache and Stripe for payment.",
                    GitUrl = "https://github.com/nitnub/restaurant",
                    DemoUrl = "https://restaurants.nickbryant.dev",
                    Port = "3501",
                    Active = true,
                    Order = 1,
                },
                new Project
                {
                    Id = 2,
                    Image = "auth-server.jpg",
                    ImageAltText = "Auth server documentation",
                    Title = "Auth REST server",
                    Description = "An authentication REST project that is used by some of my other projects to authenticate users. Utilizes JWTs.",
                    GitUrl = "https://github.com/nitnub/auth-server",
                    DemoUrl = "https://auth.nickbryant.dev/api-docs",
                    Port = "4000",
                    Active = true,
                    Order = 2,
                },
                new Project
                {
                    Id = 3,
                    Image = "werdle.png",
                    ImageAltText = "Werdle game board",
                    Title = "Werdle",
                    Description = "A clone of the popular word game Wordle. Users can customize the word length and the number of turns allowed. In this version, guesses are not checked against the dictionary, so feel free to guess with a non-word! This project was built in React.",
                    GitUrl = "https://github.com/nitnub/werdle",
                    DemoUrl = "https://werdle.nickbryant.dev",
                    Port = "3601",
                    Active = true,
                    Order = 3,
                },
                new Project
                {
                    Id = 4,
                    Image = "food-app.png",
                    ImageAltText = "API Call",
                    Title = "Food App",
                    Description = "This is an in-progress full stack project that will allow users to track food allergies. Integrates with USDA API resources and FODMAP data to help narrow down the source(s) of idiopathic reactions.",
                    GitUrl = "https://github.com/nitnub/food-tracker",
                    DemoUrl = "",
                    Port = "9001",
                    Active = true,
                    Order = 4,
                },
                new Project
                {
                    Id = 5,
                    Image = "bad-bank.png",
                    ImageAltText = "Bad Bank app landing page",
                    Title = "Bad Bank",
                    Description = "\"Bad\" (non-secure) bank assignment for the introductory section of a coding camp I attended. For this project, I opted to utilizes React, React-Bootstrap styling, Formik forms, and Yup form validation.",
                    GitUrl = "https://github.com/nitnub/bad-bank-react",
                    DemoUrl = "https://nitnub-bad-bank-project.s3.amazonaws.com/index.htm",
                    Port = "1100",
                    Active = false,
                    Order = 5,
                });

            modelBuilder.Entity<Video>().HasData(
                new Video
                {
                    Id = 1,
                    Title = "Overview",
                    Description = "Architecture, Authentication, and App Diagram",
                    ToolTip = "Architecture, Authentication, and App Diagram",
                    URL = "https://youtu.be/00l_fB_QNcA",
                    Order = 1,
                    Active = true,
                    ProjectId = 1
                },
                new Video
                {
                    Id = 2,
                    Title = "Data & API",
                    Description = "Database and API",
                    ToolTip = "Database and API",
                    URL = "https://youtu.be/NOsDenknUKc",
                    Order = 2,
                    Active = true,
                    ProjectId = 1
                },
                new Video
                {
                    Id = 3,
                    Title = "Deployment",
                    Description = "Deployment, Additional Features, Demo and Reflections",
                    ToolTip = "Deployment, Additional Features, Demo and Reflections",
                    URL = "https://youtu.be/GImnGa9xLO4",
                    Order = 3,
                    Active = true,
                    ProjectId = 1
                });

            modelBuilder.Entity<Biography>().HasData(
                new Biography
                {
                    Id = 1,
                    Image = @"joshua_tree-header.jpg",
                    ImageAltText = "nick at joshua tree national park",
                    ImageFooter = @"
                        Hiking at&nbsp;
                        <a class=""link"" href=""https://www.nps.gov/jotr/index.htm"">
                            Joshua Tree National Park
                        </a>",
                    Text = @"
                        <h1 id=""bio-header"" class=""intro-header"">
                            Hello!
                        </h1>
                        <p>
                            Welcome to my portfolio page. My name is Nick and I am a
                            customer-focused developer with 12 years of implementation, regulatory
                            compliance, and product management experience in the healthcare
                            informatics space. In 2022, after many years of working closely with
                            engineering teams developing and enhancing Electronic Health Record
                            systems at GE, AZZLY, and most recently athenahealth, I decided to
                            finally start on my journey to full-time software development. A
                            little more about me:
                        </p>
                        <ul>
                            <li>Collaborative problem solver.</li>
                            <li>
                                Interested in developing end-to-end solutions that create real
                                customer value.
                            </li>
                            <li>
                                Over a decade of experience in the healthcare informatics space and
                                excited to take these ""lessons-learned"" into other industries.
                            </li>
                            <li>
                                Projects will be posted below and under the username
                                <a href=""https://github.com/nitnub"" class=""link"">
                                    nitnub
                                </a>
                                on GitHub.
                            </li>
                        </ul>
                        <p>
                            To get in touch about new projects or professional opportunities,
                            please feel free to contact me via
                            <a href=""https://linkedin.com/in/nick-bryant-6b1a9579""
                                class=""link"">
                                LinkedIn
                            </a>
                            !
                        </p>"
                });

            modelBuilder.Entity<Logo>().HasData(
                new Logo 
                { 
                    Id = 1, 
                    Name = "C#", 
                    HTML = @"
                        <svg viewBox=""0 0 128 128"">
                            <path class=""icon-dark""
                                  fill=""currentColor""
                                  d=""M117.5 33.5l.3-.2c-.6-1.1-1.5-2.1-2.4-2.6L67.1 2.9c-.8-.5-1.9-.7-3.1-.7-1.2 0-2.3.3-3.1.7l-48 27.9c-1.7 1-2.9 3.5-2.9 5.4v55.7c0 1.1.2 2.3.9 3.4l-.2.1c.5.8 1.2 1.5 1.9 1.9l48.2 27.9c.8.5 1.9.7 3.1.7 1.2 0 2.3-.3 3.1-.7l48-27.9c1.7-1 2.9-3.5 2.9-5.4V36.1c.1-.8 0-1.7-.4-2.6zm-53.5 70c-21.8 0-39.5-17.7-39.5-39.5S42.2 24.5 64 24.5c14.7 0 27.5 8.1 34.3 20l-13 7.5C81.1 44.5 73.1 39.5 64 39.5c-13.5 0-24.5 11-24.5 24.5s11 24.5 24.5 24.5c9.1 0 17.1-5 21.3-12.4l12.9 7.6c-6.8 11.8-19.6 19.8-34.2 19.8zM115 62h-3.2l-.9 4h4.1v5h-5l-1.2 6h-4.9l1.2-6h-3.8l-1.2 6h-4.8l1.2-6H94v-5h3.5l.9-4H94v-5h5.3l1.2-6h4.9l-1.2 6h3.8l1.2-6h4.8l-1.2 6h2.2v5zm-12.7 4h3.8l.9-4h-3.8z""></path>
                        </svg>"
                },
                new Logo
                {
                    Id = 2,
                    Name = ".NET",
                    HTML = @"
                    <svg viewBox=""0 0 128 128"">
                        <path class=""icon-dark""
                              fill=""currentColor""
                              d=""M61.195 0h4.953c12.918.535 25.688 4.89 36.043 12.676 9.809 7.289 17.473 17.437 21.727 28.906 2.441 6.387 3.664 13.18 4.082 19.992v4.211c-.414 11.293-3.664 22.52-9.73 32.082-6.801 10.895-16.922 19.73-28.727 24.828A64.399 64.399 0 0165.082 128h-2.144c-11.735-.191-23.41-3.66-33.297-9.992-11.196-7.113-20.114-17.785-25.028-30.117C1.891 81.19.441 74.02 0 66.812v-4.957c.504-14.39 5.953-28.609 15.41-39.496C23.168 13.31 33.5 6.48 44.887 2.937 50.172 1.27 55.676.41 61.195 0M25.191 37.523c-.03 12.153-.011 24.305-.011 36.454 1.43.011 2.86.011 4.293.011-.075-10.433.101-20.863-.106-31.293.48.907.918 1.84 1.465 2.707C37.035 54.91 43.105 64.5 49.309 74c1.738-.023 3.476-.023 5.214.004-.003-12.16-.007-24.32.004-36.48a308.076 308.076 0 00-4.25-.012c.075 10.32-.136 20.64.125 30.949-6.507-10.352-13.101-20.645-19.695-30.945a370.85 370.85 0 00-5.516.007m38.844-.011c-.129 12.16-.004 24.32-.047 36.476 6.469-.015 12.938.024 19.41-.02a83.36 83.36 0 01.024-3.952c-5.012-.016-10.027.007-15.043-.02-.074-4.21-.004-8.426-.04-12.637 4.395-.078 8.79.012 13.18-.047-.011-1.277-.011-2.554-.019-3.832-4.387.141-8.773-.054-13.164.012.012-4.023.02-8.05.02-12.078 4.699 0 9.398-.02 14.093.012-.008-1.301 0-2.606.016-3.906-6.145-.016-12.29-.008-18.43-.008m22.602.054c.004 1.266.004 2.528.008 3.79 3.488-.04 6.972.109 10.46.035-.023 10.863.004 21.718-.011 32.574 1.46.043 2.93.035 4.39-.09-.12-5.992.118-11.988-.156-17.977.067-2.699-.07-5.394.117-8.09.106-2.14-.277-4.277-.035-6.417 3.516.047 7.035.015 10.55.015a59.774 59.774 0 01.075-3.832c-8.469-.105-16.937-.094-25.398-.008M13.55 69.094c-1.977.91-2.106 4.023-.149 5.027 1.72 1.18 4.305-.371 4.227-2.41.133-2.004-2.29-3.688-4.078-2.617m29.23 15.289c-4.277 3.469-4.226 11.195.5 14.25 2.668 1.695 6.102 1.344 8.922.215.012-.621.027-1.239.05-1.86-2.671 1.395-6.41 1.68-8.675-.61-2.965-3.237-2.297-9.269 1.613-11.476 2.211-1.164 4.907-.824 7.086.239-.007-.66-.004-1.32 0-1.98-3.097-1.099-6.922-1.04-9.496 1.222m17.207 2.71c-1.89.22-3.758 1.22-4.633 2.966-1.253 2.496-1.109 5.867.864 7.96 2.035 2.297 5.945 2.32 8.18.297 2.425-2.308 2.699-6.468.757-9.164-1.148-1.629-3.273-2.183-5.168-2.058m17.887 2.722c-1.66 2.883-1.332 7.25 1.598 9.211 2.183 1.22 4.933.832 7.074-.308-.004-.617.004-1.235.031-1.848-1.687 1.07-3.937 1.856-5.812.777-1.309-.722-1.704-2.257-1.914-3.625 2.875-.039 5.746-.082 8.625-.074-.075-1.828-.118-3.894-1.45-5.308-2.199-2.43-6.644-1.657-8.152 1.175m-8.414-2.336v12.008c.652 0 1.312 0 1.973.004.023-2.195-.04-4.394.023-6.594.016-1.27.527-2.558 1.484-3.414.801-.605 1.883-.27 2.801-.246-.012-.636-.02-1.27-.023-1.902-1.793-.398-3.336.652-4.242 2.117-.02-.633-.04-1.266-.051-1.894-.656-.024-1.313-.051-1.965-.079zm0 0""></path>
                        <path d=""M58.758 89.223c1.652-.805 4.023-.41 4.945 1.3 1.05 1.887 1.027 4.383-.137 6.211-1.52 2.286-5.527 1.786-6.523-.742-1.008-2.258-.617-5.484 1.715-6.77zm0 0M79.04 92.414c.046-1.574 1.144-3.137 2.726-3.48.976-.164 2.097.007 2.773.793.672.714.813 1.714.98 2.64-2.16.012-4.32-.031-6.48.047zm0 0""></path>
                    </svg>"
                },
                new Logo
                {
                    Id = 3,
                    Name = "TypeScript",
                    HTML = @"
                         <svg viewBox=""0 0 128 128"">
                            <path class=""icon-dark""
                                  fill=""currentColor""
                                  d=""M2 63.91v62.5h125v-125H2zm100.73-5a15.56 15.56 0 017.82 4.5 20.58 20.58 0 013 4c0 .16-5.4 3.81-8.69 5.85-.12.08-.6-.44-1.13-1.23a7.09 7.09 0 00-5.87-3.53c-3.79-.26-6.23 1.73-6.21 5a4.58 4.58 0 00.54 2.34c.83 1.73 2.38 2.76 7.24 4.86 8.95 3.85 12.78 6.39 15.16 10 2.66 4 3.25 10.46 1.45 15.24-2 5.2-6.9 8.73-13.83 9.9a38.32 38.32 0 01-9.52-.1A23 23 0 0180 109.19c-1.15-1.27-3.39-4.58-3.25-4.82a9.34 9.34 0 011.15-.73l4.6-2.64 3.59-2.08.75 1.11a16.78 16.78 0 004.74 4.54c4 2.1 9.46 1.81 12.16-.62a5.43 5.43 0 00.69-6.92c-1-1.39-3-2.56-8.59-5-6.45-2.78-9.23-4.5-11.77-7.24a16.48 16.48 0 01-3.43-6.25 25 25 0 01-.22-8c1.33-6.23 6-10.58 12.82-11.87a31.66 31.66 0 019.49.26zm-29.34 5.24v5.12H57.16v46.23H45.65V69.26H29.38v-5a49.19 49.19 0 01.14-5.16c.06-.08 10-.12 22-.1h21.81z""
                        </svg>"
                });

            modelBuilder.Entity<ProjectLogo>().HasData(
                new ProjectLogo
                {
                    Id= 1,
                    ProjectId= 1,
                    LogoId= 3,
                    Priority= 1,
                    
                },
                 new ProjectLogo
                 {
                     Id = 2,
                     ProjectId = 4,
                     LogoId = 1,
                     Priority = 1,
                 },
                new ProjectLogo
                {
                    Id = 3,
                    ProjectId = 4,
                    LogoId = 2,
                    Priority = 2,
                });
        }
    }
}
