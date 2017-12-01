/*
 * Code by Mark V Madsen
 * License LPGL
*/
using Axiom.Core;
using Axiom.Math;
using System.Collections.Generic;

namespace SmartMap
{
    /// <summary>
    /// Creates dynamic (moving) objects in scene
    /// </summary>
    /// <remarks>Interfaced with CreateGraphics method</remarks>
	public class Draw4D
	{
		// IDraw interface
		public IDraw idraw;
		private SceneManager scene;
		// Zones
		public Dictionary<int, Entity> zone;
		public Dictionary<int, SceneNode> zoneNode;
		public Dictionary<int, SceneNode> zoneGroup;
		private int zoneCount;
		// Models
		public Dictionary<int, Entity> model;
		public Dictionary<int, SceneNode> modelNode;

		public Draw4D(SceneManager man)
		{
			this.scene = man;

			this.zone = new Dictionary<int, Entity>(36);
			this.zoneNode = new Dictionary<int, SceneNode>(36);
			this.zoneGroup = new Dictionary<int, SceneNode> (4);
			this.model = new Dictionary<int, Entity>(10);
			this.modelNode = new Dictionary<int, SceneNode>(10);
		}
		public void CreateModel()
		{
            idraw.CreateGraphics(model, "Model", "ogrehead.mesh", "Ogre/Skin", 1, 1, true);
			// for main player
			modelNode[0] = scene.RootSceneNode.CreateChildSceneNode("Model");
			modelNode[0].AttachObject(model[0]);
		}
		// REPLACE THIS WITH OCTREE TERRAIN NODES - Octree nodes parent item nodes
		public void CreateZone(int zoneNumber, bool recreate, float mapSize, float meshSize)
		{
			// create zone children
			float x = -meshSize/2;
			float z = -meshSize/2;
			// create zones
			if (!recreate) {
				idraw.CreateGraphics(zone, "Zone", "Zone.mesh", "TileSet/Room", 36, 36, true);
				// create 36 zoneNodes
				for (int i = 0; i < zoneNode.Count; ++i) {
					if (x >= (mapSize * 2) - (mapSize/3)) {
						x = -meshSize/2;
						z += mapSize/3;
					}
					zoneNode[i] = scene.RootSceneNode.CreateChildSceneNode("Zone" + i, new Vector3(x, 0, z));
					zoneNode[i].AttachObject(zone[i]);
					zoneNode[i].Scale = new Vector3(1,10,1);
					//zoneNode[i].ShowBoundingBox = true;
					zone[i].IsVisible = false;

					x += mapSize/3;
				}
			}

			// create zoneNode Parent
			x = 0;
			z = 0;
			// switch ZoneGroup numbers to array numbers
			switch (zoneNumber) {
				case 1:
					zoneNumber = 0;
					zoneCount = 0;
					break;
				case 2:
					zoneNumber = 1;
					zoneCount = 3;
					break;
				case 3:
					zoneNumber = 2;
					zoneCount = 18;
					break;
				case 4:
					zoneNumber = 3;
					zoneCount = 21;
					break;
			}

			zoneGroup[zoneNumber] = scene.RootSceneNode.CreateChildSceneNode("ZoneGroup" + zoneNumber, new Vector3(x, 0, z));
			
			for (int i = 0; i < 9; ++i)
			{
				switch (zoneNumber) {
					case 0:
						if ((zoneCount == 3) || (zoneCount == 9) || (zoneCount ==15))
							zoneCount += 3;
						break;
					case 1:
						if ((zoneCount == 6) || (zoneCount == 12))
							zoneCount += 3;
						break;
					case 2:
						if ((zoneCount == 21) || (zoneCount == 27) || (zoneCount ==33))
							zoneCount += 3;
						break;
					case 3:
						if ((zoneCount == 24) || (zoneCount == 30))
							zoneCount += 3;
						break;
				}
				zoneGroup[zoneNumber].AddChild(zoneNode[zoneCount]);
				zoneCount++;
			}
		}
	}
}