using BugBlaze.Areas.Identity;
using BugBlaze.Data;
using BugBlaze.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugBlaze
{
    public class Startup
    {


        private readonly ApplicationDbContext _context;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI();

            //services.AddScoped<IUserClaimsPrincipalFactory<UserModel>, CustomUserClaimsPrincipalFactory>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddSingleton<CustomHttpClient>();
            services.AddSingleton<AppSettingsService>();

            services.AddAuthentication().AddFacebook(options => { 
                options.AppId = Configuration["Facebok:AppId"];
                options.AppSecret = Configuration["Facebook:AppToken"];
            });

            services.AddAuthentication().AddGoogle(options => 
            {
                options.ClientId = Configuration["Google:ClientId"];
                options.ClientSecret = Configuration["Google:ClientSecret"];
                options.CallbackPath = new PathString("/signin-google-token");
                //options.AuthorizationEndpoint = GoogleAuthenticationDefaults.AuthorizationEndpoint;
                //options.TokenEndpoint = GoogleAuthenticationDefaults.TokenEndpoint;
                //options.Scope.Add("openid");
                //options.Scope.Add("profile");
                //options.Scope.Add("email");
                options.ClaimActions.Clear();
                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                options.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "given_name");
                options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "family_name");
                options.ClaimActions.MapJsonKey("urn:google:profile", "link");
                options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = OnCreatingGoogleTicket()
                };
            });

            //services.AddAuthentication().

            services.AddAuthentication().AddGitHub(options => 
            {
                options.ClientId = Configuration["GitHub:ClientId"];
                options.ClientSecret = Configuration["GitHub:ClientSecret"];
                options.CallbackPath = new PathString("/signin-github");
                options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                options.TokenEndpoint = "https://github.com/login/oauth/access_token";
                options.UserInformationEndpoint = "https://api.github.com/user";
                options.Scope.Add("repo");
                options.Scope.Add("user:email");
                options.Scope.Add("repo:status");
                options.Scope.Add("repo_deployment");
                options.Scope.Add("public_repo");
                options.Scope.Add("repo:invite");
                options.Scope.Add("admin:org");
                options.Scope.Add("notifications");
                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = OnCreatingGitHubTicket()
                };
            });


        }

        /**
         * Collect user data when logging in with GitHub.
         */
        private static Func<OAuthCreatingTicketContext, Task> OnCreatingGitHubTicket()
        {
            //string baseUrl = GetBaseUrl();

            return async context =>
            {

                //OAuthAuthenticationOptions ops = new OAuthAuthenticationOptions();

                var fullName = context.Identity.FindFirst("urn:github:name").Value;
                var email = context.Identity.FindFirst(ClaimTypes.Email).Value;
                var githubUrl = context.Identity.FindFirst("urn:github:url").Value;

                Console.WriteLine(fullName + ", " + email + ", " + githubUrl);

                context.Identity.AddClaim(new Claim("urn:github:name", context.Identity.FindFirstValue(ClaimTypes.Name)));
                //context.Identity.AddClaim(new Claim("urn:github:name", ));



                //Todo: Add logic here to save info into database
                //var user = await UserManager.

                //string userName = string.Empty;

                //if (System.Web.HttpContext.Current != null &&
                //    System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                //{
                //    System.Web.Security.MembershipUser usr = Membership.GetUser();
                //    if (usr != null)
                //    {
                //        userName = usr.UserName;
                //    }
                //}

                // this Task.FromResult is purely to make the code compile as it requires a Task result
                await Task.FromResult(true);
            };
        }

        //private static Task<IEnumerable<UserModel>> GetJsonAsync<T>(object p)
        //{
        //    throw new NotImplementedException();
        //}

        private static Func<OAuthCreatingTicketContext, Task> OnCreatingGoogleTicket()
        {
            return async context =>
            {
                var firstName = context.Identity.FindFirst(ClaimTypes.GivenName).Value;
                var lastName = context.Identity.FindFirst(ClaimTypes.Surname)?.Value;
                var email = context.Identity.FindFirst(ClaimTypes.Email).Value;


                //Todo: Add logic here to save info into database

                // this Task.FromResult is purely to make the code compile as it requires a Task result
                await Task.FromResult(true);
            };
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
