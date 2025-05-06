namespace DesignPatterns;

using System;

public interface ISystemTime
{
    DateTimeOffset Now { get; }
}

public class SystemTime : ISystemTime
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
