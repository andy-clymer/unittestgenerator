namespace SentryOne.UnitTestGenerator.Core.Tests.Frameworks
{
    using System;
    using NSubstitute;
    using NUnit.Framework;
    using SentryOne.UnitTestGenerator.Core.Frameworks;
    using SentryOne.UnitTestGenerator.Core.Options;

    [TestFixture]
    public class TestNamingConventionsTests
    {
        private TestNamingConventions _testClass;
        private string _canCallMethodNaming;
        private string _performsMappingMethodNaming;
        private string _cannotCallWithNullArgumentNaming;
        private string _stringParameterValueCheckNaming;
        private string _canSetNaming;
        private string _canGetNaming;
        private string _canSetAndGetNaming;
        private string _isInitializedCorrectlyNaming;

        [SetUp]
        public void SetUp()
        {
            _canCallMethodNaming = "TestValue576294662";
            _performsMappingMethodNaming = "TestValue1084983512";
            _cannotCallWithNullArgumentNaming = "TestValue279261641";
            _stringParameterValueCheckNaming = "TestValue1356791503";
            _canSetNaming = "TestValue392980600";
            _canGetNaming = "TestValue2010235928";
            _canSetAndGetNaming = "TestValue1510925385";
            _isInitializedCorrectlyNaming = "TestValue1643985030";
            _testClass = new TestNamingConventions(_canCallMethodNaming, _performsMappingMethodNaming, _cannotCallWithNullArgumentNaming, _stringParameterValueCheckNaming, _canSetNaming, _canGetNaming, _canSetAndGetNaming, _isInitializedCorrectlyNaming);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new TestNamingConventions(_canCallMethodNaming, _performsMappingMethodNaming, _cannotCallWithNullArgumentNaming, _stringParameterValueCheckNaming, _canSetNaming, _canGetNaming, _canSetAndGetNaming, _isInitializedCorrectlyNaming);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallFromGenerationOptions()
        {
            var generationOptions = Substitute.For<IGenerationOptions>();

            var result = TestNamingConventions.FromGenerationOptions(generationOptions);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void CannotCallFromGenerationOptionsWithNullGenerationOptions()
        {
            Assert.Throws<ArgumentNullException>(() => TestNamingConventions.FromGenerationOptions(default(IGenerationOptions)));
        }

        [Test]
        public void FromGenerationOptionsPerformsMapping()
        {
            var generationOptions = Substitute.For<IGenerationOptions>();
            generationOptions.CannotCallWithNullArgumentNaming.Returns("Value1");
            generationOptions.CanCallMethodNaming.Returns("Value2");
            generationOptions.CanSetAndGetNaming.Returns("Value3");
            generationOptions.CanSetNaming.Returns("Value4");
            generationOptions.CanGetNaming.Returns("Value5");
            generationOptions.IsInitializedCorrectlyNaming.Returns("Value6");
            generationOptions.PerformsMappingMethodNaming.Returns("Value7");
            generationOptions.StringParameterValueCheckNaming.Returns("Value8");

            var result = TestNamingConventions.FromGenerationOptions(generationOptions);

            Assert.That(result.CanCallMethodNaming, Is.EqualTo(generationOptions.CanCallMethodNaming));
            Assert.That(result.PerformsMappingMethodNaming, Is.EqualTo(generationOptions.PerformsMappingMethodNaming));
            Assert.That(result.CannotCallWithNullArgumentNaming, Is.EqualTo(generationOptions.CannotCallWithNullArgumentNaming));
            Assert.That(result.StringParameterValueCheckNaming, Is.EqualTo(generationOptions.StringParameterValueCheckNaming));
            Assert.That(result.CanSetNaming, Is.EqualTo(generationOptions.CanSetNaming));
            Assert.That(result.CanGetNaming, Is.EqualTo(generationOptions.CanGetNaming));
            Assert.That(result.CanSetAndGetNaming, Is.EqualTo(generationOptions.CanSetAndGetNaming));
            Assert.That(result.IsInitializedCorrectlyNaming, Is.EqualTo(generationOptions.IsInitializedCorrectlyNaming));
        }

        [Test]
        public void CanCallMethodNamingIsInitializedCorrectly()
        {
            Assert.That(_testClass.CanCallMethodNaming, Is.EqualTo(_canCallMethodNaming));
        }

        [Test]
        public void PerformsMappingMethodNamingIsInitializedCorrectly()
        {
            Assert.That(_testClass.PerformsMappingMethodNaming, Is.EqualTo(_performsMappingMethodNaming));
        }

        [Test]
        public void CannotCallWithNullArgumentNamingIsInitializedCorrectly()
        {
            Assert.That(_testClass.CannotCallWithNullArgumentNaming, Is.EqualTo(_cannotCallWithNullArgumentNaming));
        }

        [Test]
        public void StringParameterValueCheckNamingIsInitializedCorrectly()
        {
            Assert.That(_testClass.StringParameterValueCheckNaming, Is.EqualTo(_stringParameterValueCheckNaming));
        }

        [Test]
        public void CanSetNamingIsInitializedCorrectly()
        {
            Assert.That(_testClass.CanSetNaming, Is.EqualTo(_canSetNaming));
        }

        [Test]
        public void CanGetNamingIsInitializedCorrectly()
        {
            Assert.That(_testClass.CanGetNaming, Is.EqualTo(_canGetNaming));
        }

        [Test]
        public void CanSetAndGetNamingIsInitializedCorrectly()
        {
            Assert.That(_testClass.CanSetAndGetNaming, Is.EqualTo(_canSetAndGetNaming));
        }

        [Test]
        public void IsInitializedCorrectlyNamingIsInitializedCorrectly()
        {
            Assert.That(_testClass.IsInitializedCorrectlyNaming, Is.EqualTo(_isInitializedCorrectlyNaming));
        }
    }
}