using ToDoListBertoni.Styles;
using Xamarin.Forms;

namespace ToDoListBertoni.Controls
{
    public class LoadingView : Frame
    {
        public bool IsRunning { get { return (bool)GetValue(IsRunningProperty); } set { SetValue(IsRunningProperty, value); } }
        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(
            nameof(IsRunning),
            typeof(bool),
            typeof(LoadingView),
            false,
            BindingMode.TwoWay,
            propertyChanged: (s, o, n) =>
            {
                var sender = (s as LoadingView);
                if (sender == null) return;

                if ((bool)n)
                {
                    sender.IsVisible = true;
                    sender._indicator.IsRunning = true;
                }
                else
                {
                    sender.IsVisible = false;
                    sender._indicator.IsRunning = false;
                }
            });

        ActivityIndicator _indicator;

        public LoadingView()
        {
            int loaderSize = 100;
            CornerRadius = 8;
            VerticalOptions = LayoutOptions.Center;
            Padding = 0;
            HorizontalOptions = LayoutOptions.Center;
            WidthRequest = loaderSize;
            HeightRequest = loaderSize;
            MinimumWidthRequest = loaderSize;
            MinimumHeightRequest = loaderSize;
            HasShadow = Device.RuntimePlatform == Device.iOS ? false : true;
            BorderColor = Colors.Divider;
            BackgroundColor = Colors.CellLightBackground;

            _indicator = new ActivityIndicator
            {
                WidthRequest = 50,
                HeightRequest = 50,
                IsRunning = false,
                Color = Color.Gray
            };

            Content = _indicator;
            IsVisible = false;
        }
    }
}
