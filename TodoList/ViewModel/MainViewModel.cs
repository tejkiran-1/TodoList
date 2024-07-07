using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace TodoList.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;

        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }


        [ObservableProperty]
        ObservableCollection<string> items;


        [ObservableProperty]
        string text;

        [RelayCommand]
        async Task Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return;
            }

            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Oops", "No internet connection", "OK");
                return;
            }

            Items.Add(text);
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string text)
        {
            if (Items.Contains(text))
            {
                Items.Remove(text);
            }
        }

        [RelayCommand]
        async Task Tap(string text)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?id={text}");
        }

    }
}
