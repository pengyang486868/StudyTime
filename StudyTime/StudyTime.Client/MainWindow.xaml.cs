using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace StudyTime.Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _currentTimeSpan = TimeSpan.Zero;

            SetTimer();
        }

        private Timer _timer;
        private void SetTimer()
        {
            _timer = new Timer(500);
            _timer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            _timer.AutoReset = true;
            _timer.Enabled = false;
        }

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {            
            _currentTimeSpan = _lastTimeSpan + (DateTime.Now - _continueTime);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentTimeSpan"));
        }

        private TimeSpan _lastTimeSpan;
        private TimeSpan _currentTimeSpan;
        public TimeSpan CurrentTimeSpan
        {
            get { return _currentTimeSpan; }
            set
            {
                _currentTimeSpan = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentTimeSpan"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime _continueTime;

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Enabled = false;
            _lastTimeSpan = TimeSpan.FromTicks(_currentTimeSpan.Ticks);
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            _continueTime = DateTime.Now;
            _timer.Enabled = true;
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new InfoWindow();
            wnd.Show();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
