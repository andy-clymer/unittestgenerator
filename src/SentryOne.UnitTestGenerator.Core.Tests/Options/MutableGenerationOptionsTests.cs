namespace SentryOne.UnitTestGenerator.Core.Tests.Options
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using SentryOne.UnitTestGenerator.Core.Options;

    [TestFixture]
    public class MutableGenerationOptionsTests
    {
        private MutableGenerationOptions _testClass;
        private IGenerationOptions _options;

        [SetUp]
        public void SetUp()
        {
            _options = Substitute.For<IGenerationOptions>();
            _testClass = new MutableGenerationOptions(_options);
        }

        [Test]
        public void CanConstruct()
        {
            _options.FrameworkType.Returns(TestFrameworkTypes.NUnit3);
            _options.MockingFrameworkType.Returns(MockingFrameworkType.Moq);
            _options.CreateProjectAutomatically.Returns(false);
            _options.AddReferencesAutomatically.Returns(true);
            _options.AllowGenerationWithoutTargetProject.Returns(true);
            _options.TestProjectNaming.Returns("tpn");
            _options.TestFileNaming.Returns("tfn");
            _options.TestTypeNaming.Returns("ttn");

            _testClass = new MutableGenerationOptions(_options);
            Assert.That(_testClass.FrameworkType, Is.EqualTo(_options.FrameworkType));
            Assert.That(_testClass.MockingFrameworkType, Is.EqualTo(_options.MockingFrameworkType));
            Assert.That(_testClass.CreateProjectAutomatically, Is.EqualTo(_options.CreateProjectAutomatically));
            Assert.That(_testClass.AddReferencesAutomatically, Is.EqualTo(_options.AddReferencesAutomatically));
            Assert.That(_testClass.AllowGenerationWithoutTargetProject, Is.EqualTo(_options.AllowGenerationWithoutTargetProject));
            Assert.That(_testClass.TestProjectNaming, Is.EqualTo(_options.TestProjectNaming));
            Assert.That(_testClass.TestFileNaming, Is.EqualTo(_options.TestFileNaming));
            Assert.That(_testClass.TestTypeNaming, Is.EqualTo(_options.TestTypeNaming));
        }

        [Test]
        public void CannotConstructWithNullOptions()
        {
            Assert.Throws<ArgumentNullException>(() => new MutableGenerationOptions(default(IGenerationOptions)));
        }

        [Test]
        public void CanSetAndGetFrameworkType()
        {
            var testValue = TestFrameworkTypes.XUnit;
            _testClass.FrameworkType = testValue;
            Assert.That(_testClass.FrameworkType, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetMockingFrameworkType()
        {
            var testValue = MockingFrameworkType.Moq;
            _testClass.MockingFrameworkType = testValue;
            Assert.That(_testClass.MockingFrameworkType, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetCreateProjectAutomatically()
        {
            var testValue = false;
            _testClass.CreateProjectAutomatically = testValue;
            Assert.That(_testClass.CreateProjectAutomatically, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAddReferencesAutomatically()
        {
            var testValue = false;
            _testClass.AddReferencesAutomatically = testValue;
            Assert.That(_testClass.AddReferencesAutomatically, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAllowGenerationWithoutTargetProject()
        {
            var testValue = true;
            _testClass.AllowGenerationWithoutTargetProject = testValue;
            Assert.That(_testClass.AllowGenerationWithoutTargetProject, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTestProjectNaming()
        {
            var testValue = "TestValue2008824805";
            _testClass.TestProjectNaming = testValue;
            Assert.That(_testClass.TestProjectNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTestFileNaming()
        {
            var testValue = "TestValue1629131383";
            _testClass.TestFileNaming = testValue;
            Assert.That(_testClass.TestFileNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTestTypeNaming()
        {
            var testValue = "TestValue609453222";
            _testClass.TestTypeNaming = testValue;
            Assert.That(_testClass.TestTypeNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetCanCallMethodNaming()
        {
            var testValue = "TestValue368040285";
            _testClass.CanCallMethodNaming = testValue;
            Assert.That(_testClass.CanCallMethodNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPerformsMappingMethodNaming()
        {
            var testValue = "TestValue665277815";
            _testClass.PerformsMappingMethodNaming = testValue;
            Assert.That(_testClass.PerformsMappingMethodNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetCannotCallWithNullArgumentNaming()
        {
            var testValue = "TestValue1549359554";
            _testClass.CannotCallWithNullArgumentNaming = testValue;
            Assert.That(_testClass.CannotCallWithNullArgumentNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetStringParameterValueCheckNaming()
        {
            var testValue = "TestValue1629328489";
            _testClass.StringParameterValueCheckNaming = testValue;
            Assert.That(_testClass.StringParameterValueCheckNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetCanSetNaming()
        {
            var testValue = "TestValue2136908242";
            _testClass.CanSetNaming = testValue;
            Assert.That(_testClass.CanSetNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetCanGetNaming()
        {
            var testValue = "TestValue747518191";
            _testClass.CanGetNaming = testValue;
            Assert.That(_testClass.CanGetNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetCanSetAndGetNaming()
        {
            var testValue = "TestValue1072006168";
            _testClass.CanSetAndGetNaming = testValue;
            Assert.That(_testClass.CanSetAndGetNaming, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetIsInitializedCorrectlyNaming()
        {
            var testValue = "TestValue1750846796";
            _testClass.IsInitializedCorrectlyNaming = testValue;
            Assert.That(_testClass.IsInitializedCorrectlyNaming, Is.EqualTo(testValue));
        }
    }
}