# Bhaptics_Longbow_Archery

## Summary
Archery game for Tactosy demo - in Bhaptics.co
Constructed with Unity 5 and Tactosy(Win).
Author: codeblv (contact@codeblv@.net)

### To Do List
1. Modification of Archery weeble Object
	- If damaged -> Bang!
	- Insert codes for score
	- If hit, numHit++
2. Random generate System
	- Generate archery weebles randomly of field
	- Have to look center: https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
	- Source 1: https://www.youtube.com/watch?v=WGn1zvLSndk
	- Source 2: https://www.youtube.com/watch?v=kTvBRkPTvRY
3. Score Board System
	- Calculate 2 things: Accuracy, Score
	- Have to count: Score, numHit, numShot
	- Board show -> via UnityEngine.UI (Canvas?)

## Developer's Note
### 17.03.29 WED
The first day of project. Spent too much time on VR setting issues...
* Project started.
* CRLF&LF Problem solved
: http://handam.tistory.com/127
* "sampleVRTK.unity" constructed with a lecture clip
: https://www.youtube.com/watch?v=yMYomOO9G4k
* Problem occured: A bow disappears when game starts
: Fixed - collider didn't set yet -> Colider set
* Objects can not be grabbed
: They don't be child of controller -> Solved (Mappping Problem)
* Oculus frame problem
: Only appears in usage of Oculus not HTC Vive. Looks VRTK and tracking Problem.
	- Need to set VR area again, check whether it is VRTK problem or not.
	- It was a tracking problem. After reset oculus sensor, the problem solved.
* Main graphic scene construction started - "mainScene.unity"
	- Finding for proper assets
* Tried to make able to grab an arrow but failed.
	- Have to find difference compare to sample file
	- Copied VRTK into my own scene, but problem doesn't solved yet.
* The first issue should be solved: "Grab an arrow"
### 17.03.31 FRI
SteamVR and VRTK seems based on HTC Vive. Therefore, it is not very-fit to Oculus. However, Unity supports Oculus based developments in its environment. Have to learn more to optimize the game.
* By compare&contrast, tried to solve an issue(grab an arrow).
* Because of a device problem(GPU) computer changed.
* Unity and git settsing
* Issue: Grab an arrow
	- Grab is able, however blue arrow(in eg code) appears and is grabbed.
	- Looks a script problem. Analysis started.
* Oculus account lost... Wait for help.
* Oculus doesn't work in SteamVR environment.
* Another error -> Playing VR makes Unity to shut down.
	- Seems project should be reset.

### 17.04.02 SUN
This is a Suday afternoon~ 
* git made again, bdecause of authorization problem...
* too much problems with setting...
* Git authorization problem solved: via GitHubDesktop
* Problem of Crash: VRTK prefab
* How can I do it differently?
	- Have to study Unity VR deeply....


### 17.04.10 MON
End of vacations
* Made a new git repository.
* Changed into Oculus only dev (do not use openVR, steam, VRTK.etc)
* Studying....
* Seems not too hard

### 17.04.12 WED
Hard working WED!
* Grab problem was solved!
* Need to calibrate the bow to stick to hand properly
* How about shooting an arrow?
* Start to copy : https://www.youtube.com/watch?v=WGBg4fy2Fdc
* Made a new git...
* Copied Youtube lec (~1:12:22)

### 17.04.14 FRI
Now we can shoot arrows!
* Example play scene was completed!
* Let's analyze codes
* Decided to make a normal archery game first
	- Grass ground
	- Target(for arrows)
	- Fences to mark playing area
	- White lines?
	- After that, add shooting function
	- +Tactosy Haptics(MON~WED)

### 17.04.17 MON
Archery game construction
* Study of score & counting
	- https://www.youtube.com/watch?v=cg349rLy8Ro
* Field construction -> Need some graphic sources....
* Script study needed.
* Calibration <- Big issue
* 20ms <- Maximum delay time
* Adjusting Physics
* Issue: Arrow disappears, so can't reach targe
	- Solved!

### 17.04.18 WED
Physics is difficult...
* Adjusting physics of the archery
* Real world scale -> Too HARD!
* Bought archery target model ($ 5)
	- But no set of collider OMG...
* Disposable assets were removed
* Have to think!
	- How migit I help players to see their arrow?
	- Haptics...?

