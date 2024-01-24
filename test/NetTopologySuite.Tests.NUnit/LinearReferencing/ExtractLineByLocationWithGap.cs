using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.LinearReferencing;
using NetTopologySuite.Tests.NUnit.TestData;
using NUnit.Framework;

namespace NetTopologySuite.Tests.NUnit.LinearReferencing
{
    internal class ExtractLineByLocationWithGapTest : GeometryTestCase
    {
        [Test(
            Author = "Jeff Jacobson",
            Description = "Tests LRS line extraction from a location along a WA state route MultiLineString between two points on different sides of a gap"
         )]
        public void TestExtractFromMultilineStingWithGap()
        {
            double start = 118.96;
            double end = 118.97;
            Geometry geom;
            using (var stream = EmbeddedResourceManager.GetResourceStream("NetTopologySuite.Tests.NUnit.TestData.US_WA.SR002i.zm.wkb"))
            {
                var wkbReader = new WKBReader();
                geom = wkbReader.Read(stream);
            }
            TestContext.WriteLine($"Input geometry has {geom.NumGeometries} parts.");
            TestContext.WriteLine($"WKT of input geometry is {geom.ToText()}");
            Assert.IsNotNull(geom);
            Assert.IsInstanceOf<MultiLineString>(geom);
            if (geom is MultiLineString mls)
            {
                var lel = new LengthIndexedLine(mls);
                var segment = lel.ExtractLine(start, end);
                TestContext.WriteLine($"Extracted line has {segment.NumGeometries} geometries.");
                Assert.Less(segment.Length, mls.Length);
                if (segment is MultiLineString l)
                {
                    Assert.Greater(l.NumGeometries, 1);
                }
            }
        }
    }
}
