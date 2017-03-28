# SaveTheFire

Save the Fire is a 3D game that requires an 8 projector setup to display the virtual environment to its users. <br />
The players are surrounded by projections on each side and also top projector animating fire on pit situated in <br />
the middle. Save the Fire is basically a Multitasking task Game, in which two players have to simultaneously collaborate <br />
with each others and have to  kill all the enemies who are appearing randomly from different positions and  throwing <br />
snowballs. Furthermore the other tasks of players includes find appropriate items (Wood,Coal etc) from the scene and <br />
drag and drop these founded items into the fire pit in order to keep the fire alive.  <br />


Overall Program Structure <br />
<br />
Each object in the scene has a collider. This is done because the vive controllers are using raycasting. <br />
Essentially there is a ray casted at every frame since the user needs to be able to shoot at each object. <br />
Objects in the background that don’t do much are tagged as “normal objects” and the script NormalObjBeh is <br />
applied to them. All this script does is allow for a ray to be casted onto it. Once the show ball collides with <br />
the normal object the user aimed at, the showball is removed from the scene. Objects that can be picked up have <br />
an “ItemBeh” script applied to them. This allows the the main script to distinguish between background objects <br />
and an item the user can interact with (the script itself has no actions). <br />

How pointing and shooting works: The Vive controllers are placed into the scene much like all other objects. A <br />
spotlight is attached as a child object, the orientation and rotation are all set to default values (important so <br />
the spotlight points the right way). The parenting is how the users are able to navigate the scene with the spotlight, <br />
naturally the child objects have the same location and orientation as the parent object. When the users presses the <br />
trigger a  controller.TriggerClicked event is fired. Inside this method we instantiate a showball, set it to the same <br />
position as the Vive controller and fire it towards the hit point (where the raycast hit a collider). As explained above <br />
the snowball is destroyed once it hits an object or an item. <br />


How to install and run project <br />
Clone the project using a git terminal or simply click "download zip file". <br />
Once download finished extact files from directory <br />
Locate Assets > Scenes > Raycast.unity <br />
Open Raycast.unity <br />
To run the game with the 8 - projector setup click on File > Build and Run <br />
The game can also be ran by clicking on the play button (this will run it in degub mode), no projector will be activated <br />

Software Requirements <br />
Save the Fire! is a Unity Project, required version to run 5.5.1 <br />
SteamVR Plugin 1.2.0 <br />
Note: it may work with newer versions, however some differences in software behaviour may occur
