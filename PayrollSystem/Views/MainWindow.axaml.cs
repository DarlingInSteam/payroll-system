using Avalonia.Controls;using PayrollSystem.ViewModels;namespace PayrollSystem.Views{    public partial class MainWindow : Window    {        public MainWindow()        {            InitializeComponent();            DataContext = new MainWindowViewModel();        }    }}