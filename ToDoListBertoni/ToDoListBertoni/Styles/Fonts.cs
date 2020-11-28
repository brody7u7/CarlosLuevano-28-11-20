using Device = Xamarin.Forms.Device;
using Label = Xamarin.Forms.Label;
using NamedSize = Xamarin.Forms.NamedSize;

namespace ToDoListBertoni.Styles
{
    public static class Fonts
    {
        public static double ExtraSmallSize => Device.GetNamedSize(NamedSize.Micro, typeof(Label)) + 1 + FontSizeAdded;
        public static double SmallSize => Device.GetNamedSize(NamedSize.Small, typeof(Label)) - 1 + FontSizeAdded;
        public static double MediumSize => Device.GetNamedSize(NamedSize.Medium, typeof(Label)) - 2 + FontSizeAdded;
        public static double LargeSize => Device.GetNamedSize(NamedSize.Medium, typeof(Label)) + 1 + FontSizeAdded;
        public static double ExtraLargeSize => Device.GetNamedSize(NamedSize.Large, typeof(Label)) + FontSizeAdded;
        public static double ExtraExtraLargeSize => Device.GetNamedSize(NamedSize.Large, typeof(Label)) + 4 + FontSizeAdded;
        public static double ExtraExtraExtraLargeSize => Device.GetNamedSize(NamedSize.Large, typeof(Label)) + 12 + FontSizeAdded;

        public static double FontSizeAdded = Device.RuntimePlatform == Device.iOS ? 3 : -2;
    }
}
