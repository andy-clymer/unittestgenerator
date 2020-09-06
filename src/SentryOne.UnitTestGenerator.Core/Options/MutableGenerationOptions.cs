namespace SentryOne.UnitTestGenerator.Core.Options
{
    using System;

    public class MutableGenerationOptions : IGenerationOptions
    {
        public MutableGenerationOptions(IGenerationOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            FrameworkType = options.FrameworkType;
            MockingFrameworkType = options.MockingFrameworkType;
            CreateProjectAutomatically = options.CreateProjectAutomatically;
            AddReferencesAutomatically = options.AddReferencesAutomatically;
            AllowGenerationWithoutTargetProject = options.AllowGenerationWithoutTargetProject;
            TestProjectNaming = options.TestProjectNaming;
            TestFileNaming = options.TestFileNaming;
            TestTypeNaming = options.TestTypeNaming;
            CanCallMethodNaming = options.CanCallMethodNaming;
            PerformsMappingMethodNaming = options.PerformsMappingMethodNaming;
            CannotCallWithNullArgumentNaming = options.CannotCallWithNullArgumentNaming;
            StringParameterValueCheckNaming = options.StringParameterValueCheckNaming;
            CanSetNaming = options.CanSetNaming;
            CanGetNaming = options.CanGetNaming;
            CanSetAndGetNaming = options.CanSetAndGetNaming;
            IsInitializedCorrectlyNaming = options.IsInitializedCorrectlyNaming;
        }

        public TestFrameworkTypes FrameworkType { get; set; }

        public MockingFrameworkType MockingFrameworkType { get; set; }

        public bool CreateProjectAutomatically { get; set; }

        public bool AddReferencesAutomatically { get; set; }

        public bool AllowGenerationWithoutTargetProject { get; set; }

        public string TestProjectNaming { get; set; }

        public string TestFileNaming { get; set; }

        public string TestTypeNaming { get; set; }

        public string CanCallMethodNaming { get; set; }

        public string PerformsMappingMethodNaming { get; set; }

        public string CannotCallWithNullArgumentNaming { get; set; }

        public string StringParameterValueCheckNaming { get; set; }

        public string CanSetNaming { get; set; }

        public string CanGetNaming { get; set; }

        public string CanSetAndGetNaming { get; set; }

        public string IsInitializedCorrectlyNaming { get; set; }
    }
}