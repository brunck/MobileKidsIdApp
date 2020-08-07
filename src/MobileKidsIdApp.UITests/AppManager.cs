using System;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace MobileKidsIdApp.UITests
{
    public class AppManager
    {
        // ReSharper disable once InconsistentNaming
        private const string iOSAppPath = "../../../MobileKidsIdApp/MobileKidsIdApp.iOS/bin/iPhoneSimulator/Debug/MobileKidsIdApp.iOS.app";
        private const string AndroidFileName = ""; //"../../../MobileKidsIdApp/MobileKidsIdApp.Android/";
        private const string IpaBundleId = "MobileKidsIdApp.iOS.app";

        static IApp _app;
        public static IApp App
        {
            get
            {
                if (_app == null)
                {
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                }
                return _app;
            }
        }

        static Platform? _platform;
        public static Platform Platform
        {
            get
            {
                if (_platform == null)
                {
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                }
                return _platform.Value;
            }

            set => _platform = value;
        }

        public static void StartApp()
        {
            if (Platform == Platform.Android)
            {
                _app = ConfigureApp
                    .Android
                    .InstalledApp(AndroidFileName)
#if DEBUG
                    .EnableLocalScreenshots()
                    //.Debug()
#endif
                    .StartApp(AppDataMode.Clear);
            }

            if (Platform == Platform.iOS)
            {   
                _app = ConfigureApp
                    .iOS
                    // Used to run a .app file on an iOS simulator:
                    .AppBundle(iOSAppPath)
                    //.DeviceIdentifier("") // a device ID is required when running on the iOS simulator
                    // Used to run a .ipa file on a physical iOS device:
                    //.InstalledApp(IpaBundleId)
#if DEBUG
                    .EnableLocalScreenshots()
                    //.Debug()
#endif
                    .StartApp(AppDataMode.Clear);
            }
        }
    }
}
