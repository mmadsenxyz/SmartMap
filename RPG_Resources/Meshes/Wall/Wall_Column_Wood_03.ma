//Maya ASCII 6.5 scene
//Name: Wall_Column_Wood_03.ma
//Last modified: Sun, Mar 23, 2008 11:52:14 PM
requires maya "6.5";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya Unlimited 6.5";
fileInfo "version" "6.5";
fileInfo "cutIdentifier" "200501140008-637295";
fileInfo "osv" "Microsoft Windows XP Service Pack 2 (Build 2600)\n";
createNode transform -n "Wall_Column_Wood_01:pCube6";
	setAttr ".t" -type "double3" -0.25 0 0.25 ;
createNode mesh -n "Wall_Column_Wood_01:pCubeShape6" -p "Wall_Column_Wood_01:pCube6";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 48 ".uvst[0].uvsp[0:47]" -type "float2" 0.94193256 0.60571504 
		0.88553572 0.60571504 0.94193256 0.60571504 0.88553572 0.60571504 0.88553572 0.77558023 
		0.94193256 0.77558023 0.94193256 0.82204682 0.88553572 0.82204682 0.79741967 0.60571504 
		0.74618399 0.60571504 0.74618399 0.60571504 0.79741967 0.60571504 0.89262277 0.77558023 
		0.93484551 0.77558023 0.93484551 0.77558023 0.89262277 0.77558023 0.89262277 0.77558023 
		0.89262277 0.82204676 0.93484551 0.77558023 0.93484551 0.82204676 0.79741967 0.76842272 
		0.88553572 0.77558023 0.88553572 0.76842272 0.94193256 0.77558023 0.79033256 0.77558023 
		0.88553572 0.7830556 0.75327104 0.77558023 0.88553572 0.81457132 0.94193256 0.7830556 
		0.79033256 0.77558023 0.94193256 0.81457132 0.93484551 0.82204676 0.74618399 0.76842272 
		0.88553572 0.76842266 0.94193256 0.76842266 0.74618399 0.76842266 0.94193256 0.81457132 
		0.75327104 0.77558023 0.88553572 0.81457132 0.89262277 0.82204676 0.94193256 0.7830556 
		0.93484551 0.77558023 0.89262277 0.77558023 0.88553572 0.7830556 0.94193256 0.82204682 
		0.79741967 0.76842266 0.94193256 0.76842272 0.88553572 0.82204682;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr -s 16 ".pt[0:15]" -type "float3"  1 0 1 1.5 0 1 1 0 0.5 1.5 
		0 0.5 1 0 1 1.5 0 1 1 0 0.5 1.5 0 0.5 1 0 1 1.5 0 1 1 0 1 1 0 0.5 1.5 0 1 1.5 0 0.5 
		1 0 0.5 1.5 0 0.5;
	setAttr -s 16 ".vt[0:15]"  -0.75 0 0.75 0.75 0 0.75 -0.75 0 -0.75 0.75 
		0 -0.75 -0.5 6 0.75 0.5 6 0.75 -0.5 6 -0.75 0.5 6 -0.75 -0.75 5.75 0.75 0.75 5.75 
		0.75 -0.75 6 0.5 -0.75 6 -0.5 0.75 6 0.5 0.75 6 -0.5 -0.75 5.75 -0.75 0.75 5.75 -0.75;
	setAttr -s 24 ".ed[0:23]"  0 1 0 2 3 0 
		0 8 0 1 9 0 2 0 0 3 1 0 
		4 5 0 6 7 0 10 11 0 12 13 0 
		14 2 0 15 3 0 8 4 0 4 10 0 
		10 8 0 9 12 0 12 5 0 5 9 0 
		11 6 0 6 14 0 14 11 0 13 15 0 
		15 7 0 7 13 0;
	setAttr -s 48 ".n[0:47]" -type "float3"  0 -4.5 0 0 -4.5 0 0 -4.5 0 
		0 -4.5 0 -0.0625 0.0625 0.0625 -0.0625 0.0625 0.0625 -0.0625 0.0625 0.0625 0.0625 
		0.0625 0.0625 0.0625 0.0625 0.0625 0.0625 0.0625 0.0625 -0.0625 0.0625 -0.0625 -0.0625 
		0.0625 -0.0625 -0.0625 0.0625 -0.0625 0 0 17.875 0 0 17.875 0 0 17.875 0 0 17.875 
		0 0 17.875 0 0 17.875 0.0625 0.0625 -0.0625 0.0625 0.0625 -0.0625 0.0625 0.0625 -0.0625 
		-17.875 0 0 -17.875 0 0 -17.875 0 0 -17.875 0 0 -17.875 0 0 -17.875 0 0 17.875 0 
		0 17.875 0 0 17.875 0 0 17.875 0 0 17.875 0 0 17.875 0 0 0 0 -17.875 0 0 -17.875 
		0 0 -17.875 0 0 -17.875 0 0 -17.875 0 0 -17.875 0 4.25 0 0 4.25 0 0 4.25 0 0 4.25 
		0 0 4.25 0 0 4.25 0 0 4.25 0 0 4.25 0;
	setAttr -s 10 ".fc[0:9]" -type "polyFaces" 
		f 4 1 5 -1 -5 
		mu 0 4 4 5 6 7 
		f 3 14 12 13 
		mu 0 3 43 21 42 
		f 3 15 16 17 
		mu 0 3 23 40 41 
		f 3 20 18 19 
		mu 0 3 47 27 39 
		f 6 0 3 -18 -7 -13 -3 
		mu 0 6 0 1 22 15 13 46 
		f 3 21 22 23 
		mu 0 3 31 44 36 
		f 6 4 2 -15 8 -21 10 
		mu 0 6 10 11 20 24 26 32 
		f 6 -6 -12 -22 -10 -16 -4 
		mu 0 6 8 9 35 37 29 45 
		f 6 -20 7 -23 11 -2 -11 
		mu 0 6 33 16 18 34 2 3 
		f 8 -14 6 -17 9 -24 -8 -19 -9 
		mu 0 8 25 12 14 28 30 19 17 38 ;
