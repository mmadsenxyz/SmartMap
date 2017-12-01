//Maya ASCII 6.5 scene
//Name: Misc_Key_Gold_01.ma
//Last modified: Mon, Feb 18, 2008 12:34:01 AM
requires maya "6.5";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya Unlimited 6.5";
fileInfo "version" "6.5";
fileInfo "cutIdentifier" "200501140008-637295";
fileInfo "osv" "Microsoft Windows XP Professional Service Pack 2 (Build 2600)\n";
createNode transform -n "pTorus1";
createNode mesh -n "pTorusShape1" -p "pTorus1";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 84 ".uvst[0].uvsp[0:83]" -type "float2" 0.8424381 0.93017256 
		0.87392122 0.93017256 0.88101721 0.94802886 0.83534205 0.94802886 0.82017612 0.90696788 
		0.80304468 0.91436446 0.82017612 0.87415266 0.80304468 0.86675608 0.8424381 0.85094821 
		0.83534205 0.83309168 0.87392122 0.85094821 0.88101721 0.83309168 0.89618313 0.87415266 
		0.91331458 0.86675608 0.89618313 0.90696788 0.91331458 0.91436446 0.88909817 0.96836352 
		0.82726121 0.96836352 0.78353584 0.92278731 0.78353584 0.85833311 0.8303377 0.82049876 
		0.81632984 0.8241511 0.83962524 0.81275707 0.84890246 0.81275707 0.93282336 0.85833311 
		0.93282336 0.92278731 0.88909817 0.96836352 0.82726121 0.96836352 0.78353584 0.92278731 
		0.78353584 0.85833311 0.93282336 0.85833311 0.93282336 0.92278731 0.88101721 0.94802886 
		0.83534217 0.94802886 0.80304468 0.91436446 0.80304468 0.86675608 0.91331458 0.86675608 
		0.91331458 0.91436446 0.83534205 0.83309168 0.88101721 0.83309168 0.83962536 0.81275707 
		0.81632984 0.8241511 0.83033776 0.82049876 0.84890258 0.81275707 0.88602149 0.82049876 
		0.86745691 0.81275707 0.87673414 0.81275707 0.90002948 0.8241511 0.87673408 0.81275707 
		0.86745691 0.81275707 0.88602149 0.82049882 0.9000293 0.8241511 0.86962152 0.67043698 
		0.8639006 0.67043698 0.85245872 0.67043698 0.84673774 0.67043698 0.84673774 0.67043698 
		0.85245872 0.67043698 0.8639006 0.67043698 0.86962152 0.67043698 0.86745691 0.68485272 
		0.87673414 0.68485272 0.84890246 0.68485272 0.83962524 0.74927151 0.83962524 0.70993596 
		0.83962524 0.68485272 0.83962536 0.74927151 0.84890258 0.68485272 0.83962536 0.68485272 
		0.83962536 0.70993596 0.86745691 0.68485272 0.87673408 0.68485272 0.77811527 0.76744092 
		0.77811521 0.76744092 0.77811521 0.6917665 0.77811527 0.69176656 0.81287998 0.74927151 
		0.81287992 0.74927151 0.81287998 0.70993596 0.81287992 0.70993596 0.79849887 0.76744092 
		0.79849887 0.76744092 0.79849887 0.6917665 0.79849887 0.69176656;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr -s 84 ".pt[0:83]" -type "float3"  -1 -2.75 0.1875 -1 -2.75 
		0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 
		-1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 
		-2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 
		0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 
		-1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 
		-2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 
		0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 
		-1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 
		-2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 
		0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 
		-1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 
		-2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 
		0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 
		-1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 
		-2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875 -1 -2.75 
		0.1875 -1 -2.75 0.1875 -1 -2.75 0.1875;
	setAttr -s 84 ".vt[0:83]"  2.0478354 2.875 0.38451511 1.9521646 2.875 
		0.38451511 1.884515 2.875 0.45216459 1.884515 2.875 0.54783547 1.9521646 2.875 0.61548495 
		2.0478354 2.875 0.61548495 2.115485 2.875 0.54783547 2.115485 2.875 0.45216459 2.080889 
		3 0.30471697 1.9191111 3 0.304717 1.8047171 3 0.41911113 1.8047171 3 0.58088893 1.9191111 
		3 0.69528306 2.080889 3 0.69528311 2.1952832 3 0.58088893 2.1952832 3 0.41911113 
		2.1343706 2.9375 0.17560089 1.8656296 2.9375 0.17560089 1.6756009 2.9375 0.36562949 
		1.6756009 2.9375 0.63437057 2.3243992 2.9375 0.63437057 2.3243992 2.9375 0.36562949 
		2.1343706 2.8125 0.17560089 1.8656296 2.8125 0.17560089 1.6756009 2.8125 0.36562949 
		1.6756009 2.8125 0.63437057 2.3243992 2.8125 0.63437057 2.324399 2.8125 0.36562949 
		2.080889 2.75 0.304717 1.9191111 2.75 0.304717 1.8047171 2.75 0.41911113 1.8047171 
		2.75 0.58088893 1.9191111 2.75 0.69528306 2.080889 2.75 0.69528306 2.1952829 2.75 
		0.58088893 2.1952829 2.75 0.41911116 1.8181224 2.9375 0.77689201 1.9328147 3 0.82439917 
		2.0671854 3 0.82439923 2.1818776 2.9375 0.77689207 1.8181224 2.8125 0.77689201 1.9328148 
		2.75 0.82439917 2.0671854 2.75 0.82439911 2.1818776 2.8125 0.77689195 1.8789999 3 
		0.79212016 2.1210001 3 0.79212022 1.8656296 2.9375 0.82439917 1.8656296 2.8125 0.82439917 
		2.1343706 2.9375 0.82439923 2.1343706 2.8125 0.82439911 1.8789999 2.75 0.79212016 
		2.1210001 2.75 0.7921201 2.0671854 3 1.4493992 2.1343706 2.9375 1.4493992 1.9328147 
		3 1.4493992 1.8656296 2.9375 1.4493992 1.8656296 2.8125 1.4493992 1.9328148 2.75 
		1.4493992 2.0671854 2.75 1.4493991 2.1343706 2.8125 1.4493991 2.041431 2.9520831 
		1.5095057 2.0828619 2.9135413 1.5095057 1.9585692 2.9520831 1.5095057 1.9171382 2.9135413 
		1.5095057 1.9171382 2.8364582 1.5095057 1.9585692 2.7979164 1.5095057 2.041431 2.7979164 
		1.5095056 2.0828619 2.8364582 1.5095056 1.8656296 2.9375 1.3174883 1.8656296 2.8125 
		1.3174883 1.8656296 2.9375 1.0683913 1.8656296 2.8125 1.0683913 1.8031296 2.8125 
		1.0683913 1.8031294 2.9375 1.0683913 1.8031296 2.8125 1.3174883 1.8031294 2.9375 
		1.3174883 1.7406296 2.7958331 1.0351784 1.7406294 2.9541664 1.0351784 1.7406296 2.7958331 
		1.3507012 1.7406294 2.9541664 1.3507012 1.6156296 2.7958331 1.0351784 1.6156294 2.9541664 
		1.0351784 1.6156296 2.7958331 1.3507012 1.6156294 2.9541664 1.3507012;
	setAttr -s 158 ".ed[0:157]"  0 1 0 1 2 0 
		2 3 0 3 4 0 4 5 0 5 6 0 
		6 7 0 7 0 0 8 9 0 9 10 0 
		10 11 0 11 12 0 12 13 0 13 14 0 
		14 15 0 15 8 0 16 17 0 17 18 0 
		18 19 0 19 36 0 20 21 0 21 16 0 
		22 23 0 23 24 0 24 25 0 25 40 0 
		26 27 0 27 22 0 28 29 0 29 30 0 
		30 31 0 31 32 0 32 33 0 33 34 0 
		34 35 0 35 28 0 0 8 0 1 9 0 
		2 10 0 3 11 0 4 12 0 5 13 0 
		6 14 0 7 15 0 8 16 0 9 17 0 
		10 18 0 11 19 0 12 44 0 13 45 0 
		14 20 0 15 21 0 16 22 0 17 23 0 
		18 24 0 19 25 0 20 26 0 21 27 0 
		22 28 0 23 29 0 24 30 0 25 31 0 
		26 34 0 27 35 0 28 0 0 29 1 0 
		30 2 0 31 3 0 32 4 0 33 5 0 
		34 6 0 35 7 0 37 38 0 39 20 0 
		41 42 0 43 26 0 46 47 0 48 49 0 
		50 32 0 51 33 0 44 36 0 36 46 0 
		46 37 0 37 44 0 45 38 0 38 48 0 
		48 39 0 39 45 0 47 40 0 40 50 0 
		50 41 0 41 47 0 49 42 0 42 51 0 
		51 43 0 43 49 0 38 52 0 48 53 0 
		52 53 0 37 54 0 54 52 0 46 70 0 
		55 54 0 47 71 0 55 56 0 41 57 0 
		57 56 0 42 58 0 57 58 0 49 59 0 
		59 58 0 53 59 0 52 60 0 53 61 0 
		60 61 0 54 62 0 62 60 0 55 63 0 
		63 62 0 56 64 0 63 64 0 57 65 0 
		65 64 0 58 66 0 65 66 0 59 67 0 
		67 66 0 61 67 0 68 55 0 69 56 0 
		69 68 0 70 68 0 71 69 0 71 70 0 
		71 72 0 70 73 0 72 73 0 69 74 0 
		72 74 0 68 75 0 74 75 0 73 75 0 
		72 76 0 73 77 0 76 77 0 74 78 0 
		76 78 0 75 79 0 78 79 0 77 79 0 
		76 80 0 77 81 0 80 81 0 78 82 0 
		80 82 0 79 83 0 82 83 0 81 83 0;
	setAttr -s 316 ".n";
	setAttr ".n[0:165]" -type "float3"  0 0.020543914 0.032181039 0 0.020543914 
		0.032181039 0 0.020543914 0.032181039 0 0.020543914 0.032181039 0.022755452 0.02054392 
		0.022755474 0.022755452 0.02054392 0.022755474 0.022755452 0.02054392 0.022755474 
		0.022755452 0.02054392 0.022755474 0.032181084 0.020543886 0 0.032181084 0.020543886 
		0 0.032181084 0.020543886 0 0.032181084 0.020543886 0 0.022755459 0.020543922 -0.022755489 
		0.022755459 0.020543922 -0.022755489 0.022755459 0.020543922 -0.022755489 0.022755459 
		0.020543922 -0.022755489 7.4505806e-009 0.020543901 -0.032181054 7.4505806e-009 0.020543901 
		-0.032181054 7.4505806e-009 0.020543901 -0.032181054 7.4505806e-009 0.020543901 -0.032181054 
		-0.022755466 0.020543987 -0.022755474 -0.022755466 0.020543987 -0.022755474 -0.022755466 
		0.020543987 -0.022755474 -0.022755466 0.020543987 -0.022755474 -0.032181077 0.020543983 
		0 -0.032181077 0.020543983 0 -0.032181077 0.020543983 0 -0.032181077 0.020543983 
		0 -0.022755455 0.020543968 0.022755474 -0.022755455 0.020543968 0.022755474 -0.022755455 
		0.020543968 0.022755474 -0.022755455 0.020543968 0.022755474 -1.8626451e-009 0.055586915 
		-0.026907414 -1.8626451e-009 0.055586915 -0.026907414 -1.8626451e-009 0.055586915 
		-0.026907414 -1.8626451e-009 0.055586915 -0.026907414 -0.019026421 0.055586901 -0.019026391 
		-0.019026421 0.055586901 -0.019026391 -0.019026421 0.055586901 -0.019026391 -0.019026421 
		0.055586901 -0.019026391 -0.026907429 0.055586953 7.4505806e-009 -0.026907429 0.055586953 
		7.4505806e-009 -0.026907429 0.055586953 7.4505806e-009 -0.026907429 0.055586953 7.4505806e-009 
		-0.0049866363 0.0043373471 0.0063326061 -0.0049866363 0.0043373471 0.0063326061 -0.0049866363 
		0.0043373471 0.0063326061 -0.0049866363 0.0043373471 0.0063326061 0.026907433 0.055586874 
		0 0.026907433 0.055586874 0 0.026907433 0.055586874 0 0.026907433 0.055586874 0 0.019026423 
		0.055586871 -0.019026428 0.019026423 0.055586871 -0.019026428 0.019026423 0.055586871 
		-0.019026428 0.019026423 0.055586871 -0.019026428 0 0 -0.067185298 0 0 -0.067185298 
		0 0 -0.067185298 0 0 -0.067185298 -0.047507152 -2.1991852e-008 -0.047507107 -0.047507152 
		-2.1991852e-008 -0.047507107 -0.047507152 -2.1991852e-008 -0.047507107 -0.047507152 
		-2.1991852e-008 -0.047507107 -0.067185268 5.0679176e-009 0 -0.067185268 5.0679176e-009 
		0 -0.067185268 5.0679176e-009 0 -0.067185268 5.0679176e-009 0 0.067185268 -1.1414137e-007 
		-2.9802322e-008 0.067185268 -1.1414137e-007 -2.9802322e-008 0.067185268 -1.1414137e-007 
		-2.9802322e-008 0.067185268 -1.1414137e-007 -2.9802322e-008 0.047507152 -2.1991852e-008 
		-0.047507018 0.047507152 -2.1991852e-008 -0.047507018 0.047507152 -2.1991852e-008 
		-0.047507018 0.047507152 -2.1991852e-008 -0.047507018 0 -0.055586915 -0.026907414 
		0 -0.055586915 -0.026907414 0 -0.055586915 -0.026907414 0 -0.055586915 -0.026907414 
		-0.019026421 -0.05558693 -0.01902651 -0.019026421 -0.05558693 -0.01902651 -0.019026421 
		-0.05558693 -0.01902651 -0.019026421 -0.05558693 -0.01902651 -0.026907429 -0.055586923 
		7.4505806e-009 -0.026907429 -0.055586923 7.4505806e-009 -0.026907429 -0.055586923 
		7.4505806e-009 -0.026907429 -0.055586923 7.4505806e-009 0.026907431 -0.055586975 
		0 0.026907431 -0.055586975 0 0.026907431 -0.055586975 0 0.026907431 -0.055586975 
		0 0.019026425 -0.055586923 -0.019026369 0.019026425 -0.055586923 -0.019026369 0.019026425 
		-0.055586923 -0.019026369 0.019026425 -0.055586923 -0.019026369 0 -0.020543914 0.032181099 
		0 -0.020543914 0.032181099 0 -0.020543914 0.032181099 0 -0.020543914 0.032181099 
		0.022755452 -0.02054389 0.022755474 0.022755452 -0.02054389 0.022755474 0.022755452 
		-0.02054389 0.022755474 0.022755452 -0.02054389 0.022755474 0.032181084 -0.020543842 
		0 0.032181084 -0.020543842 0 0.032181084 -0.020543842 0 0.032181084 -0.020543842 
		0 0.022755459 -0.020543922 -0.022755459 0.022755459 -0.020543922 -0.022755459 0.022755459 
		-0.020543922 -0.022755459 0.022755459 -0.020543922 -0.022755459 0 -0.020543894 -0.032181054 
		0 -0.020543894 -0.032181054 0 -0.020543894 -0.032181054 0 -0.020543894 -0.032181054 
		-0.022755452 -0.020543927 -0.022755474 -0.022755452 -0.020543927 -0.022755474 -0.022755452 
		-0.020543927 -0.022755474 -0.022755452 -0.020543927 -0.022755474 -0.032181073 -0.020543851 
		0 -0.032181073 -0.020543851 0 -0.032181073 -0.020543851 0 -0.032181073 -0.020543851 
		0 -0.022755459 -0.020543912 0.022755444 -0.022755459 -0.020543912 0.022755444 -0.022755459 
		-0.020543912 0.022755444 -0.022755459 -0.020543912 0.022755444 -0.022109538 0.053418234 
		0.013550282 -0.022109538 0.053418234 0.013550282 -0.022109538 0.053418234 0.013550282 
		-0.022109538 0.053418234 0.013550282 -0.022109538 0.053418234 0.013550282 -0.0049866363 
		-0.0043373508 0.0063326284 -0.0049866363 -0.0043373508 0.0063326284 -0.0049866363 
		-0.0043373508 0.0063326284 -0.0049866363 -0.0043373508 0.0063326284 0.0049866363 
		0.004337348 0.0063325912 0.0049866363 0.004337348 0.0063325912 0.0049866363 0.004337348 
		0.0063325912 0.0049866363 0.004337348 0.0063325912 0 0.05124953 0 0 0.05124953 0 
		0 0.05124953 0 0 0.05124953 0 0 0.05124953 0 0 0.05124953 0 0.022109549 0.053418264 
		0.013550282 0.022109549 0.053418264 0.013550282 0.022109549 0.053418264 0.013550282 
		0.022109549 0.053418264 0.013550282 0.022109549 0.053418264 0.013550282 -0.047507152 
		-3.1550726e-008 0.047507122 -0.047507152 -3.1550726e-008 0.047507122 -0.047507152 
		-3.1550726e-008 0.047507122 -0.047507152 -3.1550726e-008 0.047507122 -0.047507152 
		-3.1550726e-008 0.047507122 -0.047507152 -3.1550726e-008 0.047507122 -0.022109542 
		-0.053418264 0.013550341 -0.022109542 -0.053418264 0.013550341 -0.022109542 -0.053418264 
		0.013550341 -0.022109542 -0.053418264 0.013550341 -0.022109542 -0.053418264 0.013550341 
		0.0049866363 -0.0043373443 0.0063326061 0.0049866363 -0.0043373443 0.0063326061 0.0049866363 
		-0.0043373443 0.0063326061;
	setAttr ".n[166:315]" -type "float3"  0.0049866363 -0.0043373443 0.0063326061 
		2.8320699e-008 -1.9755817e-008 0.04471086 2.8320699e-008 -1.9755817e-008 0.04471086 
		2.8320699e-008 -1.9755817e-008 0.04471086 2.8320699e-008 -1.9755817e-008 0.04471086 
		2.8320699e-008 -1.9755817e-008 0.04471086 2.8320699e-008 -1.9755817e-008 0.04471086 
		2.8320699e-008 -1.9755817e-008 0.04471086 2.8320699e-008 -1.9755817e-008 0.04471086 
		0 -0.051249549 -5.9604645e-008 0 -0.051249549 -5.9604645e-008 0 -0.051249549 -5.9604645e-008 
		0 -0.051249549 -5.9604645e-008 0 -0.051249549 -5.9604645e-008 0 -0.051249549 -5.9604645e-008 
		0.022109535 -0.053418249 0.013550267 0.022109535 -0.053418249 0.013550267 0.022109535 
		-0.053418249 0.013550267 0.022109535 -0.053418249 0.013550267 0.022109535 -0.053418249 
		0.013550267 0.047507152 -2.1360506e-008 0.047507077 0.047507152 -2.1360506e-008 0.047507077 
		0.047507152 -2.1360506e-008 0.047507077 0.047507152 -2.1360506e-008 0.047507077 0.047507152 
		-2.1360506e-008 0.047507077 0.047507152 -2.1360506e-008 0.047507077 0.078125 0.083981454 
		-1.4901161e-008 0.078125 0.083981454 -1.4901161e-008 0.078125 0.083981454 -1.4901161e-008 
		0.078125 0.083981454 -1.4901161e-008 0 0.16796327 0 0 0.16796327 0 0 0.16796327 0 
		0 0.16796327 0 -0.078125007 0.083981417 -1.4901161e-008 -0.078125007 0.083981417 
		-1.4901161e-008 -0.078125007 0.083981417 -1.4901161e-008 -0.078125007 0.083981417 
		-1.4901161e-008 -0.078125007 0.083981417 -1.4901161e-008 -0.078125007 0.083981417 
		-1.4901161e-008 -0.060998037 -1.5601486e-008 0 -0.060998037 -1.5601486e-008 0 -0.060998037 
		-1.5601486e-008 0 -0.060998037 -1.5601486e-008 0 -0.078125007 -0.083981588 -7.4505806e-009 
		-0.078125007 -0.083981588 -7.4505806e-009 -0.078125007 -0.083981588 -7.4505806e-009 
		-0.078125007 -0.083981588 -7.4505806e-009 -0.078125007 -0.083981588 -7.4505806e-009 
		-0.078125007 -0.083981588 -7.4505806e-009 0 -0.16796322 0 0 -0.16796322 0 0 -0.16796322 
		0 0 -0.16796322 0 0.078125 -0.083981514 -1.4901161e-008 0.078125 -0.083981514 -1.4901161e-008 
		0.078125 -0.083981514 -1.4901161e-008 0.078125 -0.083981514 -1.4901161e-008 0.15625 
		-5.9604645e-008 0 0.15625 -5.9604645e-008 0 0.15625 -5.9604645e-008 0 0.15625 -5.9604645e-008 
		0 0.0060732695 0.0065285303 0.0078068329 0.0060732695 0.0065285303 0.0078068329 0.0060732695 
		0.0065285303 0.0078068329 0.0060732695 0.0065285303 0.0078068329 1.6940476e-009 0.013057092 
		0.010409091 1.6940476e-009 0.013057092 0.010409091 1.6940476e-009 0.013057092 0.010409091 
		1.6940476e-009 0.013057092 0.010409091 -0.0060732644 0.0065285317 0.007806804 -0.0060732644 
		0.0065285317 0.007806804 -0.0060732644 0.0065285317 0.007806804 -0.0060732644 0.0065285317 
		0.007806804 -0.012146526 -4.332037e-009 0.010409032 -0.012146526 -4.332037e-009 0.010409032 
		-0.012146526 -4.332037e-009 0.010409032 -0.012146526 -4.332037e-009 0.010409032 -0.0060732723 
		-0.0065285456 0.0078067784 -0.0060732723 -0.0065285456 0.0078067784 -0.0060732723 
		-0.0065285456 0.0078067784 -0.0060732723 -0.0065285456 0.0078067784 1.7901584e-008 
		-0.013057086 0.010408984 1.7901584e-008 -0.013057086 0.010408984 1.7901584e-008 -0.013057086 
		0.010408984 1.7901584e-008 -0.013057086 0.010408984 0.0060732728 -0.0065285326 0.0078067565 
		0.0060732728 -0.0065285326 0.0078067565 0.0060732728 -0.0065285326 0.0078067565 0.0060732728 
		-0.0065285326 0.0078067565 0.012146498 3.7613859e-009 0.010409026 0.012146498 3.7613859e-009 
		0.010409026 0.012146498 3.7613859e-009 0.010409026 0.012146498 3.7613859e-009 0.010409026 
		-0.03297773 4.0822385e-009 0 -0.03297773 4.0822385e-009 0 -0.03297773 4.0822385e-009 
		0 -0.03297773 4.0822385e-009 0 -0.099915519 -8.5694126e-008 0 -0.099915519 -8.5694126e-008 
		0 -0.099915519 -8.5694126e-008 0 -0.099915519 -8.5694126e-008 0 0 0 -0.015625015 
		0 0 -0.015625015 0 0 -0.015625015 0 0 -0.015625015 0 -0.031137098 0 0 -0.031137098 
		0 0 -0.031137098 0 0 -0.031137098 0 0 0 0.01562503 0 0 0.01562503 0 0 0.01562503 
		0 0 0.01562503 0 0.031137157 1.4901161e-008 0 0.031137157 1.4901161e-008 0 0.031137157 
		1.4901161e-008 0 0.031137157 1.4901161e-008 0.0094103152 1.0902909e-008 -0.017708331 
		0.0094103152 1.0902909e-008 -0.017708331 0.0094103152 1.0902909e-008 -0.017708331 
		0.0094103152 1.0902909e-008 -0.017708331 0.009410454 -0.035288755 0 0.009410454 -0.035288755 
		0 0.009410454 -0.035288755 0 0.009410454 -0.035288755 0 0.0094103208 4.4662443e-009 
		0.017708331 0.0094103208 4.4662443e-009 0.017708331 0.0094103208 4.4662443e-009 0.017708331 
		0.0094103208 4.4662443e-009 0.017708331 0.0094101867 0.03528871 0 0.0094101867 0.03528871 
		0 0.0094101867 0.03528871 0 0.0094101867 0.03528871 0 8.1970484e-009 0 -0.039583325 
		8.1970484e-009 0 -0.039583325 8.1970484e-009 0 -0.039583325 8.1970484e-009 0 -0.039583325 
		0 -0.078880675 0 0 -0.078880675 0 0 -0.078880675 0 0 -0.078880675 0 -1.2362875e-008 
		0 0.039583325 -1.2362875e-008 0 0.039583325 -1.2362875e-008 0 0.039583325 -1.2362875e-008 
		0 0.039583325 0 0.078880757 0 0 0.078880757 0 0 0.078880757 0 0 0.078880757 0;
	setAttr -s 74 ".fc[0:73]" -type "polyFaces" 
		f 4 -1 36 8 -38 
		mu 0 4 0 1 2 3 
		f 4 -2 37 9 -39 
		mu 0 4 4 0 3 5 
		f 4 -3 38 10 -40 
		mu 0 4 6 4 5 7 
		f 4 -4 39 11 -41 
		mu 0 4 8 6 7 9 
		f 4 -5 40 12 -42 
		mu 0 4 10 8 9 11 
		f 4 -6 41 13 -43 
		mu 0 4 12 10 11 13 
		f 4 -7 42 14 -44 
		mu 0 4 14 12 13 15 
		f 4 -8 43 15 -37 
		mu 0 4 1 14 15 2 
		f 4 -9 44 16 -46 
		mu 0 4 3 2 16 17 
		f 4 -10 45 17 -47 
		mu 0 4 5 3 17 18 
		f 4 -11 46 18 -48 
		mu 0 4 7 5 18 19 
		f 4 80 81 82 83 
		mu 0 4 20 21 22 23 
		f 4 -15 50 20 -52 
		mu 0 4 15 13 24 25 
		f 4 -16 51 21 -45 
		mu 0 4 2 15 25 16 
		f 4 -17 52 22 -54 
		mu 0 4 17 16 26 27 
		f 4 -18 53 23 -55 
		mu 0 4 18 17 27 28 
		f 4 -19 54 24 -56 
		mu 0 4 19 18 28 29 
		f 4 -21 56 26 -58 
		mu 0 4 25 24 30 31 
		f 4 -22 57 27 -53 
		mu 0 4 16 25 31 26 
		f 4 -23 58 28 -60 
		mu 0 4 27 26 32 33 
		f 4 -24 59 29 -61 
		mu 0 4 28 27 33 34 
		f 4 -25 60 30 -62 
		mu 0 4 29 28 34 35 
		f 4 -27 62 34 -64 
		mu 0 4 31 30 36 37 
		f 4 -28 63 35 -59 
		mu 0 4 26 31 37 32 
		f 4 -29 64 0 -66 
		mu 0 4 33 32 1 0 
		f 4 -30 65 1 -67 
		mu 0 4 34 33 0 4 
		f 4 -31 66 2 -68 
		mu 0 4 35 34 4 6 
		f 4 -32 67 3 -69 
		mu 0 4 38 35 6 8 
		f 4 -33 68 4 -70 
		mu 0 4 39 38 8 10 
		f 4 -34 69 5 -71 
		mu 0 4 36 39 10 12 
		f 4 -35 70 6 -72 
		mu 0 4 37 36 12 14 
		f 4 -36 71 7 -65 
		mu 0 4 32 37 14 1 
		f 5 -12 47 19 -81 -49 
		mu 0 5 9 7 19 21 20 
		f 4 88 89 90 91 
		mu 0 4 40 41 42 43 
		f 4 84 85 86 87 
		mu 0 4 44 45 46 47 
		f 6 -13 48 -84 72 -85 -50 
		mu 0 6 11 9 20 23 45 44 
		f 5 -14 49 -88 73 -51 
		mu 0 5 13 11 44 47 24 
		f 6 -82 -20 55 25 -89 -77 
		mu 0 6 22 21 19 29 41 40 
		f 5 -90 -26 61 31 -79 
		mu 0 5 42 41 29 35 38 
		f 4 92 93 94 95 
		mu 0 4 48 49 50 51 
		f 8 -115 -117 -119 120 -123 124 -127 -128 
		mu 0 8 52 53 54 55 56 57 58 59 
		f 6 -94 -75 -91 78 32 -80 
		mu 0 6 50 49 43 42 38 39 
		f 5 -76 -95 79 33 -63 
		mu 0 5 30 51 50 39 36 
		f 6 -74 -87 77 -96 75 -57 
		mu 0 6 24 47 46 48 51 30 
		f 4 -86 96 98 -98 
		mu 0 4 46 45 60 61 
		f 4 -73 99 100 -97 
		mu 0 4 45 23 62 60 
		f 6 -83 101 131 128 102 -100 
		mu 0 6 23 22 63 64 65 62 
		f 4 76 103 133 -102 
		mu 0 4 22 40 66 63 
		f 6 -92 105 106 -130 -133 -104 
		mu 0 6 40 43 67 68 69 66 
		f 4 74 107 -109 -106 
		mu 0 4 43 49 70 67 
		f 4 -93 109 110 -108 
		mu 0 4 49 48 71 70 
		f 4 -78 97 111 -110 
		mu 0 4 48 46 61 71 
		f 4 -99 112 114 -114 
		mu 0 4 61 60 53 52 
		f 4 -101 115 116 -113 
		mu 0 4 60 62 54 53 
		f 4 -103 117 118 -116 
		mu 0 4 62 65 55 54 
		f 4 104 119 -121 -118 
		mu 0 4 65 68 56 55 
		f 4 -107 121 122 -120 
		mu 0 4 68 67 57 56 
		f 4 108 123 -125 -122 
		mu 0 4 67 70 58 57 
		f 4 -111 125 126 -124 
		mu 0 4 70 71 59 58 
		f 4 -112 113 127 -126 
		mu 0 4 71 61 52 59 
		f 4 -131 129 -105 -129 
		mu 0 4 64 69 68 65 
		f 4 -153 154 156 -158 
		mu 0 4 72 73 74 75 
		f 4 -134 134 136 -136 
		mu 0 4 63 66 76 77 
		f 4 132 137 -139 -135 
		mu 0 4 66 69 78 76 
		f 4 130 139 -141 -138 
		mu 0 4 69 64 79 78 
		f 4 -132 135 141 -140 
		mu 0 4 64 63 77 79 
		f 4 -137 142 144 -144 
		mu 0 4 77 76 80 81 
		f 4 138 145 -147 -143 
		mu 0 4 76 78 82 80 
		f 4 140 147 -149 -146 
		mu 0 4 78 79 83 82 
		f 4 -142 143 149 -148 
		mu 0 4 79 77 81 83 
		f 4 -145 150 152 -152 
		mu 0 4 81 80 73 72 
		f 4 146 153 -155 -151 
		mu 0 4 80 82 74 73 
		f 4 148 155 -157 -154 
		mu 0 4 82 83 75 74 
		f 4 -150 151 157 -156 
		mu 0 4 83 81 72 75 ;
