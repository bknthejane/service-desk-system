using System.Threading.Tasks;
using Nthware.SDS.Models.TokenAuth;
using Nthware.SDS.Web.Controllers;
using Shouldly;
using Xunit;

namespace Nthware.SDS.Web.Tests.Controllers
{
    public class HomeController_Tests: SDSWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}