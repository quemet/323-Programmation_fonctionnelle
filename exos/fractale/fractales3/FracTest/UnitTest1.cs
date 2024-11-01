using System.Diagnostics;
using System.Drawing;
using fractales3;

namespace FracTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_angle_and_length()
        {
            // Arrange
            Point[] points = new Point[9] {
                new Point(0, 0),
                new Point(10, 100),
                new Point(100, 10),
                new Point(100,-10),
                new Point(10, -100),
                new Point(-10, -100),
                new Point(-100, -10),
                new Point(-100, 10),
                new Point(-10, 100)
            };
            Fractales fractales = new Fractales();

            // Act & Assert
            Assert.AreEqual(6,fractales.Angle(points[0], points[1]));
            Assert.AreEqual(84,fractales.Angle(points[0], points[2]));
            Assert.AreEqual(96,fractales.Angle(points[0], points[3]));
            Assert.AreEqual(174,fractales.Angle(points[0], points[4]));
            Assert.AreEqual(-174,fractales.Angle(points[0], points[5]));
            Assert.AreEqual(-96,fractales.Angle(points[0], points[6]));
            Assert.AreEqual(-84,fractales.Angle(points[0], points[7]));
            Assert.AreEqual(-6,fractales.Angle(points[0], points[8]));

            Assert.AreEqual(100.5, Math.Round(fractales.Length(points[0], points[1]),2));
            Assert.AreEqual(100.5, Math.Round(fractales.Length(points[0], points[2]),2));
            Assert.AreEqual(100.5, Math.Round(fractales.Length(points[0], points[3]),2));
            Assert.AreEqual(100.5, Math.Round(fractales.Length(points[0], points[4]),2));
            Assert.AreEqual(100.5, Math.Round(fractales.Length(points[0], points[5]),2));
            Assert.AreEqual(100.5, Math.Round(fractales.Length(points[0], points[6]),2));
            Assert.AreEqual(100.5, Math.Round(fractales.Length(points[0], points[7]),2));
            Assert.AreEqual(100.5, Math.Round(fractales.Length(points[0], points[8]),2));
        }
    }
}