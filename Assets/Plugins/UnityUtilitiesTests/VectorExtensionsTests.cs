using NUnit.Framework;
using UnityEngine;
using UnityUtilities;

namespace UnityUtilitiesTests
{
    [TestFixture]
    public class VectorExtensionsTests
    {
        [Test]
        [TestCase(0f, 0f, 0f)]
        [TestCase(0f, 0f, 1f)]
        [TestCase(0f, 0f, -2f)]
        [TestCase(0f, 2f, 0f)]
        [TestCase(0f, -1f, 0f)]
        [TestCase(5f, 0f, 0f)]
        [TestCase(-3f, 0f, 0f)]
        [TestCase(1f, 2f, 3f)]
        [TestCase(-1f, 3f, 0f)]
        public void Vector3_Deconstruct_CorrectValues(float x, float y, float z)
        {
            var vector = new Vector3(x, y, z);
            
            var (xOther, yOther, zOther) = vector;
            
            Assert.AreEqual(x, xOther);
            Assert.AreEqual(y, yOther);
            Assert.AreEqual(z, zOther);
        }
        
        [Test]
        [TestCase(0f, 0f)]
        [TestCase(0f, 2f)]
        [TestCase(0f, -1f)]
        [TestCase(5f, 0f)]
        [TestCase(-3f, 0f)]
        [TestCase(1f, 2f)]
        [TestCase(-1f, 3f)]
        public void Vector2_Deconstruct_CorrectValues(float x, float y)
        {
            var vector = new Vector2(x, y);
            
            var (xOther, yOther) = vector;
            
            Assert.AreEqual(x, xOther);
            Assert.AreEqual(y, yOther);
        }

        [Test]
        [TestCase(null, null, null)]
        [TestCase(2f, null, null)]
        [TestCase(null, 3f, null)]
        [TestCase(null, null, -1f)]
        [TestCase(2f, 3f, null)]
        [TestCase(null, 0f, 2f)]
        [TestCase(2f, null, 3f)]
        [TestCase(2f, 3f, 4f)]
        public void Vector3_With_ValuesChange(float? x, float? y, float? z)
        {
            var initialVector = Vector3.one;
            
            var (newX, newY, newZ) = initialVector.With(x, y, z);
            
            Assert.AreEqual(x ?? initialVector.x, newX);
            Assert.AreEqual(y ?? initialVector.y, newY);
            Assert.AreEqual(z ?? initialVector.z, newZ);
        }
        
        [Test]
        [TestCase(null, null)]
        [TestCase(2f, null)]
        [TestCase(null, 3f)]
        [TestCase(2f, 3f)]
        public void Vector2_With_ValuesChange(float? x, float? y)
        {
            var initialVector = Vector2.one;
            
            var (newX, newY) = initialVector.With(x, y);
            
            Assert.AreEqual(x ?? initialVector.x, newX);
            Assert.AreEqual(y ?? initialVector.y, newY);
        }
    }
}