# Mofo

This project is the engineering part of the [first lesson of the HoloKit tutorial](https://docs.holokit.io/for-creators/tutorials-and-case-studies/tutorial-1-use-hand-tracking-for-interacting-with-holograms). It covers topics such as how to use HoloKit stereo rendering, how to place AR objects, and interact with them.

## What is Mofo

After building this project as an iPhone app, tap on screen to place a particle-style Buddha on any surface.

![Example Image](https://github.com/holoi/mofo/blob/main/Assets/Documents/Images/stereo-rendering-mode.jpeg)


Utilizing the hand-tracking feature from the HoloKit SDK, this enables players to interact with the Buddha using their hands.

<video>
    <source src="https://youtu.be/spD09_W6lPg" type="video/mp4">
</video>



Additionally, the app offers stereo rendering options for an enhanced mixed reality experience using HoloKit hardware.

<video width="320" height="240" controls>
    <source src="movie.mp4" type="video/mp4">
</video>

## About HoloKit Tutorial

### Introduction

The HoloKit tutorial aims to provide a series of engaging and hands-on courses, gradually exploring the AR development process and related technologies on the Unity platform. It also guides users on how to utilize the HoloKit SDK effectively.

### Link

https://app.gitbook.com/o/mR4uhYDvPFKgusOgXgy0/s/GgGuLHKzjNAAsbVXzyoG/for-creators/tutorials-and-case-studies/tutorial-1-use-hand-tracking-for-interacting-with-holograms

## Requirements

This project utilizes the HoloKit SDK and aims to build an app that runs on iOS devices.

1. Unity 2022.3.8f1
2. Xcode 14.2
3. iPhone with Lidar capability

## How to try it

### Build App to your device

1. Clone the project, open with Unity
2. Open scene in path: Assets->Scene->Buddha_PlacingWithTouch
3. Build to an Xcode project, go to: File -> Build Settings -> Build, to build this scene to an Xcode project
4. Open Xcode, then open the project
5. Click build button to build app to your device

### Play

1. Open the app, scan on a flat surface(floor)
2. Tap on screen to create a Buddha
3. Get close and use hand to interact with Buddha
4. Click on “Stereo” button to switch rendering mode

## Change Log
