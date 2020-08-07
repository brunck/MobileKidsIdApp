using System;
using System.IO;
using NUnit.Framework;
using Xamarin.UITest;

namespace MobileKidsIdApp.UITests
{
    public abstract class BasePage
    {
        protected IApp App => AppManager.App;
        protected bool OnAndroid => AppManager.Platform == Platform.Android;
        // ReSharper disable once InconsistentNaming
        protected bool OniOS => AppManager.Platform == Platform.iOS;

        protected abstract PlatformQuery Trait { get; }

        protected BasePage()
        {
            AssertOnPage(TimeSpan.FromSeconds(30));
            TakeScreenshot("On " + this.GetType().Name);
        }

        /// <summary>
        /// Verifies that the trait is still present. Defaults to no wait.
        /// </summary>
        /// <param name="timeout">Time to wait before the assertion fails</param>
        protected void AssertOnPage(TimeSpan? timeout = default(TimeSpan?))
        {
            var message = "Unable to verify on page: " + this.GetType().Name;

            if (timeout == null)
                Assert.IsNotEmpty(App.Query(Trait.Current), message);
            else
                Assert.DoesNotThrow(() => App.WaitForElement(Trait.Current, timeout: timeout), message);
        }

        /// <summary>
        /// Verifies that the trait is no longer present. Defaults to a 5 second wait.
        /// </summary>
        /// <param name="timeout">Time to wait before the assertion fails</param>
        protected void WaitForPageToLeave(TimeSpan? timeout = default(TimeSpan?))
        {
            timeout = timeout ?? TimeSpan.FromSeconds(5);
            var message = "Unable to verify *not* on page: " + this.GetType().Name;

            Assert.DoesNotThrow(() => App.WaitForNoElement(Trait.Current, timeout: timeout), message);
        }

        public void TakeScreenshot(string title)
        {
            var file = App.Screenshot(title ?? "N/A");
#if DEBUG
            var newPath = GetScreenshotFilePath(file, title);
            file.MoveTo(newPath); // rename the local screenshot file so it's not overwritten
            Console.WriteLine();
            Console.WriteLine($"**** Screenshot moved to: {newPath}");
            Console.WriteLine();
#endif
        }

        private string GetScreenshotFilePath(FileInfo file, string title)
        {
            var platformName = OnAndroid ? "Android" : "iOS";
            var path = file.DirectoryName;
            var newPath = Path.Combine(path, "Screenshots");
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            var fileName = $"Screenshot-{platformName}-{title}-{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}.png";
            var fullName = Path.Combine(newPath, fileName);
            return fullName;
        }
    }
}