createNode materialInfo -n "Wall_Column_Wood_01:materialInfo3";
createNode shadingEngine -n "Wall_Column_Wood_01:lambert4SG";
	setAttr ".ihi" 0;
	setAttr -s 3 ".dsm";
	setAttr ".ro" yes;
createNode lambert -n "Wall_Column_Wood_01:lambert4";
createNode file -n "Wall_Column_Wood_01:file4";
	setAttr ".ftn" -type "string" "D:/Projects/RPG ENGINE/Meshes/Texture_Wall_Interior_01.png";
createNode place2dTexture -n "Wall_Column_Wood_01:place2dTexture4";
createNode lightLinker -n "lightLinker1";
	setAttr -s 3 ".lnk";
select -ne :time1;
	setAttr ".o" 1;
select -ne :renderPartition;
	setAttr -s 3 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 3 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
select -ne :lightList1;
select -ne :defaultTextureList1;
select -ne :lambert1;
	setAttr ".c" -type "float3" 0.5 0.327575 0.19749999 ;
select -ne :initialShadingGroup;
	setAttr -s 10 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :hardwareRenderGlobals;
	addAttr -ci true -sn "ani" -ln "animation" -bt "ANIM" -min 0 -max 1 -at "bool";
	setAttr ".fn" -type "string" "%s.%e";
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
	setAttr -k on ".ani";
select -ne :defaultHardwareRenderGlobals;
	setAttr ".fn" -type "string" "im";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
select -ne :ikSystem;
	setAttr -s 3 ".sol";
connectAttr "Wall_Column_Wood_01:lambert4SG.msg" "Wall_Column_Wood_01:materialInfo3.sg"
		;
connectAttr "Wall_Column_Wood_01:lambert4.msg" "Wall_Column_Wood_01:materialInfo3.m"
		;
connectAttr "Wall_Column_Wood_01:file4.msg" "Wall_Column_Wood_01:materialInfo3.t"
		 -na;
connectAttr "Wall_Column_Wood_01:lambert4.oc" "Wall_Column_Wood_01:lambert4SG.ss"
		;
connectAttr "Wall_Column_Wood_01:pCubeShape6.iog" "Wall_Column_Wood_01:lambert4SG.dsm"
		 -na;
connectAttr "pCubeShape6.iog" "Wall_Column_Wood_01:lambert4SG.dsm" -na;
connectAttr "pCubeShape21.iog" "Wall_Column_Wood_01:lambert4SG.dsm" -na;
connectAttr "Wall_Column_Wood_01:file4.oc" "Wall_Column_Wood_01:lambert4.c";
connectAttr "Wall_Column_Wood_01:place2dTexture4.c" "Wall_Column_Wood_01:file4.c"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.tf" "Wall_Column_Wood_01:file4.tf"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.rf" "Wall_Column_Wood_01:file4.rf"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.mu" "Wall_Column_Wood_01:file4.mu"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.mv" "Wall_Column_Wood_01:file4.mv"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.s" "Wall_Column_Wood_01:file4.s"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.wu" "Wall_Column_Wood_01:file4.wu"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.wv" "Wall_Column_Wood_01:file4.wv"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.re" "Wall_Column_Wood_01:file4.re"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.of" "Wall_Column_Wood_01:file4.of"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.r" "Wall_Column_Wood_01:file4.ro"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.n" "Wall_Column_Wood_01:file4.n"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.vt1" "Wall_Column_Wood_01:file4.vt1"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.vt2" "Wall_Column_Wood_01:file4.vt2"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.vt3" "Wall_Column_Wood_01:file4.vt3"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.vc1" "Wall_Column_Wood_01:file4.vc1"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.o" "Wall_Column_Wood_01:file4.uv"
		;
connectAttr "Wall_Column_Wood_01:place2dTexture4.ofs" "Wall_Column_Wood_01:file4.fs"
		;
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[0].llnk";
connectAttr ":initialShadingGroup.msg" "lightLinker1.lnk[0].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[1].llnk";
connectAttr ":initialParticleSE.msg" "lightLinker1.lnk[1].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[2].llnk";
connectAttr "Wall_Column_Wood_01:lambert4SG.msg" "lightLinker1.lnk[2].olnk";
connectAttr "Wall_Column_Wood_01:lambert4SG.pa" ":renderPartition.st" -na;
connectAttr "Wall_Column_Wood_01:lambert4.msg" ":defaultShaderList1.s" -na;
connectAttr "Wall_Column_Wood_01:place2dTexture4.msg" ":defaultRenderUtilityList1.u"
		 -na;
connectAttr "lightLinker1.msg" ":lightList1.ln" -na;
connectAttr "Wall_Column_Wood_01:file4.msg" ":defaultTextureList1.tx" -na;
// End of Wall_Column_Wood_03.ma
