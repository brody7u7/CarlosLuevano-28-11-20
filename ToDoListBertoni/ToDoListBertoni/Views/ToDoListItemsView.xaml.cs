﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListBertoni.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoListItems : ContentPage
    {
        public ToDoListItems()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ToDoListViewModel(this);
        }
    }
}