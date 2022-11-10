using System;using System.Collections.ObjectModel;using System.Reactive;using PayrollSystem.Models;using ReactiveUI;namespace PayrollSystem.ViewModels;public class AddHourlyWageWorkerViewModel : ViewModelBase{    private string? _hourlyName;    private string? _hourlyGender;    private string? _normalHourlySalary;    private string? _overtimeHourlySalary;    private string? _standartOfHourlyWorkingHours;        public ObservableCollection<HourlyWageWorker> HourlyWorkers { get; set; }    public ObservableCollection<HourlyWageWorker> _HourlyWageWorkers { get; set; }    public ReactiveCommand<Unit, Unit> AddHourlyWorkers { get; }    public AddHourlyWageWorkerViewModel()    {        HourlyWorkers = new ObservableCollection<HourlyWageWorker>();        _HourlyWageWorkers = new ObservableCollection<HourlyWageWorker>();        AddHourlyWorkers = ReactiveCommand.Create(() =>        {            HourlyWorkers.Clear();            for (int iterator = 0; iterator < _HourlyWageWorkers.Count; iterator++)            {                HourlyWorkers.Add(                    _HourlyWageWorkers[iterator]                );            }        });    }    public void AddHourlyWorker()    {        if (CheckEquilName(_hourlyName) && CheckNullString(_hourlyName) && CheckNullString(_hourlyGender) &&            CheckRightNumber(_normalHourlySalary) &&            CheckRightNumber(_overtimeHourlySalary) && CheckRightNumber(_standartOfHourlyWorkingHours) && CheckRightGender(_hourlyGender))        {            HourlyWorkers.Add(                new HourlyWageWorker()                {                    FullName = _hourlyName,                    Gender = _hourlyGender,                    NormalSalary = Convert.ToInt32(_normalHourlySalary),                    OvertimeSalary = Convert.ToInt32(_overtimeHourlySalary),                    StandartOfWorkingHours = Convert.ToInt32(_standartOfHourlyWorkingHours)                });            _HourlyWageWorkers.Add(                new HourlyWageWorker()                {                    FullName = _hourlyName,                    Gender = _hourlyGender,                    NormalSalary = Convert.ToInt32(_normalHourlySalary),                    OvertimeSalary = Convert.ToInt32(_overtimeHourlySalary),                    StandartOfWorkingHours = Convert.ToInt32(_standartOfHourlyWorkingHours)                });        }    }    private bool CheckRightNumber(string num)    {        if (int.TryParse(num, out int numericValue) && num[0] != '-') return true;        return false;    }        private bool CheckRightGender(string gender)    {        if (gender == "Male" || gender == "Female") return true;        return false;    }        public void FireWorker(string name)    {        for (int iterator = 0; iterator < _HourlyWageWorkers.Count; iterator++)        {            if (_HourlyWageWorkers[iterator].FullName == name)            {                _HourlyWageWorkers.RemoveAt(iterator);            }        }    }        private bool CheckNullString(string? str)    {        if (String.IsNullOrEmpty(str))        {            return false;        }        return true;    }        private bool CheckEquilName(string? name)    {        for (int iterator = 0; iterator < HourlyWorkers.Count; iterator++)        {            if (name == HourlyWorkers[iterator].FullName) return false;        }        return true;    }        public string HourlyName    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _hourlyName, value);            }        }        get        {            if (_hourlyName != null)                return _hourlyName;            throw new NullReferenceException();        }    }        public string? HourlyGender    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _hourlyGender, value);            }        }            get        {            if (_hourlyGender != null)                return _hourlyGender;                throw new NullReferenceException();        }    }        public string? NormalHourlySalary    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _normalHourlySalary, value);            }        }        get        {            if (_normalHourlySalary != null)                return _normalHourlySalary;            throw new NullReferenceException();        }    }        public string? OvertimeHourlySalary    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _overtimeHourlySalary, value);            }        }        get        {            if (_overtimeHourlySalary != null)                return _overtimeHourlySalary;            throw new NullReferenceException();        }    }    public string? StandartOfHourlyWorkingHours    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _standartOfHourlyWorkingHours, value);            }        }        get        {            if (_standartOfHourlyWorkingHours != null)                return _standartOfHourlyWorkingHours;            throw new NullReferenceException();        }    }}