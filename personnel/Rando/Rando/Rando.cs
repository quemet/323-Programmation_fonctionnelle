using Aspose.Gis;

namespace Rando
{
    public class Points
    {
        public double _x { get; set; }
        public double _y { get; set; }
        public double _z { get; set; }
        public Points(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
    }

    public partial class Rando : Form
    {
        List<Points> poi = new List<Points>();

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
                                    poi.Add(new Points(segment[j].X, segment[j].Y, segment[j].Z));
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            Point[] p = new Point[poi.Count];

            for(int i = 0; i < p.Length; i++)
            {
                p[i] = new Point((int)poi[i]._x, (int)poi[i]._y);
            }

            Point[] points = new Point[4] { new Point(30,50), new Point(50,10), new Point(80,50), new Point(111,400) };

            this.CreateGraphics().DrawLines(myPen, points);
        }
    }
}
