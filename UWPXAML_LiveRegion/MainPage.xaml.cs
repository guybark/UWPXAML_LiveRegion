using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace UWPXAML_LiveRegion
{
    public sealed partial class MainPage : Page
    {
        private int currentStatus = 1;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            LiveStatusTB.Text = "Status is now " + currentStatus.ToString();
            ++currentStatus;

            var peer = FrameworkElementAutomationPeer.FromElement(LiveStatusTB);
            if (peer != null)
            {
                peer.RaiseAutomationEvent(AutomationEvents.LiveRegionChanged);
            }
        }
    }
}
