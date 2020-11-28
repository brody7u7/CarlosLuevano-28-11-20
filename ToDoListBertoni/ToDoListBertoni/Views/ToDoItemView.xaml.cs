using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListBertoni.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoItemView : ContentPage
    {
        public ToDoItemView()
        {
            InitializeComponent();
        }
    }
}