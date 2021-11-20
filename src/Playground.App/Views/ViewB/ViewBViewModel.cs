﻿using Prism.Mvvm;
using Prism.Regions;

namespace Playground.App.Views.ViewB
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        #region MvvmBindings
        private string _title = "View B";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private int _pageViews;

        public int PageViews
        {
            get => _pageViews;
            set => SetProperty(ref _pageViews, value);
        }
        #endregion

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
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