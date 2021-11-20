using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Playground.App.Views.Main
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "STEA Playground Application";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }
        
        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }
    }
}