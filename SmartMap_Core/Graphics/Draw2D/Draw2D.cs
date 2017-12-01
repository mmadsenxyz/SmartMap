/*
 * Code by Mark V Madsen
 * License BSD
*/
using System;
using System.ComponentModel;
using System.Collections;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Windows.Forms;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.RandomWalks;
using QuickGraph.Algorithms.Search;
using QuickGraph.Collections;

namespace SmartMap
{
    /// <summary>
    /// The UI and 2D drawing portion of SmartMap_Core
    /// </summary>
    /// <remarks>SmartMap_Core base class</remarks>
	public class Draw2D : UserControl
	{
		#region Feilds
       
        public int tileAmountNorth = 15, tileAmountEast = 15;
		public SmartMap_Core sm;
		//int keyUp = 0;
		// Draw ball
		protected Point[] apt = new Point[4];
		public int xPaint1 = 100, yPaint1 = 100, xPaint2 = 100, yPaint2 = 100, xPaint3 = 100, yPaint3 = 100, xPaint4 = 100, yPaint4 = 100;
		public float fTension = 0.8f;
		// Move ball
		public int xMoveSize, yMoveSize;// rClockwise, rCounterClockwise;
		public int xGo = 1, yGo = 1;
		protected Brush strBrush, brush;
		// Rotate ball
		private float rotateX1, rotateY1, rotateX2, rotateY2, rotateX3, rotateY3, rotateX4, rotateY4;
		private double radien1 = 1;
		private double radien2 = 3;
		private double radien3 = 2;
		private double radien4 = 4;
		private double rotation = .025;
		// Draw Map
		private float pointWidth  = 5;
		private Color pointColor  = Color.Black;
		private float wallWidth = 2;
		private Color wallColor = Color.Black;
		private RectangleF rect;
		// Form stuff
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Timers.Timer timer1;
		private System.Timers.Timer timer2;
		private System.Timers.Timer timer3;
        private System.ComponentModel.IContainer components = null;

		#endregion

		public Draw2D()
		{
			InitializeComponent();
                
			strBrush = new SolidBrush(Color.White);
			brush = new SolidBrush(Color.Green);
          
			// Remove flicker -
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);

			OnResize(EventArgs.Empty);
			
			this.rect = new RectangleF((pointWidth/2) + 3, (pointWidth/2) + 3, this.Width-(pointWidth + 10)
			    ,this.Height-(pointWidth + 10));			
		}

		public void CreateTileSet(Graphics g)
		{
            //Debug.Assert(this.sm.Width != null & this.sm.Length ! = null);

			float dx = rect.Width/(this.sm.Width-1);
			float dy = rect.Height/(this.sm.Length-1);

			SolidBrush pointBrush = new SolidBrush(PointColor);
			Pen linePen = new Pen(wallColor, wallWidth);
			linePen.EndCap = LineCap.ArrowAnchor;

			// draw points
			float x,y;
			for(int i=0;i < this.sm.Width; ++i)
			{
				for (int j=0;j < this.sm.Length; ++j)
				{
					x = rect.X + i*dx-pointWidth/2;
					y = rect.Y + j*dy-pointWidth/2;
					// draw vertex
					if (i == 0 && j == 0) { pointBrush.Color = Color.Red;} else {pointBrush.Color = Color.Red;}
					g.FillEllipse(pointBrush, x, y, pointWidth, pointWidth);
				}
			}

			// draw edges
			foreach(Edge<Point<int>> e in this.sm.md.Values)
			{
				if (e==null)
					continue;
	
				float sx = rect.X + ((int)e.Source.Width)*dx;
				float sy = rect.Y + ((int)e.Source.Length)*dy;
               
				float tx = rect.X + ((int)e.Target.Width)*dx;
				float ty = rect.Y + ((int)e.Target.Length)*dy;
				g.DrawLine(linePen,sx,sy,tx,ty);
			}
		}
		
		#region Properties

		// Graphics
		public float PointWidth 
		{
			get{return this.pointWidth;}
			set{this.pointWidth = Math.Max(0,value);}
		}

