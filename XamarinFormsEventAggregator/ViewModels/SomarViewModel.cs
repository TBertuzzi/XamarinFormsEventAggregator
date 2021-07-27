using System;
using System.Threading.Tasks;
using MvvmHelpers;
using XamarinFormsEventAggregator.Events;
using XamarinFormsEventAggregator.ViewModels.Interfaces;

namespace XamarinFormsEventAggregator.ViewModels
{
    public class SomarViewModel : BaseViewModel, ISomarViewModel
    {
        private readonly IEventAggregator _EventAggregator;
        public MvvmHelpers.Commands.Command SomarCommand { get; }
        int _cont = 0;

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


        public SomarViewModel(IEventAggregator eventAggregator)
        {
            _texto = "Soma 0";

            _EventAggregator = eventAggregator;

            SomarCommand = new MvvmHelpers.Commands.Command(async () => await SomarCommandExecute());
        }

        private async Task SomarCommandExecute()
        {
            _cont++;
            var texto = $"Soma {_cont}";
            Texto = texto;

            var SomarMessage = new SomarMessage
            {
                Texto = texto
            };

            _EventAggregator.SendMessage(SomarMessage);

        }
    }
}
