using NUnit.Framework;
using Xamarin.UITest;

namespace MobileKidsIdApp.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public abstract class BaseTestFixture
    {
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        // ReSharper disable once InconsistentNaming
        protected bool OniOS => AppManager.Platform == Platform.iOS;

        protected BaseTestFixture(Platform platform)
        {
            AppManager.Platform = platform;
        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            AppManager.StartApp();
        }
    }
}