		public Color PointColor 
		{
			get{return this.pointColor;}
			set{this.pointColor = value;}
		}

		public float WallWidth 
		{
			get{return this.wallWidth;}
			set{this.wallWidth = Math.Max(0,value);}
		}

		public Color WallColor 
		{
			get{return this.wallColor;}
			set{this.wallColor = value;}
		}

		#endregion
   
		#region Interact with ball
     
		/// <summary>
		/// Select the array points
		/// </summary>
		protected override void OnMouseDown(MouseEventArgs mea)
		{
			if (mea.Button == MouseButtons.Left)
			{
				if (ModifierKeys == Keys.Shift)
				{
				}
				else if (ModifierKeys == Keys.None)
				{
				}       
				else
					return;
			}
			else if (mea.Button == MouseButtons.Right)
			{
				if (ModifierKeys == Keys.None)
				{
				}
				else if (ModifierKeys == Keys.Shift)
				{
				}
				else
					return;
			}
			else
				return;
		}
     
		protected override void OnMouseUp(MouseEventArgs e)
		{
		}

		/// <summary>
		/// Move the array points
		/// </summary>
		protected override void OnMouseMove(MouseEventArgs mea)
		{
			Point pt = new Point(mea.X, mea.Y);
        
			if ((mea.X < 0) | (mea.X > ClientSize.Width))
			{ 
			}
			else
			{    
				if (mea.Button == MouseButtons.Left)
				{
					if (ModifierKeys == Keys.Shift)
					{
						xPaint1 = mea.X;
						yPaint1 = mea.Y;
					}   
					else if (ModifierKeys == Keys.None)
					{
						xPaint2 = mea.X;
						yPaint2 = mea.Y;
					}        
					else 
					{
						return;
					}
					//Cursor.Position = PointToScreen(pt);
				}
				else if (mea.Button == MouseButtons.Right)
				{
					if (ModifierKeys == Keys.None)
					{
						xPaint3 = mea.X;
						yPaint3 = mea.Y;
					}            
					else if (ModifierKeys == Keys.Shift)
					{
						xPaint4 = mea.X;
						yPaint4 = mea.Y;
					}        
					else 
					{
						return;
					}
				}
				else 
				{
					return;
				}
			}  
		}

		#endregion

		#region Timers

		private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{	 
		}
    
		/// <summary>
		/// Moves graphics object 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer2_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			// rClockwise++;
			// rCounterClockwise++;
			// Reset radien so it doesn't get too high
			if (radien1 == 100 | radien2 == 100 | radien3 ==100 | radien4 == 100)
			{
				radien1 = 1;
				radien2 = 3;
				radien3 = 2;
				radien4 = 4;
			}

			//Move ball
			xMoveSize += xGo;
			yMoveSize += yGo;

			// Rotate ball. The first numbers tell how far from center
			rotateX1 = (100 -1) * (1 + (float)Math.Cos(radien3));
			rotateY1 = (100 -1) * (1 + (float)Math.Sin(radien3));
			rotateX2 = (100 -1) * (1 + (float)Math.Cos(radien2));
			rotateY2 = (100 -1) * (1 + (float)Math.Sin(radien2));
			rotateX3 = (100 -1) * (1 + (float)Math.Cos(radien4));
			rotateY3 = (100 -1) * (1 + (float)Math.Sin(radien4));
			rotateX4 = (100 -1) * (1 + (float)Math.Cos(radien1));
			rotateY4 = (100 -1) * (1 + (float)Math.Sin(radien1));
     
			radien1 += rotation;
			radien2 += rotation;
			radien3 += rotation;
			radien4 += rotation;

