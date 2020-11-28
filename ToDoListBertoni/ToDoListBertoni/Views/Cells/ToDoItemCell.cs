using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ToDoListBertoni.Styles;
using Xamarin.Forms;

namespace ToDoListBertoni.Views.Cells
{
    public class ToDoItemCell : ViewCell
    {
        public ToDoItemCell()
        {
            var description = new Label
            {
                FontSize = Fonts.MediumSize,
                TextColor = Colors.TextDarkPrimary,
                MaxLines = 2,
                LineBreakMode = LineBreakMode.TailTruncation,
            };

            var status = new Label
            {
                FontSize = Fonts.LargeSize,
                TextColor = Colors.Primary,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End
            };

            var divider = new BoxView
            {
                HorizontalOptions = LayoutOptions.Fill,
                HeightRequest = 1,
                Color = Colors.Divider
            };

            var content = new Grid
            {
                HorizontalOptions = LayoutOptions.Fill,
                Margin = new Thickness(Layouts.Margin, 0),
                ColumnSpacing = Layouts.Margin / 2,
                RowDefinitions =
                {
                    new RowDefinition{Height = GridLength.Auto},
                    new RowDefinition{Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star},
                    new ColumnDefinition { Width = GridLength.Auto}
                }
            };
            content.Children.Add(description, 0, 0);
            content.Children.Add(status, 1, 0);
            content.Children.Add(divider, 0, 2, 1, 2);

            description.SetBinding(Label.TextProperty, "Description");
            status.SetBinding(Label.TextProperty, "Status", converter: new StatusConverter());
            
            View = content;
        }
    }

    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Models.ToDoStatus)
                return ((Models.ToDoStatus)value) == Models.ToDoStatus.Complete ? Resources.Labels.Complete : Resources.Labels.Incomplete;
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
