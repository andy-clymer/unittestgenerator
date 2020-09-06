namespace SentryOne.UnitTestGenerator.Core.Frameworks
{
    public interface ITestNamingConventions
    {
        string CanCallMethodNaming { get; }

        string PerformsMappingMethodNaming { get; }

        string CannotCallWithNullArgumentNaming { get; }

        string StringParameterValueCheckNaming { get; }
    }
}