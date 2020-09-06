// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global - is set by VS
namespace SentryOne.UnitTestGenerator.Options
{
    using System.ComponentModel;
    using Microsoft.VisualStudio.Shell;
    using SentryOne.UnitTestGenerator.Core.Options;

    public class GenerationOptions : DialogPage, IGenerationOptions
    {
        [Category("Generation")]
        [DisplayName("Test framework type")]
        [Description("The type of test framework to use")]
        public TestFrameworkTypes FrameworkType { get; set; } = TestFrameworkTypes.NUnit3;

        [Category("Generation")]
        [DisplayName("Mocking framework type")]
        [Description("The type of mocking framework to use")]
        public MockingFrameworkType MockingFrameworkType { get; set; } = MockingFrameworkType.NSubstitute;

        [Category("Test project")]
        [DisplayName("Automatically create Tests project")]
        [Description("Test projects will be created automatically")]
        public bool CreateProjectAutomatically { get; set; } = true;

        [Category("Test project")]
        [DisplayName("Automatically add references to Tests projects")]
        [Description("References will be added to test projects automatically")]
        public bool AddReferencesAutomatically { get; set; } = true;

        [Category("Test project")]
        [DisplayName("Allow generation without target project")]
        [Description("Tests will be generated as a file outside of the scope of a project if a target project is not available")]
        public bool AllowGenerationWithoutTargetProject { get; set; } = true;

        [Category("Naming")]
        [DisplayName("Project naming convention")]
        [Description("Format string that converts the source project name to the unit test project name")]
        public string TestProjectNaming { get; set; } = "{0}.Tests";

        [Category("Naming")]
        [DisplayName("File naming convention")]
        [Description("Format string that converts the source file name to the unit test file name")]
        public string TestFileNaming { get; set; } = "{0}Tests";

        [Category("Naming")]
        [DisplayName("Type naming convention")]
        [Description("Format string that converts the source type name to the unit test type name")]
        public string TestTypeNaming { get; set; } = "{0}Tests";

        [Category("Naming")]
        [DisplayName("Main test method naming convention")]
        [Description("Format string that converts the source method name to the main unit test method name")]
        public string CanCallMethodNaming { get; set; } = "CanCall{0}";

        [Category("Naming")]
        [DisplayName("Mapping test method naming convention")]
        [Description("Format string that converts the source method name to the mapping unit test method name")]
        public string PerformsMappingMethodNaming { get; } = "{0}PerformsMapping";

        [Category("Naming")]
        [DisplayName("Null parameter check test method naming convention")]
        [Description("Format string that converts the source method and parameter name to the unit test method name")]
        public string CannotCallWithNullArgumentNaming { get; } = "CannotCall{0}WithNull{1}";

        [Category("Naming")]
        [DisplayName("String NullOrWhitespace parameter check test method naming convention")]
        [Description("Format string that converts the source method and parameter name to the unit test method name")]
        public string StringParameterValueCheckNaming { get; } = "CannotCall{0}WithInvalid{1}";
    }
}