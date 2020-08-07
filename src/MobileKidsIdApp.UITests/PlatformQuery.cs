using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MobileKidsIdApp.UITests
{
    public class PlatformQuery
    {
        public Func<AppQuery, AppQuery> Android
        {
            set
            {
                if (AppManager.Platform == Platform.Android)
                {
                    _current = value;
                }
            }
        }

        // ReSharper disable once InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles
        public Func<AppQuery, AppQuery> iOS
#pragma warning restore IDE1006 // Naming Styles
        {
            set
            {
                if (AppManager.Platform == Platform.iOS)
                {
                    _current = value;
                }
            }
        }

        Func<AppQuery, AppQuery> _current;
        public Func<AppQuery, AppQuery> Current
        {
            get
            {
                if (_current == null)
                {
                    throw new NullReferenceException("Trait not set for current platform");
                }

                return _current;
            }
        }
    }
}
