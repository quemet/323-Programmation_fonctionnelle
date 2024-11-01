using System.Diagnostics;
using System.Drawing;
using System.Numerics;

namespace fractales3
{
    public partial class Fractales : Form
    {
        private readonly int PANEL_WIDTH;
        private readonly int PANEL_HEIGHT;

        Graphics graphics;

        Action<Pen, Point[]> Draw;

        // The first point of a pattern must always be (0,0)
        Point[] pattern = new Point[5] {
            new Point(0, 0),
            new Point(20, 0),
            new Point(30, 25),
            new Point(40, 0),
            new Point(60,0)
        };

        // Test points
        Point[] points = new Point[7] {
                new Point(0, 150),
                new Point(100, 100),
                new Point(100, -100),
                new Point(0, -150),
                new Point(-100, -100),
                new Point(-100,100),
                new Point(0, 150)
            };

        Pen pen = new Pen(Color.Red, 1);


        public Fractales()
        {
            InitializeComponent();
            graphics = drawingPanel.CreateGraphics();
            Draw = graphics.DrawLines;

            // Initialize pannel dimensions
            PANEL_WIDTH = drawingPanel.ClientSize.Width;
            PANEL_HEIGHT = drawingPanel.ClientSize.Height;
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Draw(pen, VerticalFlip(MoveTo(Fractalize(points, (int)nudDepth.Value), new Point(PANEL_WIDTH / 2, PANEL_HEIGHT / 2))));
        }

        private Point[] VerticalFlip(Point[] points)
        {
            return points.Select(p => new Point(p.X, PANEL_HEIGHT - p.Y)).ToArray();
        }

        private Point[] MoveTo(Point[] points, Point basePoint)
        {
            return points.Select(p => new Point(basePoint.X + p.X, basePoint.Y + p.Y)).ToArray();
        }

        private Point[] Resize(Point[] points, double factor)
        {
            return points.Select(p => new Point((int)Math.Round(p.X * factor), (int)Math.Round(p.Y * factor))).ToArray();
        }

        private Point[] Rotate(Point[] points, int angle)
        {
            double angleRadians = angle * (Math.PI / 180.0);
            return points.Select(p =>
            {
                double xNew = p.X * Math.Cos(angleRadians) - p.Y * Math.Sin(angleRadians);
                double yNew = p.X * Math.Sin(angleRadians) + p.Y * Math.Cos(angleRadians);

                return new Point((int)Math.Round(xNew), (int)Math.Round(yNew));
            }).ToArray();
        }

        // Returns the angle in degrees of vector p1-p2 with a vertical line
        public int Angle(Point p1, Point p2)
        {
            return (int)Math.Round(Math.Atan2(p2.X - p1.X, p2.Y - p1.Y) * 180.0 / Math.PI);
        }

        public double Length(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        private Point[] FitPattern(Point[] pattern, Point start, Point end)
        {
            // Compute the size ratio
            double patternLength = Length(pattern[0], pattern[pattern.Length - 1]);
            double segmentLength = Length(end, start);
            double ratio = segmentLength / patternLength;

            // Compute the angle
            int patternAngle = Angle(pattern[0], pattern[pattern.Length - 1]);
            int segmentAngle = Angle(start, end);
            int angle = patternAngle - segmentAngle;

            // Do the job
            return MoveTo(Resize(Rotate(pattern, angle), ratio), start);
        }

        private Point[] Fractalize(Point[] ptrn, int depth)
        {
            if (depth == 0) return ptrn;
            return ptrn.Zip(ptrn.Skip(1), (p1, p2) => Fractalize(FitPattern(pattern, p1, p2), depth - 1)).SelectMany(p => p).ToArray();
        }

        private void nudDepth_ValueChanged(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
        }

        private void rbtLine_CheckedChanged(object sender, EventArgs e)
        {
            Draw = graphics.DrawLines;
            drawingPanel.Invalidate();
        }

        private void rbtCurve_CheckedChanged(object sender, EventArgs e)
        {
            Draw = graphics.DrawCurve;
            drawingPanel.Invalidate();
        }
    }
}
