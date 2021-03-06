// <auto-generated />
namespace IronJS.Tests.UnitTests.Sputnik.Conformance.NativeECMAScriptObjects.ArrayObjects.PropertiesOfTheArrayPrototypeObject
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ArrayPrototypeUnshiftTests : SputnikTestFixture
    {
        public ArrayPrototypeUnshiftTests()
            : base(@"Conformance\15_Native_ECMA_Script_Objects\15.4_Array_Objects\15.4.4_Properties_of_the_Array_Prototype_Object\15.4.4.13_Array_prototype_unshift")
        {
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A1_T1.js", Description = "The arguments are prepended to the start of the array, such that their order within the array is the same as the order in which they appear in the argument list")]
        [TestCase("S15.4.4.13_A1_T2.js", Description = "The arguments are prepended to the start of the array, such that their order within the array is the same as the order in which they appear in the argument list")]
        public void TheArgumentsArePrependedToTheStartOfTheArraySuchThatTheirOrderWithinTheArrayIsTheSameAsTheOrderInWhichTheyAppearInTheArgumentList(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A2_T1.js", Description = "The unshift function is intentionally generic. It does not require that its this value be an Array object")]
        [TestCase("S15.4.4.13_A2_T2.js", Description = "The unshift function is intentionally generic. It does not require that its this value be an Array object")]
        [TestCase("S15.4.4.13_A2_T3.js", Description = "The unshift function is intentionally generic. It does not require that its this value be an Array object")]
        public void TheUnshiftFunctionIsIntentionallyGenericItDoesNotRequireThatItsThisValueBeAnArrayObject(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A3_T1.js", Description = "Check ToUint32(length) for non Array objects")]
        [TestCase("S15.4.4.13_A3_T2.js", Description = "Check ToUint32(length) for non Array objects")]
        [TestCase("S15.4.4.13_A3_T3.js", Description = "Check ToUint32(length) for non Array objects")]
        public void CheckToUint32LengthForNonArrayObjects(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.13")]
        [Category("ECMA 8.6.2.1")]
        [Category("ECMA 8.6.2.5")]
        [TestCase("S15.4.4.13_A4_T1.js", Description = "[[Get]], [[Delete]] from not an inherited property")]
        [TestCase("S15.4.4.13_A4_T2.js", Description = "[[Get]], [[Delete]] from not an inherited property")]
        public void GetDeleteFromNotAnInheritedProperty(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.6.4")]
        [Category("ECMA 15.2.4.7")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A5.1.js", Description = "The length property of unshift has the attribute DontEnum")]
        public void TheLengthPropertyOfUnshiftHasTheAttributeDontEnum(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 11.4.1")]
        [Category("ECMA 15.2.4.5")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A5.2.js", Description = "The length property of unshift has the attribute DontDelete")]
        public void TheLengthPropertyOfUnshiftHasTheAttributeDontDelete(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A5.3.js", Description = "The length property of unshift has the attribute ReadOnly")]
        public void TheLengthPropertyOfUnshiftHasTheAttributeReadOnly(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A5.4.js", Description = "The length property of unshift is 1")]
        public void TheLengthPropertyOfUnshiftIs1(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.6.4")]
        [Category("ECMA 15.2.4.7")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A5.5.js", Description = "The unshift property of Array has the attribute DontEnum")]
        public void TheUnshiftPropertyOfArrayHasTheAttributeDontEnum(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A5.6.js", Description = "The unshift property of Array has not prototype property")]
        public void TheUnshiftPropertyOfArrayHasNotPrototypeProperty(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 11.2.2")]
        [Category("ECMA 15.4.4.13")]
        [TestCase("S15.4.4.13_A5.7.js", Description = "The unshift property of Array can\'t be used as constructor")]
        public void TheUnshiftPropertyOfArrayCanTBeUsedAsConstructor(string file)
        {
            RunFile(file);
        }
    }
}