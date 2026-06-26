using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucther_app.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>(object parameter = null) where TViewModel : class;
        void NavigateTo(Type viewModelType, object parameter = null);
        void GoBack();
        bool CanGoBack { get; }
    }
}
