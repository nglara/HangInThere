using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HangInThere.Startup))]
namespace HangInThere
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JobStorage.Current = new SqlServerStorage("TestContext");
            GlobalConfiguration.Configuration.UseSqlServerStorage("TestContext");

            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                AuthorizationFilters = new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        Users = new[]
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login = "user",
                                PasswordClear = "pass"
                            }
                        },
                        RequireSsl = false,
                        LoginCaseSensitive = false,
                        SslRedirect = false
                    })
                }
            });

            app.UseHangfireServer();
        }
    }
}
