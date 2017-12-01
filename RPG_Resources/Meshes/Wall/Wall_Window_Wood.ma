//Maya ASCII 6.5 scene
//Name: Wall_Window_Wood.ma
//Last modified: Mon, Feb 18, 2008 07:22:56 PM
requires maya "6.5";
requires "VectorRender" "6.0 - 3.126 - cut 200501140727";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya Unlimited 6.5";
fileInfo "version" "6.5";
fileInfo "cutIdentifier" "200501140008-637295";
fileInfo "osv" "Microsoft Windows XP Service Pack 2 (Build 2600)\n";
createNode transform -n "Wall_Middle_Wood_04:pCube6";
	setAttr ".t" -type "double3" -10 0 0 ;
createNode mesh -n "Wall_Middle_Wood_04:pCubeShape6" -p "Wall_Middle_Wood_04:pCube6";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
createNode mesh -n "polySurfaceShape6" -p "Wall_Middle_Wood_04:pCube6";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 64 ".uvst[0].uvsp[0:63]" -type "float2" 0.67245573 0.75248563 
		0.23567228 0.92622328 0.23567228 0.90767419 0.23567228 0.90767419 0.9761411 0.32437667 
		0.4667851 0.753923 0.4667851 0.91206563 0.39193606 0.90767419 0.98616898 0.11260349 
		0.31135583 0.92622328 0.31135583 0.90767419 0.31135583 0.90767419 0.9761411 0.18740034 
		0.39193606 0.753923 0.39193606 0.91206557 0.4667851 0.90767419 0.62626368 0.83087301 
		0.67245573 0.83087301 0.39193571 0.92622328 0.6262638 0.75248563 0.96237558 0.11260349 
		0.4667851 0.92622328 0.96237558 0.10070676 0.74823499 0.10070676 0.74823499 0.11260344 
		0.71254486 0.11260343 0.71254486 0.065016709 0.74823499 0.065016709 0.74823499 0.076913416 
		0.96237558 0.076913357 0.96237558 0.065016806 0.98616898 0.065016806 0.39193606 0.90767419 
		0.4667851 0.90767419 0.31135583 0.90767419 0.23567228 0.90767419 0.39193606 0.7763679 
		0.39193606 0.90767419 0.4667851 0.90767419 0.4667851 0.7763679 0.31135583 0.7763679 
		0.31135583 0.91206557 0.23567228 0.7763679 0.23567228 0.91206563 0.31135583 0.753923 
		0.31135583 0.77223694 0.23567228 0.753923 0.23567228 0.77223694 0.92994905 0.18740034 
		0.39193606 0.77223694 0.4667851 0.77223694 0.92994905 0.32437667 0.98616898 0.065016709 
		0.98616898 0.11260343 0.96237558 0.11260343 0.96237564 0.10070675 0.74823499 0.10070676 
		0.74823499 0.11260343 0.71254486 0.11260343 0.71254486 0.065016687 0.74823499 0.065016687 
		0.74823499 0.076913416 0.96237558 0.076913416 0.96237558 0.065016717;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr -s 24 ".pt[0:23]" -type "float3"  0 0 -3.75 0 0 -3.75 0 0 -3.75 
		0 0 -3.75 0 0 -3.75 0 0 -3.75 0 0 -3.75 0 0 -3.75 0 0 -3.75 0 0 -3.75 0 0 -3.75 0 
		0 -3.75 0 0 -2 0 0 -2 0 0 -2 0 0 -2 0 0 -2 0 0 -2 0 0 -2 0 0 -2 0 0 -2 0 0 -2 0 0 
		-2 0 0 -2;
	setAttr -s 24 ".vt[0:23]"  0.5 0 1.75 1.5 0 1.75 0.5 5.75 1.75 1.5 
		5.75 1.75 0.5 5.25 1.75 1.5 5.25 1.75 0.625 5.25 1.75 1.375 5.25 1.75 0.625 0.75 
		1.75 1.375 0.75 1.75 0.5 0.75 1.75 1.5 0.75 1.75 0.5 5.75 4 1.5 5.75 4 0.5 5.25 4 
		0.625 5.25 4 0.625 0.75 4 0.5 0.75 4 0.5 0 4 1.5 0 4 1.5 0.75 4 1.375 0.75 4 1.375 
		5.25 4 1.5 5.25 4;
	setAttr -s 36 ".ed[0:35]"  0 1 0 0 10 0 
		1 11 0 2 3 0 4 2 0 5 3 0 
		6 4 0 7 5 0 8 6 0 9 7 0 
		10 8 0 11 9 0 2 12 0 3 13 0 
		12 13 0 4 14 0 14 12 0 6 15 0 
		15 14 0 8 16 0 16 15 0 10 17 0 
		17 16 0 0 18 0 18 17 0 1 19 0 
		18 19 0 11 20 0 19 20 0 9 21 0 
		20 21 0 7 22 0 21 22 0 5 23 0 
		22 23 0 23 13 0;
	setAttr -s 166 ".n[0:165]" -type "float3"  0 0 1 0 0 1 0 0 1 0 0 1 0 
		0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 0 0 1 0 -1 0 0 -1 0 
		0 -1 0 0 -1 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 0 1 0 0 1 
		0 0 1 0 0 1 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 1 0 0 1 0 0 
		1 0 0 1 0 0 0 1 0 0 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 0 0 1 0 0 0 -1 0 0 -1 0 0 -1 0 
		0 -1 0 1 0 0 1 0 0 1 0 0 1 0 0 0 1 0 0 1 0 0 1 0 0 1 0 0 0 1 0 0 1 0 0 1 0 0 1 0 
		0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 
		0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 0 0 1 0 -1 0 0 -1 
		0 0 -1 0 0 -1 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 0 1 0 0 
		1 0 0 1 0 0 1 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 1 0 0 1 0 
		0 1 0 0 1 0 0 0 1 0 0 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 0 0 1 0 0 0 -1 0 0 -1 0 0 -1 
		0 0 -1 0 1 0 0 1 0 0 1 0 0 1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 1 0 0 
		1 0 0 1 0 0 1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 
		1 0 0 1 0 0 1 0 0 1 0 0 -1 0 0 -1 0 0 -1 0 0 -1 0 0;
	setAttr -s 14 ".fc[0:13]" -type "polyFaces" 
		f 12 -15 -17 -19 -21 -23 -25 26 28 30 32 
		34 35 
		mu 0 12 8 31 30 29 28 27 26 25 24 
		23 22 20 
		f 4 -4 12 14 -14 
		mu 0 4 0 19 16 17 
		f 4 -5 15 16 -13 
		mu 0 4 1 35 34 9 
		f 4 -7 17 18 -16 
		mu 0 4 2 43 41 10 
		f 4 -9 19 20 -18 
		mu 0 4 3 42 40 11 
		f 4 -11 21 22 -20 
		mu 0 4 42 47 45 40 
		f 4 -2 23 24 -22 
		mu 0 4 47 46 44 45 
		f 4 0 25 -27 -24 
		mu 0 4 4 51 48 12 
		f 4 2 27 -29 -26 
		mu 0 4 5 50 49 13 
		f 4 11 29 -31 -28 
		mu 0 4 50 39 36 49 
		f 4 9 31 -33 -30 
		mu 0 4 39 38 37 36 
		f 4 7 33 -35 -32 
		mu 0 4 6 33 32 14 
		f 4 5 13 -36 -34 
		mu 0 4 7 18 21 15 
		f 12 3 -6 -8 -10 -12 -3 -1 1 10 8 
		6 4 
		mu 0 12 52 53 54 55 56 57 58 59 60 
		61 62 63 ;
