using NUnit.Framework;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MobileKidsIdApp.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform) : base(platform)
        {
        }

        [Test]
        public void Repl()
        {
            AppManager.App.Repl();
        }
    }
}
