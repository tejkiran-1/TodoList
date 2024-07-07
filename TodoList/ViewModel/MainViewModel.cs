using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace TodoList.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
        }


        [ObservableProperty]
        ObservableCollection<string> items;


        [ObservableProperty]
        string text;

        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
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

    }
}
