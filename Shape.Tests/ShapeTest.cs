using MyLib;

namespace Shape.Tests
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void TestMethodForBigCyrcle()
        {
            // Arrange
            float a = 10;
            float b = 7;
            float c = 8;
            float answer_test = 5.034f; // 10 7 8

            // Act
            Triangle shape = new Triangle("tri", a, b, c);
            float answer = shape.Radius_Big;

            // Assert
            Assert.AreEqual(answer_test, answer, 0.001, "Test detected Not Equal value");
            
        }
    }
}