createNode polyTweakUV -n "polyTweakUV2";
	setAttr ".uopa" yes;
	setAttr -s 24 ".uvtk";
	setAttr ".uvtk[0:3]" -type "float2" -0.28179321 0.17373766  7.6248174e-012 
		-9.5823349e-013  7.6248174e-012 0  7.6248174e-012 0 ;
	setAttr ".uvtk[6:7]" -type "float2" -2.3886115e-011 0  7.6248174e-012 
		0 ;
	setAttr ".uvtk[9:11]" -type "float2" -2.3886115e-011 -9.5823349e-013  -2.3886115e-011 
		0  -2.3886115e-011 0 ;
	setAttr ".uvtk[14:19]" -type "float2" 7.6248174e-012 0  -2.3886115e-011 
		0  -0.39059138 0.12583554  -0.43678343 0.09535028  7.6248174e-012 -9.5823349e-013  
		-0.23560128 0.2042228 ;
	setAttr ".uvtk[21]" -type "float2" -2.3886115e-011 -9.5823349e-013 ;
	setAttr ".uvtk[32:35]" -type "float2" 7.6248174e-012 0  -2.3886115e-011 
		0  -2.3886115e-011 0  7.6248174e-012 0 ;
	setAttr ".uvtk[37:38]" -type "float2" 7.6248174e-012 0  -2.3886115e-011 
		0 ;
	setAttr ".uvtk[41]" -type "float2" -2.3886115e-011 0 ;
	setAttr ".uvtk[43]" -type "float2" 7.6248174e-012 0 ;
