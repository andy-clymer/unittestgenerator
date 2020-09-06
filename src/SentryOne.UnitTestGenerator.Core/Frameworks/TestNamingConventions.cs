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
            string stringParameterValueCheckNaming)
        {
            CanCallMethodNaming = canCallMethodNaming;
            PerformsMappingMethodNaming = performsMappingMethodNaming;
            CannotCallWithNullArgumentNaming = cannotCallWithNullArgumentNaming;
            StringParameterValueCheckNaming = stringParameterValueCheckNaming;
        }

        public string CanCallMethodNaming { get; }

        public string PerformsMappingMethodNaming { get; }

        public string CannotCallWithNullArgumentNaming { get; }

        public string StringParameterValueCheckNaming { get; }

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
                generationOptions.StringParameterValueCheckNaming);
        }
    }
}