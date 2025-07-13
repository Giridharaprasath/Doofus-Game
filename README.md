# Doofus Game

A Simple 3D Platform Game, where the Player has to stay on top of the Platform and Score as much as possible.

The Platform which is called Pulpit, gets randomly spawned on any side of the existing Pulpit.
Each Pulpit will have a timer running which indicated the life span of that Pulpit.
When it reached 0, the Pulpit will fall down.
If the Player is on top of it, the player will fall to the death and the game is over.

The Player has to keep moving to make sure that the cube stays on top of the Pulpit and not fall to the death. Each new Pulpit the Player reached the Score count increases.

## Game

- **[Download Latest Release](https://github.com/Giridharaprasath/WordJam/releases).**
- Download From itch.io **[Doofus Game Link](https://giridharaprasath.itch.io/doofus-game)**
  
## Gallery

- Main Menu

![image](https://user-images.githubusercontent.com/83279100/189513616-149ce4ae-bfab-419f-a194-007b92ce2cb6.png)

- Game Scene

![image](https://user-images.githubusercontent.com/83279100/189513639-b135c83e-c530-4450-9cda-e23f70650751.png)

- Pause Menu

![image](https://user-images.githubusercontent.com/83279100/189513643-1183a96c-4763-49b9-b078-02eec51bfd06.png)

- Game Over Menu

![image](https://user-images.githubusercontent.com/83279100/189513646-93a1d165-0254-4f19-beb7-698a542a9df4.png)

- Game Play Video

[<img src="https://user-images.githubusercontent.com/83279100/189513616-149ce4ae-bfab-419f-a194-007b92ce2cb6.png" width="50%">](https://youtu.be/K_JtiR0kT_A "View Video on Youtube")

## Edge Conditions

- The Player Speed and The Pulpit Data are retrieved from a JSON File stored in a web server.
- The new Pulpit will not spawn on the last pulpit location.
- The Pulpit have a random life span Ranging between two numbers given in the JSON File.
- The Pulpit will also fall down when the timer reaches 0.
- At a given time only 2 Pulpit will only be present and new Pulpit will spawn the the old Pulpit's timer reached 2.5 seconds.
- The Player moves at the speed which is given in the JSON File.
