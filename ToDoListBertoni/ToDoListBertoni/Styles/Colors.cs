using Color = Xamarin.Forms.Color;

namespace ToDoListBertoni.Styles
{
    public static class Colors
    {
        // Common
        public static readonly Color Primary = Color.FromHex("#24AB73");
        public static readonly Color PrimaryDark = Color.FromHex("#4CD964");
        public static readonly Color CommonBlack = Color.FromHex("#000000");
        public static readonly Color CommonWhite = Color.FromHex("#FFFFFF");
        public static readonly Color CommonGrayLight = Color.FromHex("#C1C2C3");
        public static readonly Color CommonGray = Color.FromHex("#212B36");
        public static readonly Color OKColor = Color.Green;
        public static readonly Color Precaution = Color.FromHex("#FD9726");
        public static readonly Color Danger = Color.FromHex("#B00020");
        public static readonly Color Disabled = Color.LightGray;
        public static readonly Color Divider = Color.FromHex("#F0F0F0");
        public static readonly Color EntryBorderColor = Color.Gray;
        public static readonly Color EntryBackgroundColor = Color.White;
        public static readonly Color IconTappedBackColor = Color.FromHex("#33FFFFFF");

        // Backgrounds
        public static readonly Color PrimaryLightBackground = Color.FromHex("#FFFFFF");
        public static readonly Color SecondaryLightBackground = Color.FromHex("#F2F2F2");
        public static readonly Color CellLightBackground = Color.FromHex("#FFFFFF");
        public static readonly Color PopupLightBackground = Color.FromRgba(254, 254, 254, 0.7);
        public static readonly Color PrimaryDarkBackground = Color.FromHex("#121212");
        public static readonly Color SecondaryDarkBackground = Color.FromHex("#121212");
        public static readonly Color CellDarkBackground = Color.FromHex("#202020");
        public static readonly Color PopupDarkBackground = Color.FromRgba(18, 18, 18, 0.7);

        // Texts
        public static readonly Color TextDarkPrimary = new Color(CommonBlack.R, CommonBlack.G, CommonBlack.B, 1);
        public static readonly Color TextDarkSecondary = new Color(CommonBlack.R, CommonBlack.G, CommonBlack.B, 0.87);
        public static readonly Color TextDarkHint = new Color(CommonBlack.R, CommonBlack.G, CommonBlack.B, 0.6);
        public static readonly Color TextDarkDisabled = new Color(CommonBlack.R, CommonBlack.G, CommonBlack.B, 0.38);
        public static readonly Color TextLightPrimary = new Color(CommonWhite.R, CommonWhite.G, CommonWhite.B, 1);
        public static readonly Color TextLightSecondary = new Color(CommonWhite.R, CommonWhite.G, CommonWhite.B, 0.87);
        public static readonly Color TextLightHint = new Color(CommonWhite.R, CommonWhite.G, CommonWhite.B, 0.6);
        public static readonly Color TextLightDisabled = new Color(CommonWhite.R, CommonWhite.G, CommonWhite.B, 0.38);
    }
}
