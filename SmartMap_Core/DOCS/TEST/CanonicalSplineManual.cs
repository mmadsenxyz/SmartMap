//----------------------------------------------------
// CanonicalSplineManual.cs © 2001 by Charles Petzold
//----------------------------------------------------
using System;
using System.Drawing;
using System.Windows.Forms;

class CanonicalSplineManual: CanonicalSpline
{
     public new static void Main()
     {
          Application.Run(new CanonicalSplineManual());
     }
     public CanonicalSplineManual()
     {
          Text = "Canonical Spline \"Manually\" Drawn";
     }
     protected override void OnPaint(PaintEventArgs pea)
     {
          base.OnPaint(pea);

          CanonicalSpline(pea.Graphics, Pens.Red, apt, fTension);
     }
     void CanonicalSpline(Graphics grfx, Pen pen, Point[] apt, float T)
     {
          CanonicalSegment(grfx, pen, apt[0], apt[0], apt[1], apt[2], T);
          CanonicalSegment(grfx, pen, apt[0], apt[1], apt[2], apt[3], T);
          CanonicalSegment(grfx, pen, apt[1], apt[2], apt[3], apt[3], T);
     }
     void CanonicalSegment(Graphics grfx, Pen pen, Point pt0, Point pt1, 
                           Point pt2, Point pt3, float T)
     {
          Point[] apt = new Point[10];

          float SX1 = T * (pt2.X - pt0.X);
          float SY1 = T * (pt2.Y - pt0.Y);
          float SX2 = T * (pt3.X - pt1.X);
          float SY2 = T * (pt3.Y - pt1.Y);
          float AX = SX1 + SX2 + 2 * pt1.X - 2 * pt2.X;
          float AY = SY1 + SY2 + 2 * pt1.Y - 2 * pt2.Y;
          float BX = -2 * SX1 - SX2 - 3 * pt1.X + 3 * pt2.X;
          float BY = -2 * SY1 - SY2 - 3 * pt1.Y + 3 * pt2.Y;
          float CX = SX1;
          float CY = SY1;
          float DX = pt1.X;
          float DY = pt1.Y;

          for (int i = 0; i < apt.Length; i++)
          {
               float t = (float)i / (apt.Length - 1);
               apt[i].X = (int) (AX * t * t * t + BX * t * t + CX * t + DX);
               apt[i].Y = (int) (AY * t * t * t + BY * t * t + CY * t + DY);
          }
          grfx.DrawLines(pen, apt);
     }
}