createNode polyMapCut -n "polyMapCut2";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[3]" "e[12:14]";
createNode polyTweakUV -n "polyTweakUV1";
	setAttr ".uopa" yes;
	setAttr -s 72 ".uvtk[0:71]" -type "float2" 0 -0.27510375 7.6248174e-012 
		-0.27510375 7.6248174e-012 -0.27510375 7.6248174e-012 -0.27510375 0 -0.27510375 -0.076122582 
		-0.27510375 -0.076122582 -0.27510375 -0.15626378 -0.27510375 0 -0.27510375 0.079306692 
		-0.27510375 0.079306692 -0.27510375 0.079306692 -0.27510375 0 -0.27510375 -0.15626378 
		-0.27510375 -0.15626378 -0.27510375 -0.076122582 -0.27510375 0 -0.27510375 0 -0.27510375 
		-0.15626343 -0.27510375 0 -0.27510375 0 -0.27510375 -0.076122582 -0.27510375 0 -0.27510375 
		0 -0.27510375 0 -0.27510375 0 -0.27510375 0 -0.27510375 0 -0.27510375 0 -0.27510375 
		0 -0.27510375 0 -0.27510375 0 -0.27510375 -0.15626378 -0.27510375 -0.076122582 -0.27510375 
		0.079306692 -0.27510375 7.6248174e-012 -0.27510375 -0.15626378 -0.27510375 -0.15626378 
		-0.27510375 -0.076122582 -0.27510375 -0.076122582 -0.27510375 0.079306692 -0.27510375 
		0.079306692 -0.27510375 7.6248174e-012 -0.27510375 7.6248174e-012 -0.27510375 0.079306692 
		-0.27510375 0.079306692 -0.27510375 7.6248174e-012 -0.27510375 7.6248174e-012 -0.27510375 
		0 -0.27510375 -0.15626378 -0.27510375 -0.076122582 -0.27510375 0 -0.27510375 0 -0.27510375 
		0 -0.27510375 0 -0.27510375 0 -0.27510375 0 -0.27510375 0 -0.27510375 0 -0.27510375 
		0 -0.27510375 0 -0.27510375 0 -0.27510375 0 -0.27510375 0 -0.27510375 -0.15626378 
		-0.27510375 -0.15626378 -0.27510375 -0.076122582 -0.27510375 -0.076122582 -0.27510375 
		0.079306692 -0.27510375 0.079306692 -0.27510375 7.6248174e-012 -0.27510375 7.6248174e-012 
		-0.27510375;
createNode polyMapCut -n "polyMapCut1";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[0:35]";
createNode materialInfo -n "Wall_Middle_Wood_04:materialInfo3";
createNode shadingEngine -n "Wall_Middle_Wood_04:lambert4SG";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode lambert -n "Wall_Middle_Wood_04:lambert4";
createNode file -n "Wall_Middle_Wood_04:file4";
	setAttr ".ftn" -type "string" "D:/Projects/RPG ENGINE/Meshes/Texture_Wall_Interior_01.png";
createNode place2dTexture -n "Wall_Middle_Wood_04:place2dTexture4";
createNode lightLinker -n "lightLinker1";
	setAttr -s 23 ".lnk";
select -ne :time1;
	setAttr ".o" 1;
select -ne :renderPartition;
	setAttr -s 23 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 23 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 29 ".u";
select -ne :lightList1;
	setAttr -s 2 ".l";
