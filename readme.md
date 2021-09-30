# Lingotown

![lingotown](https://user-images.githubusercontent.com/13554426/135513639-862590af-e5ef-465a-a9a4-46e920c25231.jpg)

## Key Features and Noteworthy Implementation details

- NPC dialogues are triggered with a sphere collider
- door switch is triggered with a ray cast
- The `AbstractAfterInteractionAction` class defines a method that can be executed after an interaction or dialogue. The actual implementation fo the action happens in an inheriting class. Therefore, different kinds of actions can be triggered after an interaction/dialogue in a composable fashion. E.g. simply by adding a small open door script.
- ScriptableObjects for the NPC dialogues in german and english
- animated dialogue
- usage of singletons for manager classes
- finite state machine-like pattern for determining the overall game state. This prevents looking and moving in the main menu and in dialogues.

## Details about Assets

### Tutorial Scene

3D models made with blender:

- Robot NPC
- computer monitor and mouse
- key
- building, doors, etc. built with unity standard objects

### Second Scene

#### House

Free Fantasy Medieval Houses and Props Pack
https://assetstore.unity.com/packages/3d/environments/fantasy/free-fantasy-medieval-houses-and-props-pack-167010


#### Ground Material

PBR Ground Free
https://assetstore.unity.com/packages/2d/textures-materials/floors/pbr-ground-free-158595


#### Female NPC (host family member)

Girl with clothes. Worker set
https://assetstore.unity.com/packages/3d/characters/humanoids/girl-with-clothes-worker-set-162925