			Invalidate();
		}
    
		/// <summary>
		/// Morph Ball
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer3_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{    
		}

		#endregion

		#region Auto Code

		private void InitializeComponent()
		{
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Timers.Timer();
            this.timer2 = new System.Timers.Timer();
            this.timer3 = new System.Timers.Timer();
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.timer1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.timer2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.timer3 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point( 0, 0 );
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size( 233, 218 );
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler( this.timer1_Elapsed );
            // 
            // timer2
            // 
            this.timer2.Interval = 15;
            this.timer2.SynchronizingObject = this;
            this.timer2.Elapsed += new System.Timers.ElapsedEventHandler( this.timer2_Elapsed );
            // 
            // timer3
            // 
            this.timer3.Interval = 15;
            this.timer3.SynchronizingObject = this;
            this.timer3.Elapsed += new System.Timers.ElapsedEventHandler( this.timer3_Elapsed );
            // 
            // Draw2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.pictureBox1 );
            this.Name = "Draw2D";
            this.Size = new System.Drawing.Size( 328, 330 );
            ( (System.ComponentModel.ISupportInitialize)( this.pictureBox1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.timer1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.timer2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.timer3 ) ).EndInit();
            this.ResumeLayout( false );

		}

		#endregion

		#region Events

        public virtual void pictureBox_Paint(object sender, PaintEventArgs pea)
        {
            int a = 0;
            Graphics grfx = pea.Graphics;
            GraphicsPath path = new GraphicsPath(FillMode.Winding);

            CreateTileSet(grfx);

            if (a == 1)
            {
                // Rotate and move ball vertexes
                apt[0].X = xPaint1 + (int)rotateX1 + xMoveSize;
                apt[0].Y = yPaint1 + (int)rotateY1 + yMoveSize;
                apt[1].X = xPaint2 + (int)rotateX2 + xMoveSize;
                apt[1].Y = yPaint2 + (int)rotateY2 + yMoveSize;
                apt[2].X = xPaint3 + (int)rotateX3 + xMoveSize;
                apt[2].Y = yPaint3 + (int)rotateY3 + yMoveSize;
                apt[3].X = xPaint4 + (int)rotateX4 + xMoveSize;
                apt[3].Y = yPaint4 + (int)rotateY4 + yMoveSize;

                // Draw path
                path.AddClosedCurve(apt, fTension);

                grfx.DrawPath(new Pen(Color.Green), path);

                // Fill path.
                PathGradientBrush pgbrush = new PathGradientBrush(path);

                pgbrush.CenterColor = Color.White;
                pgbrush.SurroundColors = new Color[1] { Color.Green };

                grfx.FillPath(pgbrush, path);

                // Anti-Allais
                grfx.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // Draw Array Ellipses (vertex indicators)
                for (int i = 0; i < 4; i++)
                {
                    grfx.FillEllipse(strBrush, apt[i].X - 3, apt[i].Y - 3, 7, 7);
                }
                // Collision for ball. Reverse angle ball if collide.
                // Set extra collision for rotation so it doesn't get stuck 
                grfx.SetClip(path);

                if (grfx.VisibleClipBounds.Width < grfx.ClipBounds.Width)
                {
                    xGo = -xGo;
                    rotation = -rotation;
                    // Stop rotation from getting stuck on walls
                    if (grfx.ClipBounds.X > 0)
                    {
                        xPaint1 += -3;
                        xPaint2 += -3;
                        xPaint3 += -3;
                        xPaint4 += -3;
                    }
                    if (grfx.ClipBounds.X < 1)
                    {
                        xPaint1 += 3;
                        xPaint2 += 3;
                        xPaint3 += 3;
                        xPaint4 += 3;
                    }
                    //  Add sound.
                    // applicationBuffer.Play(0, BufferPlayFlags.Default);
                }

                if (grfx.VisibleClipBounds.Height < grfx.ClipBounds.Height)
                {
                    yGo = -yGo;
                    rotation = -rotation;
                    // Stop rotation from getting stuck on walls
                    if (grfx.ClipBounds.Y > 0)
                    {
                        yPaint1 += -3;
                        yPaint2 += -3;
                        yPaint3 += -3;
                        yPaint4 += -3;
                    }
                    if (grfx.ClipBounds.Y < 1)
                    {
                        yPaint1 += 3;
                        yPaint2 += 3;
                        yPaint3 += 3;
                        yPaint4 += 3;
                    }
                }
            }
        }
        #endregion
   
        
	}
}