select -ne :defaultTextureList1;
	setAttr -s 29 ".tx";
select -ne :initialShadingGroup;
	setAttr -s 4 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :initialMaterialInfo;
	setAttr -s 8 ".t";
select -ne :defaultRenderGlobals;
	setAttr ".top" 767;
	setAttr ".rght" 1023;
	setAttr ".oft" -type "string" "";
	setAttr ".prm" -type "string" "";
	setAttr ".pom" -type "string" "";
select -ne :defaultRenderQuality;
	setAttr ".rfl" 10;
	setAttr ".rfr" 10;
	setAttr ".sl" 10;
	setAttr ".eaa" 0;
	setAttr ".ufil" yes;
	setAttr ".ss" 2;
	setAttr ".pss" 8;
	setAttr ".ert" yes;
	setAttr ".rct" 0.20000000298023224;
	setAttr ".gct" 0.15000000596046448;
	setAttr ".bct" 0.30000001192092896;
select -ne :defaultResolution;
	setAttr ".w" 1024;
	setAttr ".h" 768;
select -ne :defaultLightSet;
	setAttr -s 2 ".dsm";
select -ne :hardwareRenderGlobals;
	addAttr -ci true -sn "ani" -ln "animation" -bt "ANIM" -min 0 -max 1 -at "bool";
	setAttr ".fn" -type "string" "%s.%e";
	setAttr ".if" 32;
	setAttr ".edl" no;
	setAttr ".resx" 1024;
	setAttr ".resy" 768;
	setAttr ".par" 0.99999749660491943;
	setAttr ".ctrs" 512;
	setAttr ".btrs" 1024;
	setAttr ".eeaa" yes;
	setAttr ".mes" 9;
	setAttr ".trm" 1;
	setAttr ".pre" -type "string" "";
	setAttr ".pst" -type "string" "";
	setAttr ".ce" -type "string" "";
	setAttr -k on ".ani";
select -ne :defaultHardwareRenderGlobals;
	setAttr ".fn" -type "string" "im";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
select -ne :hyperGraphLayout;
	setAttr ".hyp[0].x" 808.8775634765625;
	setAttr ".hyp[0].y" 134.14285278320312;
	setAttr ".hyp[0].isc" no;
	setAttr ".hyp[0].isf" yes;
connectAttr "polyTweakUV2.out" "Wall_Middle_Wood_04:pCubeShape6.i";
connectAttr "polyTweakUV2.uvtk[0]" "Wall_Middle_Wood_04:pCubeShape6.uvst[0].uvtw"
		;
connectAttr "polyMapCut2.out" "polyTweakUV2.ip";
connectAttr "polyTweakUV1.out" "polyMapCut2.ip";
connectAttr "polyMapCut1.out" "polyTweakUV1.ip";
connectAttr "polySurfaceShape6.o" "polyMapCut1.ip";
connectAttr "Wall_Middle_Wood_04:lambert4SG.msg" "Wall_Middle_Wood_04:materialInfo3.sg"
		;
connectAttr "Wall_Middle_Wood_04:lambert4.msg" "Wall_Middle_Wood_04:materialInfo3.m"
		;
connectAttr "Wall_Middle_Wood_04:file4.msg" "Wall_Middle_Wood_04:materialInfo3.t"
		 -na;
connectAttr "Wall_Middle_Wood_04:lambert4.oc" "Wall_Middle_Wood_04:lambert4SG.ss"
		;
connectAttr "Wall_Middle_Wood_04:pCubeShape6.iog" "Wall_Middle_Wood_04:lambert4SG.dsm"
		 -na;
