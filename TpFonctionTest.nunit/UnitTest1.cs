using NUnit.Framework;
using TpFonction;
using System;

namespace TpFonctionTest.NUnit
{
    [TestFixture]
    public class QuadraticSolverTests
    {
        [Test]
        public void TestTwoRealRoots()
        {
            // Arrange
            double a = 1, b = -3, c = 2; // Roots are x1 = 2, x2 = 1

            // Act
            Solution result = Program.SolveQuadratic(a, b, c);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2), "Should have two real roots");
            Assert.That(result.Sol1, Is.EqualTo(2).Within(0.0001), "First root should be 2");
            Assert.That(result.Sol2, Is.EqualTo(1).Within(0.0001), "Second root should be 1");
            Assert.That(result.ComplexPart, Is.Null, "Complex part should be null for real roots");
        }

        [Test]
        public void TestOneRealRoot()
        {
            // Arrange
            double a = 1, b = -2, c = 1; // Root is x = 1

            // Act
            Solution result = Program.SolveQuadratic(a, b, c);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1), "Should have one real root");
            Assert.That(result.Sol1, Is.EqualTo(1).Within(0.0001), "Root should be 1");
            Assert.That(result.Sol2, Is.EqualTo(0), "Second solution should not be set for one root");
            Assert.That(result.ComplexPart, Is.Null, "Complex part should be null for real roots");
        }

        [Test]
        public void TestComplexRoots()
        {
            // Arrange
            double a = 1, b = 2, c = 5; // Complex roots x1 = -1 + 2i, x2 = -1 - 2i

            // Act
            Solution result = Program.SolveQuadratic(a, b, c);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2), "Should have two complex roots");
            Assert.That(result.Sol1, Is.EqualTo(-1).Within(0.0001), "Real part should be -1");
            Assert.That(result.ComplexPart, Is.EqualTo("2.00"), "Complex part should be 2.00");
        }

        [Test]
        public void TestInvalidCoefficientA()
        {
            // Arrange
            double a = 0, b = 2, c = 5; // Not a quadratic equation

            // Act & Assert
            Assert.That(() => Program.SolveQuadratic(a, b, c), Throws.TypeOf<DivideByZeroException>(), "Should throw exception when 'a' is zero");
        }
    }
}
