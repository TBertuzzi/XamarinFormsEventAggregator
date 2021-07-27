using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsEventAggregator.ViewModels;
using XamarinFormsEventAggregator.ViewModels.Interfaces;

namespace XamarinFormsEventAggregator
{
    public partial class SomarPage : ContentPage
    {
        public SomarPage(ISomarViewModel viewModel = null)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
