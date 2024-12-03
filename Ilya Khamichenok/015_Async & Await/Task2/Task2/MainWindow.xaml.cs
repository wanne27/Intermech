using System.Timers;
using System.Windows;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConnectionDB connetcionDB = new ConnectionDB();
        static CancellationTokenSource cts;
        private System.Timers.Timer aTimer;

        public MainWindow()
        {
            InitializeComponent();           
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SetTimer();
            try
            {
                cts = new CancellationTokenSource();
                textbox.Text = await connetcionDB.Connection(cts.Token);
            }
            catch(OperationCanceledException)
            {
                textbox.Text = "Экстренное отключение от БД";
            }         
            
            StopTimer();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(aTimer != null)
            {                
                Cancel();
                textbox.Text = await connetcionDB.Disconnection();
                StopTimer();
            }            
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(300);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void StopTimer()
        {
            aTimer.Stop();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => textbox.Text += " Данные получены");
        }

        private void Cancel()
        {
            cts.Cancel();
            cts.Dispose();
            cts = new CancellationTokenSource();
        }
    }
}