createNode transform -s -n "persp";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -3.4803709257142996 7.7646637071222795 4.8256532997385602 ;
	setAttr ".r" -type "double3" -52.538352729677662 -35.800000000001454 -1.9607302206051377e-015 ;
createNode camera -s -n "perspShape" -p "persp";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 9.7821221641592206;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 100 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100;
	setAttr ".ow" 6.62007659447886;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 100 ;
createNode camera -s -n "frontShape" -p "front";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100;
	setAttr ".ow" 6.7924992729289873;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 100 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100;
	setAttr ".ow" 10.964860987071603;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode materialInfo -n "materialInfo2";
createNode shadingEngine -n "lambert3SG";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode lambert -n "lambert3";
createNode file -n "file3";
	setAttr ".ftn" -type "string" "D:/Projects/RPG ENGINE/Meshes/Texture_Book_Big_01.png";
createNode place2dTexture -n "place2dTexture3";
createNode lightLinker -n "lightLinker1";
	setAttr -s 3 ".lnk";
createNode displayLayerManager -n "layerManager";
createNode displayLayer -n "defaultLayer";
createNode renderLayerManager -n "renderLayerManager";
createNode renderLayer -n "defaultRenderLayer";
createNode renderLayer -s -n "globalRender";
createNode script -n "uiConfigurationScriptNode";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" \"Top View\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l \"Top View\" -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"top\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -wireframeOnShaded 0\n"
		+ "                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 4096\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n"
		+ "                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -locators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -shadows 0\n"
		+ "                $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l \"Top View\" -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -wireframeOnShaded 0\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 4096\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n"
		+ "            -hairSystems 1\n            -follicles 1\n            -locators 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -shadows 0\n            $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" \"Side View\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l \"Side View\" -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"side\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -wireframeOnShaded 0\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -displayTextures 0\n"
		+ "                -smoothWireframe 0\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 4096\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n"
		+ "                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -locators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -shadows 0\n                $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l \"Side View\" -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -wireframeOnShaded 0\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 4096\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n"
		+ "            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -locators 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n"
		+ "            -shadows 0\n            $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" \"Front View\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l \"Front View\" -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"front\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -wireframeOnShaded 0\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n"
		+ "                -textureMaxSize 4096\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n"
		+ "                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -locators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -shadows 0\n                $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l \"Front View\" -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n"
		+ "            -activeOnly 0\n            -wireframeOnShaded 0\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 4096\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n"
		+ "            -occlusionCulling 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -locators 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -shadows 0\n            $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" \"Persp View\"`;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l \"Persp View\" -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -wireframeOnShaded 0\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -displayTextures 1\n                -smoothWireframe 0\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 4096\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n"
		+ "                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n"
		+ "                -hulls 1\n                -grid 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -locators 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -shadows 0\n                $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l \"Persp View\" -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -wireframeOnShaded 0\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 4096\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n"
		+ "            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -locators 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -shadows 0\n            $editorName;\nmodelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" \"Outliner\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `outlinerPanel -unParent -l \"Outliner\" -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n"
		+ "            outlinerEditor -e \n                -mainListConnection \"worldList\" \n                -selectionConnection \"modelList\" \n                -showShapes 0\n                -showAttributes 0\n                -showConnected 0\n                -showAnimCurvesOnly 0\n                -autoExpand 0\n                -showDagOnly 1\n                -ignoreDagHierarchy 0\n                -expandConnections 0\n                -showUnitlessCurves 1\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 0\n                -highlightActive 1\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"defaultSetFilter\" \n                -showSetMembers 1\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -editAttrName 0\n"
		+ "                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l \"Outliner\" -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -mainListConnection \"worldList\" \n            -selectionConnection \"modelList\" \n            -showShapes 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -autoExpand 0\n            -showDagOnly 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n"
		+ "            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" \"Graph Editor\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"graphEditor\" -l \"Graph Editor\" -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -mainListConnection \"graphEditorList\" \n                -selectionConnection \"graphEditor1FromOutliner\" \n"
		+ "                -highlightConnection \"keyframeList\" \n                -showShapes 1\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -autoExpand 1\n                -showDagOnly 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n"
		+ "                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -mainListConnection \"graphEditor1FromOutliner\" \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Graph Editor\" -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n"
		+ "            outlinerEditor -e \n                -mainListConnection \"graphEditorList\" \n                -selectionConnection \"graphEditor1FromOutliner\" \n                -highlightConnection \"keyframeList\" \n                -showShapes 1\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -autoExpand 1\n                -showDagOnly 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n"
		+ "                -setsIgnoreFilters 1\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -mainListConnection \"graphEditor1FromOutliner\" \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" \"Dope Sheet\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dopeSheetPanel\" -l \"Dope Sheet\" -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -mainListConnection \"animationList\" \n                -selectionConnection \"dopeSheetPanel1OutlinerSelection\" \n                -highlightConnection \"keyframeList\" \n                -showShapes 1\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -autoExpand 0\n                -showDagOnly 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n"
		+ "                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -mainListConnection \"dopeSheetPanel1FromOutliner\" \n                -highlightConnection \"dopeSheetPanel1OutlinerSelection\" \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n"
		+ "                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Dope Sheet\" -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -mainListConnection \"animationList\" \n                -selectionConnection \"dopeSheetPanel1OutlinerSelection\" \n                -highlightConnection \"keyframeList\" \n                -showShapes 1\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -autoExpand 0\n                -showDagOnly 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUnitlessCurves 0\n"
		+ "                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -mainListConnection \"dopeSheetPanel1FromOutliner\" \n                -highlightConnection \"dopeSheetPanel1OutlinerSelection\" \n"
		+ "                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" \"Trax Editor\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"clipEditorPanel\" -l \"Trax Editor\" -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -mainListConnection \"lockedList1\" \n                -highlightConnection \"clipEditorPanel1HighlightConnection\" \n                -displayKeys 0\n"
		+ "                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Trax Editor\" -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -mainListConnection \"lockedList1\" \n                -highlightConnection \"clipEditorPanel1HighlightConnection\" \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" \"Hypergraph\"`;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperGraphPanel\" -l \"Hypergraph\" -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -orientation \"horiz\" \n                -zoom 1\n                -animateTransition 0\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -freeform 0\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Hypergraph\" -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -orientation \"horiz\" \n"
		+ "                -zoom 1\n                -animateTransition 0\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -freeform 0\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" \"Hypershade\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperShadePanel\" -l \"Hypershade\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Hypershade\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" \"Visor\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"visorPanel\" -l \"Visor\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Visor\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" \"UV Texture Editor\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"polyTexturePlacementPanel\" -l \"UV Texture Editor\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"UV Texture Editor\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"multiListerPanel\" \"Multilister\"`;\n\tif (\"\" == $panelName) {\n"
		+ "\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"multiListerPanel\" -l \"Multilister\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Multilister\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" \"Render View\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"renderWindowPanel\" -l \"Render View\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Render View\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"blendShapePanel\" \"Blend Shape\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\tblendShapePanel -unParent -l \"Blend Shape\" -mbv $menusOkayInPanels ;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tblendShapePanel -edit -l \"Blend Shape\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" \"Dynamic Relationships\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynRelEdPanel\" -l \"Dynamic Relationships\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Dynamic Relationships\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"devicePanel\" \"Devices\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\tdevicePanel -unParent -l \"Devices\" -mbv $menusOkayInPanels ;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tdevicePanel -edit -l \"Devices\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" \"Relationship Editor\"`;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"relationshipPanel\" -l \"Relationship Editor\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Relationship Editor\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" \"Reference Editor\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"referenceEditorPanel\" -l \"Reference Editor\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Reference Editor\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" \"Component Editor\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"componentEditorPanel\" -l \"Component Editor\" -mbv $menusOkayInPanels `;\n"
		+ "\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Component Editor\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" \"Paint Effects\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynPaintScriptedPanelType\" -l \"Paint Effects\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Paint Effects\" -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"webBrowserPanel\" \"Web Browser\"`;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"webBrowserPanel\" -l \"Web Browser\" -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l \"Web Browser\" -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl \"Current Layout\"`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label \"Current Layout\"\n\t\t\t\t-defaultImage \"\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"quad\\\" -ps 1 38 61 -ps 2 62 61 -ps 3 62 39 -ps 4 38 39 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t\"Top View\"\n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l \\\"Top View\\\" -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera top` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -wireframeOnShaded 0\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 4096\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -locators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l \\\"Top View\\\" -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera top` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -wireframeOnShaded 0\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 4096\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -locators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t\"Persp View\"\n\t\t\t\t\t\"modelPanel\"\n\t\t\t\t\t\"$panelName = `modelPanel -unParent -l \\\"Persp View\\\" -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -wireframeOnShaded 0\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 4096\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -locators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l \\\"Persp View\\\" -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -wireframeOnShaded 0\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 4096\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -locators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t\"Side View\"\n\t\t\t\t\t\"modelPanel\"\n\t\t\t\t\t\"$panelName = `modelPanel -unParent -l \\\"Side View\\\" -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera side` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -wireframeOnShaded 0\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 4096\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -locators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l \\\"Side View\\\" -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera side` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -wireframeOnShaded 0\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 4096\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -locators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t-ap false\n\t\t\t\t\t\"Front View\"\n\t\t\t\t\t\"modelPanel\"\n\t\t\t\t\t\"$panelName = `modelPanel -unParent -l \\\"Front View\\\" -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera front` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -wireframeOnShaded 0\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 4096\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -locators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l \\\"Front View\\\" -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera front` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"wireframe\\\" \\n    -activeOnly 0\\n    -wireframeOnShaded 0\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 4096\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -locators 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout \"Current Layout\";\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        setFocus `paneLayout -q -p1 $gMainPane`;\n        sceneUIReplacement -deleteRemaining;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 165 -ast 1 -aet 165 ";
	setAttr ".st" 6;
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
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".edl" no;
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
connectAttr "lambert3SG.msg" "materialInfo2.sg";
connectAttr "lambert3.msg" "materialInfo2.m";
connectAttr "file3.msg" "materialInfo2.t" -na;
connectAttr "lambert3.oc" "lambert3SG.ss";
connectAttr "pTorusShape1.iog" "lambert3SG.dsm" -na;
connectAttr "file3.oc" "lambert3.c";
connectAttr "place2dTexture3.c" "file3.c";
connectAttr "place2dTexture3.tf" "file3.tf";
connectAttr "place2dTexture3.rf" "file3.rf";
connectAttr "place2dTexture3.mu" "file3.mu";
connectAttr "place2dTexture3.mv" "file3.mv";
connectAttr "place2dTexture3.s" "file3.s";
connectAttr "place2dTexture3.wu" "file3.wu";
connectAttr "place2dTexture3.wv" "file3.wv";
connectAttr "place2dTexture3.re" "file3.re";
connectAttr "place2dTexture3.of" "file3.of";
connectAttr "place2dTexture3.r" "file3.ro";
connectAttr "place2dTexture3.n" "file3.n";
connectAttr "place2dTexture3.vt1" "file3.vt1";
connectAttr "place2dTexture3.vt2" "file3.vt2";
connectAttr "place2dTexture3.vt3" "file3.vt3";
connectAttr "place2dTexture3.vc1" "file3.vc1";
connectAttr "place2dTexture3.o" "file3.uv";
connectAttr "place2dTexture3.ofs" "file3.fs";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[0].llnk";
connectAttr ":initialShadingGroup.msg" "lightLinker1.lnk[0].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[1].llnk";
connectAttr ":initialParticleSE.msg" "lightLinker1.lnk[1].olnk";
connectAttr ":defaultLightSet.msg" "lightLinker1.lnk[3].llnk";
connectAttr "lambert3SG.msg" "lightLinker1.lnk[3].olnk";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "lambert3SG.pa" ":renderPartition.st" -na;
connectAttr "lambert3.msg" ":defaultShaderList1.s" -na;
connectAttr "place2dTexture3.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "lightLinker1.msg" ":lightList1.ln" -na;
connectAttr "file3.msg" ":defaultTextureList1.tx" -na;
// End of Misc_Key_Gold_01.ma
