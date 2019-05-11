using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentAttendanceSystemGW.Startup))]
namespace StudentAttendanceSystemGW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
