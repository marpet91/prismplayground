using System;
using System.Windows;
using Playground.App.Views.HandMode;
using Playground.App.Views.Print;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Playground.App.Views.Main
{
    public class MainWindowViewModel : BindableBase, INavigationAware
    {
        private string _title = "STEA Playground Application";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; }
        public DelegateCommand PrintViewCommand { get; }
        public DelegateCommand HandModeViewCommand { get; }

        private WindowStyle _windowStyle;
        public WindowStyle WindowStyle
        {
            get => _windowStyle;
            set => SetProperty(ref _windowStyle, value);
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));
            NavigateCommand = new DelegateCommand<string>(Navigate);
            PrintViewCommand = new DelegateCommand(NaviagateToPrintView);
            HandModeViewCommand = new DelegateCommand(NavigateToHandModeView);
#if DEBUG
            WindowStyle = WindowStyle.SingleBorderWindow;
#else
            WindowStyle = WindowStyle.None;
#endif
        }
        
        private void NavigateToHandModeView()
        {
            _regionManager.RequestNavigate(GlobalDefinitions.ContentRegion, nameof(HandModeView));
        }

        private void NaviagateToPrintView()
        {
            _regionManager.RequestNavigate(GlobalDefinitions.ContentRegion, nameof(PrintView));
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                _regionManager.RequestNavigate(GlobalDefinitions.ContentRegion, navigatePath);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _regionManager.RequestNavigate(GlobalDefinitions.ContentRegion, nameof(PrintView));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}