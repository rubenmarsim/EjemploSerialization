using IntroductionRest.ViewModels;
using Xamarin.Forms;

namespace IntroductionRest.Views
{
    public partial class SerializationView : ContentPage
    {
        private bool _hasAppearedOnce;

        private object Parameter { get; set; }

        public SerializationView(object parameter)
        {
            InitializeComponent();

            Parameter = parameter;

            BindingContext = App.Locator.SerializationViewModel;
        }

        protected override void OnAppearing()
        {
            var viewModel = BindingContext as SerializationViewModel;
            if (viewModel != null) viewModel.OnAppearing(Parameter);

            if (!_hasAppearedOnce)
            {
                _hasAppearedOnce = true;
                var padding = (NameGrid.Width - MessagesListView.Height) / 2;

                MessagesListView.HeightRequest = MessagesLayoutFrame.Width;
                MessagesLayoutFrameInner.WidthRequest = MessagesLayoutFrame.Width;
                MessagesLayoutFrameInner.Padding = new Thickness(0);
                MessagesLayoutFrame.Padding = new Thickness(0);
                MessagesLayoutFrame.IsClippedToBounds = true;
                AbsoluteLayout.SetLayoutBounds(MessagesLayoutFrameInner,
                    new Rectangle(0, 0 - padding, AbsoluteLayout.AutoSize, MessagesListView.Height - padding));
                MessagesLayoutFrameInner.IsClippedToBounds = true;
            }
        }

        protected override void OnDisappearing()
        {
            var viewModel = BindingContext as SerializationViewModel;
            if (viewModel != null) viewModel.OnDisappearing();
        }
    }
}
