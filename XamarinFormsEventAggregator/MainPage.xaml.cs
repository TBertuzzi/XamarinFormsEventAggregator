using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsEventAggregator.ViewModels;
using XamarinFormsEventAggregator.ViewModels.Interfaces;

namespace XamarinFormsEventAggregator
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IMainViewModel viewModel = null)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}
