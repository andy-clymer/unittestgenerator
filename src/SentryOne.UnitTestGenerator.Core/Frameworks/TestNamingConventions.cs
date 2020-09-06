namespace SentryOne.UnitTestGenerator.Core.Frameworks
{
    using System;
    using SentryOne.UnitTestGenerator.Core.Options;

    public class TestNamingConventions : ITestNamingConventions
    {
        public TestNamingConventions(
            string canCallMethodNaming,
            string performsMappingMethodNaming,
            string cannotCallWithNullArgumentNaming,
            string stringParameterValueCheckNaming,
            string canSetNaming,
            string canGetNaming,
            string canSetAndGetNaming,
            string isInitializedCorrectlyNaming)
        {
            CanCallMethodNaming = canCallMethodNaming;
            PerformsMappingMethodNaming = performsMappingMethodNaming;
            CannotCallWithNullArgumentNaming = cannotCallWithNullArgumentNaming;
            StringParameterValueCheckNaming = stringParameterValueCheckNaming;
            CanSetNaming = canSetNaming;
            CanGetNaming = canGetNaming;
            CanSetAndGetNaming = canSetAndGetNaming;
            IsInitializedCorrectlyNaming = isInitializedCorrectlyNaming;
        }

        public string CanCallMethodNaming { get; }

        public string PerformsMappingMethodNaming { get; }

        public string CannotCallWithNullArgumentNaming { get; }

        public string StringParameterValueCheckNaming { get; }

        public string CanSetNaming { get; }

        public string CanGetNaming { get; }

        public string CanSetAndGetNaming { get; }

        public string IsInitializedCorrectlyNaming { get; }

        public static TestNamingConventions FromGenerationOptions(IGenerationOptions generationOptions)
        {
            if (generationOptions == null)
            {
                throw new ArgumentNullException(nameof(generationOptions));
            }

            return new TestNamingConventions(
                generationOptions.CanCallMethodNaming,
                generationOptions.PerformsMappingMethodNaming,
                generationOptions.CannotCallWithNullArgumentNaming,
                generationOptions.StringParameterValueCheckNaming,
                generationOptions.CanSetNaming,
                generationOptions.CanGetNaming,
                generationOptions.CanSetAndGetNaming,
                generationOptions.IsInitializedCorrectlyNaming);
        }
    }
}