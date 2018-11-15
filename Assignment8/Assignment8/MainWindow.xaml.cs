using System;
using System.Windows;
using System.Windows.Controls;
using EventTimer;

namespace Assignment8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            DataContext = new TimeManager();
            InitializeComponent();
        }

        private void StartButton_OnClick()
        {
            bool success = ((TimeManager)DataContext).StartTimer();
            if (!success)
            {
                Warning = "Failed to start timer, timer already running!";
            }
            else
            {
                //start a timer to update elasped time with current interval
            }
        }

        private void StopButton_OnClick()
        {
            bool success = ((TimeManager)DataContext).EndTimer();
            if (!success)
            {
                Warning = "Failed to stop timer, no timer running!";
            }
            else
            {
                string description = DescriptionText.Text;
                TimeSpan duration = ((TimeManager)DataContext).TimeElapsed;
                Event e = new Event(description, duration);
                ListBox.Items.Add(e.ToString());
                //set timer text to be 00:00:00
                DescriptionText.Text = "";
            }
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

        private struct Event
        {
            public Event(string d, TimeSpan t)
            {
                Description = d;
                Duration = t;
            }
            public TimeSpan Duration { get; private set; }
            public string Description { get; private set; }
            public override string ToString()
            {
                return $"{Duration.ToString()} : {Description}";
            }
        }

    }
}
