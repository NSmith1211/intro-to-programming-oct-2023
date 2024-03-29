﻿namespace DemoApi.Services;

public class UpdatedFeeCalculator : ICalculateFees
{
    private readonly ISystemTime _systemTime;

    public UpdatedFeeCalculator(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    public decimal GetCurrentFee()
    {
        var localNow = _systemTime.GetCurrent().ToLocalTime();
        var isWeekend = localNow.DayOfWeek == DayOfWeek.Sunday || localNow.DayOfWeek == DayOfWeek.Saturday;

        return isWeekend ? 0.02M : 0.04M;
    }
}
