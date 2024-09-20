using Aspose.Gis;
using System.Reflection.Metadata.Ecma335;

namespace Rando
{
    public class Points
    {
        public double _x { get; set; }
        public double _y { get; set; }
        public double _z { get; set; }
        public double _distance { get; set; }
        public List<Points> _points { get; set; }

        public Points(double x = 1, double y = 1, double z = 1)
        {
            _x = x;
            _y = y;
            _z = z;
            _points = new List<Points>();
        }

        public void CalculateDistance()
        {
            /*
            double lon1 = toRadians(lon1);
            double lon2 = toRadians(lon2);

            double lat1 = toRadians(lat1);
            double lat2 = toRadians(lat2);
 
            double dlon = lon2 - lon1; 
            double dlat = lat2 - lat1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2),2);
            
            double c = 2 * Math.Asin(Math.Sqrt(a));
 
            double r = 6371;

            return (c * r);
             */



            /*double y = _points.Aggregate(new Points(), (p, next) =>
            {
                return new Points() { 
                    _x = next._x, 
                    _y = next._y, 
                    _z = next._z, 
                    _distance = Math.Sqrt(Math.Pow((next._x - p._x), 2) + Math.Pow((next._y - p._y), 2) + Math.Pow((next._z - p._z), 2)) + p._distance
                };
            }, p => p._distance);
            MessageBox.Show((y*3.78103356).ToString());*/
        }
    }

    public partial class Rando : Form
    {
        public static Points p = new Points();
        public Rando()
        {
            InitializeComponent();

            ReadXML();
        }

        public void ReadXML()
        {
            using (var layer = Drivers.Gpx.OpenLayer("Running.gpx"))
            {
                foreach (var feature in layer)
                {
                    if (feature.Geometry.GeometryType == Aspose.Gis.Geometries.GeometryType.MultiLineString)
                    {
                        var lines = (Aspose.Gis.Geometries.MultiLineString)feature.Geometry;
                        for (int i = 0; i < lines.Count; i++)
                        {
                            var segment = (Aspose.Gis.Geometries.LineString)lines[i];

                            for (int j = 0; j < segment.Count; j++)
                            {
                                string attributeName = $"name__{i}__{j}";
                                if (!(layer.Attributes.Contains(attributeName) && feature.IsValueSet(attributeName)))
                                {
                                    p._points.Add(new Points(segment[j].X, segment[j].Y, segment[j].Z));
                                }
                            }
                        }
                    }
                }
            }
            p.CalculateDistance();
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
