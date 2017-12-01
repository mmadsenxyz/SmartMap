/*
 * Code by Mark V Madsen
 * License BSD
*/
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Threading;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.RandomWalks;
using QuickGraph.Algorithms.Search;
using QuickGraph.Collections;
using Wintellect;
using System.Collections.Generic;
using Axiom.Configuration;
using Axiom.Animating;
using Axiom.Core;
using Axiom.Collections;
using Axiom.Math;
using Axiom.Graphics;
using Axiom.Input;
using Axiom.Overlays;
using MouseButtons = Axiom.Input.MouseButtons;

namespace SmartMap
{
    /// <summary>
    /// Fast drawing across all classes
    /// </summary>
	public interface IDraw
	{
		void CreateGraphics(Dictionary<int, Entity> entity, string tileName, string tileFileName, string materialName, int meshAmount,
		    int textureAmount, bool newEntity);
	}
}
