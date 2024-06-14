Gem Hunter program is a console-based 2D game where players compete to collect the most gems within a set number of turns. This game contains a 6*6 square board,2 players (P1, P2), obstacle(O), and gems(G). P1 is placed at the top left of the board and P2 is placed at the bottom right of the board. The gems and obstacles will be placed randomly on the board. The players can move in four directions on the board Left(L), Right(R), Up(U), Down(D). The player's position will be updated to a new position based on the movement. If the player faces any obstacles, the player will remain in the same position. The game continues till 30 turns. The winner will be announced based on individual player gem collection. If both players have the same gems, then the game will be on tie.
The Gem Hunter game is structured using classes, constructors, and methods. The position class represents the X, and Y coordinators of the board and is initialized through the constructor. The player class represents the players in the game and contains properties such as the player’s name, player’s position, and gem count. The position class also contains the ‘Move’ method to update the player’s position based on the movement.
The Cell class represents the individual cells on the game board and its occupant. The Board class represents the 6*6 board and has its constructor to initialize the initial position of cell occupants. The method ‘Initialize Board’ defines the random position of gems and obstacles. The ‘Display’ method print the board to console and ’IsValidMove’ method check the movement of player is valid or not. The method ‘IsMove’ validates the player's movements and updates the player's position on the board. The Game class controls the overall game and the method ‘start’ starts the game and handles the functions IsGameOver ,IsMove, SwitchTurn. Lastly main program consists of the main method which acts as the starting point of game and the game continue to work until 30 turns.