using System;using System.Collections.Generic;using PayrollSystem.Models;using ReactiveUI;namespace PayrollSystem.ViewModels;public class AddHourlyWageWorkerViewModel : ViewModelBase{    public List<HourlyWageWorker> HourlyWorkers = new List<HourlyWageWorker>();    public AddHourlyWageWorkerViewModel()    {            }    public void AddHourlyWorker()    {        if (_hourlyName == null || _hourlyGender == null || Convert.ToInt32(_normalHourlySalary) <= 0 ||            Convert.ToInt32(_overtimeHourlySalary) <= 0 || Convert.ToInt32(_standartOfHourlyWorkingHours) <= 0)            MessageBus.Current("Неправильный ввод");    }        public string? HourlyName    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _hourlyName, value);            }        }        get        {            if (_hourlyName != null)                return _hourlyName;            throw new NullReferenceException();        }    }        public string? HourlyGender    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _hourlyGender, value);            }        }        get        {            if (_hourlyGender != null)                return _hourlyGender;            throw new NullReferenceException();        }    }        public string? NormalHourlySalary    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _normalHourlySalary, value);            }        }        get        {            if (_normalHourlySalary != null)                return _normalHourlySalary;            throw new NullReferenceException();        }    }        public string? OvertimeHourlySalary    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _overtimeHourlySalary, value);            }        }        get        {            if (_overtimeHourlySalary != null)                return _overtimeHourlySalary;            throw new NullReferenceException();        }    }    public string? StandartOfHourlyWorkingHours    {        set        {            if (value != null && !string.Equals(value, ""))            {                this.RaiseAndSetIfChanged(ref _standartOfHourlyWorkingHours, value);            }        }        get        {            if (_standartOfHourlyWorkingHours != null)                return _standartOfHourlyWorkingHours;            throw new NullReferenceException();        }    }        private string? _hourlyName;    private string? _hourlyGender;    private string? _normalHourlySalary;    private string? _overtimeHourlySalary;    private string? _standartOfHourlyWorkingHours;}