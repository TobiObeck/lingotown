# Lingotown

Lingotown is a game where you can talk to NPCs with a **bilingual dialogue system** (proof of concept).

- **Texts are shown in the target language you want to learn**
- Also, a **translation in your native language** is shown with deemphasized text.

![lingotown](https://user-images.githubusercontent.com/13554426/135513639-862590af-e5ef-465a-a9a4-46e920c25231.jpg)

You start in a training center...

![1_receptionist](https://github.com/TobiObeck/lingotown/assets/13554426/23090f06-b13e-4a86-8d4b-4b2cee082393)

...and can play different simulated training scenarios for practicing real-life interactions in common situations. (currently only 1 scenario is implemented)

![4_tech_guy](https://github.com/TobiObeck/lingotown/assets/13554426/f4322426-491f-403d-bdcc-b52ed24c6a3f)

Start the first scenario:

![5_computer](https://github.com/TobiObeck/lingotown/assets/13554426/a305d549-dcba-4c2d-acff-96f70196ab9f)

You are **IN** the virtual scenario accomplishing a simple fetch quest:

![6_mother](https://github.com/TobiObeck/lingotown/assets/13554426/60ee4db5-f25a-4194-916b-0eaf992b7d60)

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
