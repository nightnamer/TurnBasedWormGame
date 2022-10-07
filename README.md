# 3D Worms-like

## Controls
### Menus
Navigate menus using <kbd>Mouse</kbd> and <kbd>Keyboard</kbd>.

### Game
Left click to charge, release to shoot. 1 and 2 to swap weapons.

#### Movement mode
Whilst in *movement mode*, use <kbd>W</kbd><kbd>A</kbd><kbd>S</kbd><kbd>D</kbd> and <kbd>Space</kbd> to move and jump.  

## Features
This was my first time using unity and coding with c#. It has been very educational but also very very messy. I do really look forward to inproving my code as I move forward and reach my own standards.

### General
- [x] (G) Only play scene is required
- [x] (VG, small) Add main menu (start) scene and game over scene
- [ ] (VG, medium) Implement Pause menu and settings menu 

I made a menu start scene and a victory screen but not a scene. The menu uses simple buttons.

### Turn based game
- [x] (G) You can have two players using the same input device taking turns.
- [x] (VG, large) Support up to 4 players (using the same input device taking turns)
- [ ] (VG, large) Implement a simple AI opponent.

I support 2-4 players through my spawnManager

### Terrain
- [x] (G) Basic Unity terrain or primitives will suffice for a level
- [ ] (VG, large) Destructible terrain (You can use Unity's built in terrain or your own custom solution)

I used the terrain unity provides for us and the brushes within it. I also downloaded assets for houses and such.

### Player
- [x] (G) A player only controls one worm
- [x] (G) Use the built in Character Controller. Add jumping.
- [x] (G) Has hit points
- [x] (VG, small) Implement a custom character controller to control the movement of the worm.
- [x] (VG, small) A worm can only move a certain range 
- [ ] (VG, medium) A player controls a team of (multiple worms)

I used an input handler to handle the inputs that sends them to the players while I  have a player controller handling the movement. 

### Camera
- [x] (G) Focus camera on active player
- [x] (VG, small) Camera movement

I use cinemachine, with a variety of scripts each serving unique purposes

### Weapon system
- [x] (G) Minimum of two different weapons/attacks, can be of similar functionality, can be bound to an individual button, like weapon 1 is left mouse button and weapon 2 is right mouse button
- [ ] (VG, small) a weapon can have ammo and needs to reload
- [ ] (VG, medium) The two types of weapons/attacks must function differently, I.E a pistol and a hand grenade. The player can switch between the different weapons and 
