namespace SentryOne.UnitTestGenerator.Core.Frameworks
{
    public interface ITestNamingConventions
    {
        string CanCallMethodNaming { get; }

        string PerformsMappingMethodNaming { get; }

        string CannotCallWithNullArgumentNaming { get; }

        string StringParameterValueCheckNaming { get; }

        string CanSetNaming { get; }

        string CanGetNaming { get; }

        string CanSetAndGetNaming { get; }

        string IsInitializedCorrectlyNaming { get; }
    }
}