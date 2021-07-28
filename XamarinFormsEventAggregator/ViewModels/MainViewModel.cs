using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;
using XamarinFormsEventAggregator.Events;
using XamarinFormsEventAggregator.ViewModels.Interfaces;

namespace XamarinFormsEventAggregator.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IEventAggregator _EventAggregator;
        public MvvmHelpers.Commands.Command SomarViewCommand { get; }

        string _texto;
        public string Texto
        {
            get
            {
                return _texto;
            }
            set
            {
                SetProperty(ref _texto, value);
            }
        }

        public MainViewModel(IEventAggregator eventAggregator)
        {
            _texto = "Soma 0";
            _EventAggregator = eventAggregator;

            //Registra o Evento
            eventAggregator.RegisterHandler<SomarMessage>(
       SomarHandler);

            SomarViewCommand = new MvvmHelpers.Commands.Command(async () => await SomarViewCommandExecute());
        }

        // public MainViewModel(IEventAggregator eventAggregator)
        // {
        //     _texto = "Soma 0";
        //     _EventAggregator = eventAggregator;

        //     //Registra o Evento
        //     EventAggregator.Instance.RegisterHandler<SomarMessage>(
        //SomarHandler);

        //     SomarViewCommand = new MvvmHelpers.Commands.Command(async () => await SomarViewCommandExecute());
        //  }

        

        private void SomarHandler(
    SomarMessage message)
        {
            Texto = message.Texto;
        }


        private async Task SomarViewCommandExecute()
        {
            //await Xamarin.Forms.Application.Current.
            //MainPage.Navigation.PushAsync(new SomarPage());

            await Xamarin.Forms.Application.Current.
                MainPage.Navigation.PushAsync(App.ServiceProvider.GetService<SomarPage>());
        }
    }
}
