/////////////////////////////////////////
			// Create Titlesets by camClipping //
			/////////////////////////////////////////

			// many if statements for the Zones now until I set up the EVENT system for SceneNodes
			// check for nodes because Entities stay in one place while nodes move
			/*if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[0].WorldAABB)) & (camClipped != 1))
			{ 
				// turn off camClip until another is triggered because of timer
				camClipped = 1;
				window.DebugText = string.Format("Zone: 1");

			} else
			if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[1].WorldAABB)) & (camClipped != 2))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 2;
				window.DebugText = string.Format("Zone: 2");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[2].WorldAABB)) & (camClipped != 3))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 3;
				window.DebugText = string.Format("Zone: 3");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[3].WorldAABB)) & (camClipped != 4))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 4;
				window.DebugText = string.Format("Zone: 4");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[4].WorldAABB)) & (camClipped != 5))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 5;
				window.DebugText = string.Format("Zone: 5");	
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[5].WorldAABB)) & (camClipped != 6))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 6;
				window.DebugText = string.Format("Zone: 6");
				/*if ((d4d.zoneNode[12].Position.x < d4d.zoneNode[5].Position.x) || (d4d.zoneNode[5].Position.z != d4d.zoneNode[12].Position.z)) {
					MoveSceneNode(d4d.zoneNode, 0, 8, d4d.zoneNode[0].Position.x + mapSize, 0, d4d.zoneNode[0].Position.z);
					this.sm  = new SmartMap(30, 0 , 30);
					this.sm.GeneratePath(10, 10);
					this.sm.SearchPath();
					RemoveTileset(1);
					CreateTileset(1, true, d4d.zoneNode[0].Position.x + mapSize, 0, d4d.zoneNode[0].Position.z);
				}
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[6].WorldAABB)) & (camClipped != 7))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 7;
				window.DebugText = string.Format("Zone: 7");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[7].WorldAABB)) & (camClipped != 8)) {
				// turn off camClip until another is triggered because of timer
				camClipped = 8;
				window.DebugText = string.Format("Zone: 8");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[8].WorldAABB)) & (camClipped != 9))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 9;
				window.DebugText = string.Format("Zone: 9");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[9].WorldAABB)) & (camClipped != 10))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 10;
				window.DebugText = string.Format("Zone: 10");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[10].WorldAABB)) & (camClipped != 11))
			{
			// turn off camClip until another is triggered because of timer
			camClipped = 11;
			window.DebugText = string.Format("Zone: 11");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[11].WorldAABB)) & (camClipped != 12))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 12;
				window.DebugText = string.Format("Zone: 12");
			}
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[12].WorldAABB)) & (camClipped != 13))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 13;
				window.DebugText = string.Format("Zone: 13");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[13].WorldAABB)) & (camClipped != 14))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 14;
				window.DebugText = string.Format("Zone: 14");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[14].WorldAABB)) & (camClipped != 15))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 15;
				window.DebugText = string.Format("Zone: 15");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[15].WorldAABB)) & (camClipped != 16))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 16;
				window.DebugText = string.Format("Zone: 16");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[16].WorldAABB)) & (camClipped != 17)) 
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 17;
				window.DebugText = string.Format("Zone: 17");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[17].WorldAABB)) & (camClipped != 18))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 18;
				window.DebugText = string.Format("Zone: 18");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[18].WorldAABB)) & (camClipped != 19))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 6;
				window.DebugText = string.Format("Zone: 19");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[19].WorldAABB)) & (camClipped != 20))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 20;
				window.DebugText = string.Format("Zone: 20");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[20].WorldAABB)) & (camClipped != 21))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 21;
				window.DebugText = string.Format("Zone: 21");	
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[21].WorldAABB)) & camClipped != 22) {
				// turn off camClip until another is triggered because of timer
				camClipped = 22;
				window.DebugText = string.Format("Zone: 22");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[22].WorldAABB)) & (camClipped != 23))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 7;
				window.DebugText = string.Format("Zone: 23");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[23].WorldAABB)) & (camClipped != 24))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 24;
				window.DebugText = string.Format("Zone: 24");
			} else
			if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[24].WorldAABB)) & (camClipped != 25))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 25;
				window.DebugText = string.Format("Zone: 25");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[25].WorldAABB)) & (camClipped != 26))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 26;
				window.DebugText = string.Format("Zone: 26");
			} else
			if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[26].WorldAABB)) & (camClipped != 27))
			{
			// turn off camClip until another is triggered because of timer
			camClipped = 27;
			window.DebugText = string.Format("Zone: 27");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[27].WorldAABB)) & (camClipped != 28))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 28;
				window.DebugText = string.Format("Zone: 28");
			}
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[28].WorldAABB)) & (camClipped != 29))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 29;
				window.DebugText = string.Format("Zone: 29");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[29].WorldAABB)) & (camClipped != 30))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 30;
				window.DebugText = string.Format("Zone: 30");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[30].WorldAABB)) & (camClipped != 31))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 31;
				window.DebugText = string.Format("Zone: 31");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[31].WorldAABB)) & (camClipped != 32))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 32;
				window.DebugText = string.Format("Zone: 32");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[32].WorldAABB)) & (camClipped != 33))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 33;
				window.DebugText = string.Format("Zone: 33");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[33].WorldAABB)) & (camClipped != 34))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 34;
				window.DebugText = string.Format("Zone: 34");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[34].WorldAABB)) & (camClipped != 35))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 35;
				window.DebugText = string.Format("Zone: 35");
			} else
			if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[35].WorldAABB)) & (camClipped != 36))
			{
				// turn off camClip until another is triggered because of timer
				camClipped = 36;
				window.DebugText = string.Format("Zone: 36");
			}*/