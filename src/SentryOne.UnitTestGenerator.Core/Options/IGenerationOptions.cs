namespace SentryOne.UnitTestGenerator.Core.Options
{
    public interface IGenerationOptions
    {
        TestFrameworkTypes FrameworkType { get; }

        MockingFrameworkType MockingFrameworkType { get; }

        bool CreateProjectAutomatically { get; }

        bool AddReferencesAutomatically { get; }

        bool AllowGenerationWithoutTargetProject { get; }

        string TestProjectNaming { get; }

        string TestFileNaming { get; }

        string TestTypeNaming { get; }

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