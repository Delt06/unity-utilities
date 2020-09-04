using NUnit.Framework;
using UnityEngine;
using UnityUtilities;

namespace UnityUtilitiesTests
{
	[TestFixture]
	public class ColorExtensionsTests
	{
		[Test, TestCase(1f, 1f, 1f, 1f), TestCase(0f, 0f, 0f, 0f), TestCase(0f, 0f, 0f, 1f),
		 TestCase(1 / 2f, 0f, 1 / 3f, 0f), TestCase(1 / 1f, 1 / 5f, 1 / 5f, 0f)]
		public void Color_Deconstruct_CorrectValues(float r, float g, float b, float a)
		{
			var color = new Color(r, g, b, a);

			var (rObtained, gObtained, bObtained, aObtained) = color;

			Assert.AreEqual(r, rObtained);
			Assert.AreEqual(g, gObtained);
			Assert.AreEqual(b, bObtained);
			Assert.AreEqual(a, aObtained);
		}

		[Test, TestCase(255, 255, 255, 255), TestCase(0, 0, 0, 0), TestCase(0, 0, 0, 255), TestCase(33, 128, 0, 0),
		 TestCase(44, 55, 187, 1)]
		public void Color32_Deconstruct_CorrectValues(byte r, byte g, byte b, byte a)
		{
			var color = new Color32(r, g, b, a);

			var (rObtained, gObtained, bObtained, aObtained) = color;

			Assert.AreEqual(r, rObtained);
			Assert.AreEqual(g, gObtained);
			Assert.AreEqual(b, bObtained);
			Assert.AreEqual(a, aObtained);
		}

		[Test, TestCase(null, null, null, null), TestCase(null, null, null, 1f), TestCase(1 / 2f, null, null, null),
		 TestCase(null, 1 / 3f, null, 0.5f), TestCase(null, null, 1f, null), TestCase(1 / 2f, 1 / 3f, null, null),
		 TestCase(null, 0f, 1 / 2f, null), TestCase(1 / 2f, null, 3f, 1 / 3f), TestCase(1 / 2f, 1 / 3f, 1 / 4f, 1 / 5f)]
		public void Color_With_ValuesChange(float? r, float? g, float? b, float? a)
		{
			var originalVector = Color.white;

			var newVector = originalVector.With(r, g, b, a);

			Assert.AreEqual(r ?? originalVector.r, newVector.r);
			Assert.AreEqual(g ?? originalVector.g, newVector.g);
			Assert.AreEqual(b ?? originalVector.b, newVector.b);
			Assert.AreEqual(a ?? originalVector.a, newVector.a);
		}

		[Test, TestCase(null, null, null, null), TestCase(null, null, null, 255), TestCase(128, null, null, null),
		 TestCase(null, 64, null, 128), TestCase(null, null, 255, null), TestCase(127, 33, null, null),
		 TestCase(null, 13, 56, null), TestCase(64, null, 33, 64), TestCase(128, 44, 55, 32)]
		public void Color32_With_ValuesChange(byte? r, byte? g, byte? b, byte? a)
		{
			var originalVector = new Color32(255, 255, 255, 255);

			var newVector = originalVector.With(r, g, b, a);

			Assert.AreEqual(r ?? originalVector.r, newVector.r);
			Assert.AreEqual(g ?? originalVector.g, newVector.g);
			Assert.AreEqual(b ?? originalVector.b, newVector.b);
			Assert.AreEqual(a ?? originalVector.a, newVector.a);
		}
	}
}