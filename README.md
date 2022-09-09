# BlockPush

This repository contains a one week programming assignment hosted by GainPlay Studios. The task was to create a block pushing game in which the player (a sphere) must complete levels by interacting with various types of blocks. For a full detailed description of the project, see the RequirementsDocumentation.pdf file. This readme will contain any deviations and creative decisions that were made outside of the requirement document and aren't immediately obvious by playing the game.

## Level Creation

The biggest area of interpretation lay in the way that the game was structured. It was unclear if the game should contain a single hand crafted level, a single randomly generated level or multiple levels.

My interpretation of the game has 10 levels that were created using a custom import script. Each level contains an array of "Tile Maps" that are stitched together from end to end to create a complete level. These Tile Maps are created using a graphical editor such as Photoshop or Gimp. Pixels are drawn on a N x M canvas using a labeled color pallet. Each pixel color corresponds to a prefab object in Unity.

The chunk generation script first generates a ground plane equal in size to the N x M size of the imported image. It then iterates through the non-transparent pixels to see if they correspond to a prefab. If they do, the prefab is Instantiated and it's position is set by converting the coordinates from image space into Unity world space. Technically it uses an offset relative to the bottom left corner of the current chunk.

This process is repeated for each Tile Map in the array of Tile Maps for that level. In this way, levels can easily be constructed with an arbitrary length and Tile Maps can be easily reused between levels.

The current limitations of this system are two-fold. First, it doesn't support object stacking, which prevents more than one layer of vertically in the level. This could be fixed by adding another dimension to the Tile Map array. An element in the sub array would correspond to a different layer on the Y-axis. This way, 3D levels could be created by stacking 2D slices on top of each other.

The second limitation is the lack of support for multi-pixel objects. Each pixel is currently read individually and doesn't combine with neighboring pixels. It would be easy to use opacity to indicate that an object is a multi-pixel structure and scale the X and Y dimensions of the prefab to match the image. This hasn't been implemented yet because it wasn't a huge problem and it was better of focus on other tasks.

## Time Limit System

The requirements stated that the game should get harder over time, but didn't specify what mechanism would be used to enforce difficulty. In my implementation, the game gets harder in two ways. In the normal campaign each level is more complicated than the last. The first few levels get the player familiar with the properties of the objects before putting them together in later levels. In the future the levels can be expanded upon by designers since the first 10 levels are quite basic and only serve as a demonstration of the features in the game.

A laser was also added that constantly chases the player. It destroys any objects that it interacts with, including the player if they touch it. Speed pads were also added that increase the speed of the laser when they are touched. This forces the player to move faster to prevent getting destroyed by the laser. Speed pads weren't added to the normal levels to give the player time to solve puzzles of increasing difficulty.

## Endless Mode

With the current level generation structure it would be very easy to create an endless mode. The game could randomly sample all the available Tile Maps and generate a new chunk when the player is a few chunks away from it. By maintaining at least one chunk behind the player and two chunks in front of the player, the experience would appear smooth to the player. Destroying chunks that are behind the player and only instantiating new chunks when they are needed prevents an excess of memory from being used.

## Included Features

This section contains an enumeration of the key features included. Most of these were created as a direct answer to the specifications in the requirements documentation, but some were added to make the game more pleasant to play.

- [x] Positive block that move when a player pushes them
- [x] Fixed blocks that cannot be moved\*
- [x] Neutral blocks that can only be moved by pushing a positive block into them\*
- [x] Hazard blocks that destroy the player on contact\*
- [x] Level selection menu to choose a level
- [x] Level gating which forced previous levels to be completed before proceeding
- [x] Point pickups with a point tracking display in the top left.
- [x] Powerups that allow the player to move any block
- [x] Powerup tracking. The color of the blocks LERP from the player's colour back to their own when a powerup is picked up. This allows the player to see how long is left on their power without looking at the display text.
- [x] Player controller. An animation curve was used to enforce a maximum speed and improve player handling
- [x] The time limit isn't enforced using a traditional visible timer. The laser serves as a visual reminder to the player which is more tangible than a text based timer. It serves the same purpose of enforcing a time limit
- [x] Way more than 30 seconds of content
- [x] Game Controller that can pause the game with the escape key
- [x] Detection for hazards, falling off the world and achieving the goal that trigger end of game menus. These menus allow the player to return to the main menu or restart the level
- [x] Sound effects for powerups, destruction, level won, etc.
- [x] Sound control in the pause menu that allows the player to mute or lower their master volume. In the future this could be separated into different sliders for sound effects and music.
- [x] JSON data export in the requested format. The file is saved to the Unity asset folder for now.

* All blocks can be moved when a powerup is used.

## Future Plans

See the Github issues tagged with "Future Work" for future plans. There are many ways to improve the look and feel of the game if more time were invested.

A special thanks to everyone at GainPlay involved with this assignment. I had fun building this project and look forward to continuing my work with Unity in the future. This project took roughly 15-20 hours to complete. I completed most of the main features on the first day and then slowly worked on enhancements and minor issues over the next few days.
