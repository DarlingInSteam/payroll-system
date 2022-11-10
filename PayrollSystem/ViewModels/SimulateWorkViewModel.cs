using System;using Avalonia.Interactivity;using ReactiveUI;namespace PayrollSystem.ViewModels;public class SimulateWorkViewModel : ViewModelBase{    private int _workedDaysCount = 0;    private int _expenses = 0;    private string _workedDays;    private string _expen;    private const int MaxPrice = 15000;    private const int WorkingCycle = 15;    private string _days;    private AddHourlyWageWorkerViewModel _hourlyWorkers;    private AddComissionWageWorkerViewModel _comissionWorkers;    public string Expenses    {        set => this.RaiseAndSetIfChanged(ref _expen, value);         get => _expen;     }    public string WorkedDaysCount     {        set => this.RaiseAndSetIfChanged(ref _workedDays, value);         get => _workedDays;     }    public SimulateWorkViewModel(AddHourlyWageWorkerViewModel addHourlyWageWorkerViewModel, AddComissionWageWorkerViewModel addComissionWageWorkerViewModel)    {        _hourlyWorkers = addHourlyWageWorkerViewModel;        _comissionWorkers = addComissionWageWorkerViewModel;    }    public void SimulateWork()    {        if (int.TryParse(_days, out int numericValue) && _days[0] != '-' && _days[0] != '0'                                                      && (_hourlyWorkers._HourlyWageWorkers.Count != 0 || _comissionWorkers._comissionWageWorkers.Count != 0))        {            int days = Convert.ToInt32(_days);            var randomNumbers = new Random(Environment.TickCount);            for (int workedDays = 0; workedDays < days; workedDays++)            {                foreach (var worker in _hourlyWorkers._HourlyWageWorkers)                {                    //Worker workerReferense = worker;                    worker.Work(randomNumbers.Next() % MaxPrice);                }                _workedDaysCount++;                if (_workedDaysCount % WorkingCycle == 0)                {                    foreach (var worker in _hourlyWorkers._HourlyWageWorkers)                        _expenses += worker.CalculateWage();                }            }            for (int workedDays = 0; workedDays < days; workedDays++)            {                foreach (var worker in _comissionWorkers._comissionWageWorkers)                {                    //Worker workerReferense = worker;                    worker.Work(randomNumbers.Next() % MaxPrice);                }                _workedDaysCount++;                if (_workedDaysCount % WorkingCycle == 0)                {                    foreach (var worker in _comissionWorkers._comissionWageWorkers)                        _expenses += worker.CalculateWage();                }            }            _workedDaysCount %= 15;            WorkedDaysCount = Convert.ToString(_workedDaysCount);            _workedDays = Convert.ToString(_workedDaysCount);            Expenses = Convert.ToString(_expenses);            _expen = Convert.ToString(_expenses);            _workedDaysCount = 0;            _expenses = 0;        }        else        {            var messageBox = MessageBox.Avalonia.MessageBoxManager                .GetMessageBoxStandardWindow("Ошибка ввода", "Неправильно задано число или не заданы работники");            messageBox.Show();        }    }            public string? Days    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _days, value);            }        }            get        {            if (_days != null)                return _days;                throw new NullReferenceException();        }    }}