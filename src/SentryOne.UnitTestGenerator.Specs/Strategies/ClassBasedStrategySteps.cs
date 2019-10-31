﻿namespace SentryOne.UnitTestGenerator.Specs.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Formatting;
    using NUnit.Framework;
    using SentryOne.UnitTestGenerator.Core;
    using SentryOne.UnitTestGenerator.Core.Frameworks;
    using SentryOne.UnitTestGenerator.Core.Options;
    using SentryOne.UnitTestGenerator.Core.Strategies.ClassGeneration;
    using TechTalk.SpecFlow;

    [Binding]
    public class ClassBasedStrategySteps
    {
        private readonly ClassBasedStrategyContext _context;

        public ClassBasedStrategySteps(ClassBasedStrategyContext context)
        {
            _context = context;
        }

        [Given(@"an existing test class")]
        public void GivenIHaveExistingTestClass(string testClass)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(testClass);
            var compilation = CSharpCompilation.Create("MyTest", new[] { syntaxTree }, SemanticModelHelper.References.Value);
            var model = compilation.GetSemanticModel(syntaxTree);
            _context.TestModel = model;

        }

        [When(@"I generate tests for the class using strategy '(.*)'")]
        public void WhenIGenerateTestsForTheClass(string strategy)
        {
            var options = new UnitTestGeneratorOptions(new GenerationOptions(_context.TargetFramework, _context.MockFramework), new VersionOptions());
            var frameworkSet = FrameworkSetFactory.Create(options);

            IClassGenerationStrategy generationStrategy = null;
            if (strategy == "StandardClassGenerationStrategy")
            {
                generationStrategy = new StandardClassGenerationStrategy(frameworkSet);
            }

            if (strategy == "StaticClassGenerationStrategy")
            {
                generationStrategy = new StaticClassGenerationStrategy(frameworkSet);
            }

            if (strategy == "AbstractClassGenerationStrategy")
            {
                generationStrategy = new AbstractClassGenerationStrategy(frameworkSet);
            }

            if (generationStrategy == null)
            {
                throw new InvalidOperationException();
            }

            _context.Result = generationStrategy.Create(_context.ClassModel);
            _context.CurrentClass = _context.Result;
 
            using (var workspace = new AdhocWorkspace())
            {
                Console.WriteLine(Formatter.Format(_context.Result, workspace));
            }
        }

        [When(@"I regenerate tests for all constructors")]
        public async Task WhenIRegenerateTests()
        {
            var options = new UnitTestGeneratorOptions(new GenerationOptions(_context.TargetFramework, _context.MockFramework), new VersionOptions());
            var result = await CoreGenerator.Generate(_context.SemanticModel, _context.ClassModel.Constructors.First().Node, _context.TestModel, true, options, x => x + ".Tests");
            var tree = CSharpSyntaxTree.ParseText(result.FileContent, new CSharpParseOptions(LanguageVersion.Latest));

            _context.Result = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            _context.CurrentClass = _context.Result;
        }

        [Then(@"I expect a field of type '(.*)' with name '(.*)'")]
        public void ThenIExpectField(string type, string name)
        {
            bool isThere = false;
            bool fieldThere = false;
            string foundType = "none";
            var found = new List<string>();
            
            foreach (var field in _context.CurrentClass.Members.OfType<FieldDeclarationSyntax>())
            {
                foreach (var variable in field.Declaration.Variables)
                {
                    if (variable.ToString() == name)
                    {
                        fieldThere = true;
                        
                        if (field.Declaration.Type.ToString() == type)
                        {
                            isThere = true;
                            break;
                        }
                        else
                        {
                            foundType = field.Declaration.Type.ToString();
                        }
                    }
                }
                
                if (isThere)
                {
                    break;
                }
            }
            
            if (!isThere && fieldThere)
            {
                Assert.Fail("Found variable '{0}', expected type '{1}', found type '{2}'", name, type, foundType);
            }

            if (!found.Any())
            {
                found.Add("none");
            }
            
            Assert.IsTrue(isThere, "Expected to find variable '{0}', found variables '{1}'", name, found.Aggregate((x, y) => x + ", " + y));

        }

        [Then(@"I expect the method '(.*)'")]
        public void ThenIExpectAMethod(string methodName)
        {
            var isThere = _context.CurrentClass.Members.OfType<MethodDeclarationSyntax>().FindMatches(method => method.Identifier.ValueText, 
                methodName, 
                out var found,
                out var itemFound);

            _context.CurrentMethod = itemFound;
            Assert.IsTrue(isThere, "Expected method '{0}', found methods '{1}'", methodName, found.Aggregate((x, y) => x + ", " + y));
        }

        [Then(@"I expect it to contain an assignment for '(.*)'")]
        public void ThenIExpectField(string fieldName)
        {
            var isThere = _context.CurrentMethod.Body.Statements.OfType<ExpressionStatementSyntax>().Select(x => x.Expression).OfType<AssignmentExpressionSyntax>().FindMatches(
                field => field.Left.ToString(), 
                fieldName, 
                out var found, 
                out _);
            
            Assert.IsTrue(isThere, "Expected to find assignment for '{0}', found assignments for '{1}'", fieldName, found.Aggregate((x, y) => x + ", " + y));
        }

        [Then(@"I expect it to have the attribute '(.*)'")]
        public void ThenIExpectAttribute(string attributeName)
        {
            bool isThere = false;
            var found = new List<string>();

            foreach (var attributeList in _context.CurrentMethod.AttributeLists)
            {
                isThere = attributeList.Attributes.FindMatches(attribute => attribute.ToString(), attributeName, out var foundItems, out _);
                if (isThere)
                {
                    break;
                }

                foreach (var foundItem in foundItems)
                {
                    if (foundItem != "none")
                    {
                        found.Add(foundItem);
                    }
                }
            }

            if (!found.Any())
            {
                found.Add("none");
            }

            Assert.IsTrue(isThere, "Expected to find attribute '{0}', found attributes '{1}'", attributeName, found.Aggregate((x, y) => x + ", " + y));
        }

        [Then(@"I expect the class to have the modifier '(.*)'")]
        public void ThenIExpectModifier(string modifierName)
        {
            var isThere = _context.CurrentClass.Modifiers.FindMatches(modifier => modifier.ToString(),
                modifierName,
                out var found,
                out _);

            Assert.IsTrue(isThere, "Expected to find modifier '{0}', found modifiers '{1}'", modifierName, found.Aggregate((x, y) => x + ", " + y));
        }

        [Then(@"I expect the class '(.*)'")]
        public void ThenIExpectClass(string className)
        {
            var isThere = _context.Result.Members.OfType<ClassDeclarationSyntax>().FindMatches(
                classes => classes.Identifier.ValueText, 
                className, 
                out var found, 
                out var foundItem);

            _context.CurrentClass = foundItem;

            Assert.IsTrue(isThere, "Expected to find class '{0}', found classes '{1}'", className, found.Aggregate((x, y) => x + ", " + y));
        }

        [Then(@"I expect it to have the property '(.*)' of type '(.*)'")]
        public void ThenIExpectProperty(string propertyName, string type)
        {
            bool isThere = false;
            string typeFound = "none";

            var propertyThere = _context.CurrentClass.Members.OfType<PropertyDeclarationSyntax>().FindMatches(
                property => property.Identifier.ValueText,
                propertyName,
                out var found, 
                out var foundItem);
            
            if (foundItem.Type.ToString() == type)
            {
                isThere = true;
            }
            else
            {
                typeFound = foundItem.Type.ToString();
            }
            
            if (!isThere && propertyThere)
            {
                Assert.Fail("Found property '{0}', expected type '{1}', found type '{2}'", propertyName, type, typeFound);
            }
            
            Assert.IsTrue(isThere, "Expected to find property '{0}', found properties '{1}'", propertyName, found.Aggregate((x, y) => x + ", " + y));
        }

        [Then(@"I expect no method with name like '(.*)'")]
        public void ThenIExpectNoMethod(string methodName)
        {
            var matcher = new Regex(methodName);

            var isThere = _context.Result.Members.OfType<MethodDeclarationSyntax>().FindMatches(
                method => matcher.IsMatch(method.Identifier.ValueText), 
                out _);

            Assert.IsTrue(!isThere, "Expected no method called '{0}', found one", methodName);

        }

        [Then(@"I expect it to have the modifier '(.*)'")]
        public void ThenIExpectMethodModifier(string methodModifier)
        {
            var isThere = _context.CurrentMethod.Modifiers.FindMatches(
                modifier => modifier.ToString(),
                methodModifier,
                out var found,
                out _);

            Assert.IsTrue(isThere, "Expected the modifier '{0}', found modifiers '{1}'", methodModifier, found.Aggregate((x, y) => x + ", " + y));
        }

        [Then(@"I expect it to contain the parameter '(.*)'")]
        public void ThenIExpectParameter(string parameterName)
        {
            var isThere = _context.CurrentMethod.ParameterList.Parameters.FindMatches(
                parameter => parameter.Identifier.ValueText,
                parameterName,
                out var found,
                out _);
            
            Assert.IsTrue(isThere, "Expected to find parameter '{0}', found parameters '{1}'", parameterName, found.Aggregate((x, y) => x + ", " + y));
        }
    }
}