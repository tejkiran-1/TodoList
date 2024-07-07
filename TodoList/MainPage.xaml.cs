using TodoList.ViewModel;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();

            BindingContext = vm;
        }

    }

}
