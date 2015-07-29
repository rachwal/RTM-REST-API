using RESTComponent.Preview.ViewModel;

namespace RESTComponent.Preview.View
{
    public partial class ShellView
    {
        private IPreviewViewModel ViewModel
        {
            get { return (IPreviewViewModel)DataContext; }
            set { DataContext = value; }
        }

        public ShellView(IPreviewViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
