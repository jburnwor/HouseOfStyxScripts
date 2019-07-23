# HouseOfStyxScripts

House of Styx is a dark surrealist, violent action game following George as he delves deep into his mind to fight and overcome his traumatic past.

Game Website: https://houseofstyx.ucraft.net/
Game Trailer: https://www.youtube.com/watch?v=ujdBcqK5wEQ

This is a collection of the scripts from the game since our team used Unity Collab.

I mainly worked on the AI for the game. It is based off of the unity tutorial for plugable AI using a finite state machine. https://www.youtube.com/watch?v=cHUXh5biQMg&list=PLX2vGYjWbI0ROSj_B0_eir_VkHrEkd4pi

The main starting place to look at the AI would be the state controller script in the AI folder. The actions, decisions, and states are extended from the base classes and each of the enemy type specific scripts are in the grunt, screamer, or boss folders within the AI folder. Something else to know is that the grunts heavily use the gamemanager script in scripts/scene/ folder to time attacks and keep the correct distance from the player.

If I refactor or could create the AI again I would create seperate state controllers for every enemy type to avoid redundant or unused code that is enemy type specific being used by every enemy.
