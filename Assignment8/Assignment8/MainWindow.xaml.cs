using System;
using System.Windows;
using System.Windows.Controls;
using EventTimer;
using static EventTimer.TimeManager;

namespace Assignment8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            DataContext = new TimeManager(AddListBoxItem);
            InitializeComponent();
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool success = ((TimeManager)DataContext).StartTimer();
            Warning = success ? "" : "Failed to start timer, timer already running!";
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            bool success = ((TimeManager)DataContext).EndTimer(DescriptionText.Text);
            Warning = success ? "":"Failed to stop timer, no timer running!" ;
        }

        private string Warning
        {
            get => _Warning;
            set
            {
                if (value != _Warning)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        WarningText.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        WarningText.Text = value;
                        WarningText.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        private string _Warning;

        public void AddListBoxItem(TimeEvent e)
        {
 
            ItemList.Items.Add(e);
        }

        public void RemoveListBoxItem(object sender, RoutedEventArgs args)
        {
            Button toRemove = (Button)sender;
            if (toRemove.DataContext is TimeEvent e)
            {
                ItemList.Items.Remove(e);
            }
        }

    }
}