connectAttr "Wall_Middle_Wood_04:file4.oc" "Wall_Middle_Wood_04:lambert4.c";
connectAttr "Wall_Middle_Wood_04:place2dTexture4.c" "Wall_Middle_Wood_04:file4.c"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.tf" "Wall_Middle_Wood_04:file4.tf"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.rf" "Wall_Middle_Wood_04:file4.rf"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.mu" "Wall_Middle_Wood_04:file4.mu"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.mv" "Wall_Middle_Wood_04:file4.mv"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.s" "Wall_Middle_Wood_04:file4.s"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.wu" "Wall_Middle_Wood_04:file4.wu"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.wv" "Wall_Middle_Wood_04:file4.wv"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.re" "Wall_Middle_Wood_04:file4.re"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.of" "Wall_Middle_Wood_04:file4.of"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.r" "Wall_Middle_Wood_04:file4.ro"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.n" "Wall_Middle_Wood_04:file4.n"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.vt1" "Wall_Middle_Wood_04:file4.vt1"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.vt2" "Wall_Middle_Wood_04:file4.vt2"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.vt3" "Wall_Middle_Wood_04:file4.vt3"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.vc1" "Wall_Middle_Wood_04:file4.vc1"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.o" "Wall_Middle_Wood_04:file4.uv"
		;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.ofs" "Wall_Middle_Wood_04:file4.fs"
		;
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[0].llnk";
connectAttr ":initialShadingGroup.msg" "lightLinker1.lnk[0].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[1].llnk";
connectAttr ":initialParticleSE.msg" "lightLinker1.lnk[1].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[2].llnk";
connectAttr "lambert2SG.msg" "lightLinker1.lnk[2].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[3].llnk";
connectAttr "lambert3SG.msg" "lightLinker1.lnk[3].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[4].llnk";
connectAttr "lambert4SG.msg" "lightLinker1.lnk[4].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[5].llnk";
connectAttr "lambert5SG.msg" "lightLinker1.lnk[5].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[6].llnk";
connectAttr "Misc_Book_Magic_01_lambert3SG.msg" "lightLinker1.lnk[6].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[7].llnk";
connectAttr "Store_Chest_Wood_01_lambert5SG.msg" "lightLinker1.lnk[7].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[8].llnk";
connectAttr "Store_Chest_Wood_01_lambert5SG1.msg" "lightLinker1.lnk[8].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[9].llnk";
connectAttr "Wall_SingleEnd_Wood_01:lambert4SG.msg" "lightLinker1.lnk[9].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[10].llnk";
connectAttr "Wall_Middle_Wood_01:lambert4SG.msg" "lightLinker1.lnk[10].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[11].llnk";
connectAttr "Wall_Middle_Wood_02:lambert4SG.msg" "lightLinker1.lnk[11].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[12].llnk";
connectAttr "Wall_Single_Wood_01:lambert4SG.msg" "lightLinker1.lnk[12].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[13].llnk";
connectAttr "Wall_Double_Wood_01:lambert4SG.msg" "lightLinker1.lnk[13].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[14].llnk";
connectAttr "Wall_Middle_Wood_03:lambert4SG.msg" "lightLinker1.lnk[14].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[15].llnk";
connectAttr "Wall_Single_Wood_02:lambert4SG.msg" "lightLinker1.lnk[15].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[16].llnk";
connectAttr "Misc_Book_Magic_01:lambert3SG.msg" "lightLinker1.lnk[16].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[17].llnk";
connectAttr "Misc_Key_Gold_01:lambert3SG.msg" "lightLinker1.lnk[17].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[18].llnk";
connectAttr "Store_Chest_Wood_01:lambert5SG.msg" "lightLinker1.lnk[18].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[19].llnk";
connectAttr "Wall_Double_Wood_02:lambert4SG.msg" "lightLinker1.lnk[19].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[20].llnk";
connectAttr "Store_Chest_Wood_02:lambert5SG.msg" "lightLinker1.lnk[20].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[21].llnk";
connectAttr "Store_Chest_Wood_03:lambert5SG.msg" "lightLinker1.lnk[21].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[22].llnk";
connectAttr "Wall_Middle_Wood_04:lambert4SG.msg" "lightLinker1.lnk[22].olnk";
connectAttr "Wall_Middle_Wood_04:lambert4SG.pa" ":renderPartition.st" -na;
connectAttr "Wall_Middle_Wood_04:lambert4.msg" ":defaultShaderList1.s" -na;
connectAttr "Wall_Middle_Wood_04:place2dTexture4.msg" ":defaultRenderUtilityList1.u"
		 -na;
connectAttr "lightLinker1.msg" ":lightList1.ln" -na;
connectAttr "Wall_Middle_Wood_04:file4.msg" ":defaultTextureList1.tx" -na;
// End of Wall_Window_Wood.ma
