// <auto-generated />
namespace IronJS.Tests.UnitTests.Sputnik.Conformance.NativeECMAScriptObjects.ArrayObjects.PropertiesOfTheArrayPrototypeObject
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ArrayPrototypeToLocaleStringTests : SputnikTestFixture
    {
        public ArrayPrototypeToLocaleStringTests()
            : base(@"Conformance\15_Native_ECMA_Script_Objects\15.4_Array_Objects\15.4.4_Properties_of_the_Array_Prototype_Object\15.4.4.3_Array_prototype_toLocaleString")
        {
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A1_T1.js", Description = "The elements of the array are converted to strings using their toLocaleString methods, and these strings are then concatenated, separated by occurrences of a separator string that has been derived in an implementation-defined locale-specific way")]
        public void TheElementsOfTheArrayAreConvertedToStringsUsingTheirToLocaleStringMethodsAndConcatenatedInALocaleSpecificWay(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A2_T1.js", Description = "The toLocalString function is not generic. it throws a TypeError exception if its this value is not an Array object")]
        public void TheToLocalStringFunctionIsNotGenericItThrowsATypeErrorExceptionIfItsThisValueIsNotAnArrayObject(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.3")]
        [Category("ECMA 8.6.2.1")]
        [TestCase("S15.4.4.3_A3_T1.js", Description = "[[Get]] from not an inherited property")]
        public void GetFromNotAnInheritedProperty(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.6.4")]
        [Category("ECMA 15.2.4.7")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A4.1.js", Description = "The length property of toLocaleString has the attribute DontEnum")]
        public void TheLengthPropertyOfToLocaleStringHasTheAttributeDontEnum(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 11.4.1")]
        [Category("ECMA 15.2.4.5")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A4.2.js", Description = "The length property of toLocaleString has the attribute DontDelete")]
        public void TheLengthPropertyOfToLocaleStringHasTheAttributeDontDelete(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A4.3.js", Description = "The length property of toLocaleString has the attribute ReadOnly")]
        public void TheLengthPropertyOfToLocaleStringHasTheAttributeReadOnly(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A4.4.js", Description = "The length property of toLocaleString is 0")]
        public void TheLengthPropertyOfToLocaleStringIs0(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 12.6.4")]
        [Category("ECMA 15.2.4.7")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A4.5.js", Description = "The toLocaleString property of Array has the attribute DontEnum")]
        public void TheToLocaleStringPropertyOfArrayHasTheAttributeDontEnum(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A4.6.js", Description = "The toLocaleString property of Array has not prototype property")]
        public void TheToLocaleStringPropertyOfArrayHasNotPrototypeProperty(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 11.2.2")]
        [Category("ECMA 15.4.4.3")]
        [TestCase("S15.4.4.3_A4.7.js", Description = "The toLocaleString property of Array can\'t be used as constructor")]
        public void TheToLocaleStringPropertyOfArrayCanTBeUsedAsConstructor(string file)
        {
            RunFile(file);
        }
    }
}