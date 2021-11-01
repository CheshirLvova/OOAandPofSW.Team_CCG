# TⓤO EMIT
TⓤO EMIT is a click-and-point game where you need get out of the maze full of puzzles in the shortest possible time. Check your ranking in the standings, get prizes, discover new levels, and don't forget about time.

## Functional Requirements 

The application should have:
*	Possibility to register an account
*	Possibility to save game progress
*	Possibility to continue previous game
*	User personal statistics (account details, achievements system)
*	Global leaderboard
*	User-friendly interface

## Identity Management

Users can create an account with the login information stored in Identity or they can use an external login provider. Supported external login providers include Facebook or Google.

**Types of roles**: Guest, User, Admin.

| Role       | Description                                                    |        
| ---------- | -------------------------------------------------------------- |
| Guest      |  User that have not authenticated yet. <ul><li>Can sign in/sign up;</li><li>Can just view global leaderboard.</li></ul>  |
| User       |  User that have already authenticated. <ul><li>Can view statistics (time played, scores and ect);</li><li>Can be displayed on leaderboard;</li><li>Can play the game;</li><li>Can reset the progress;</li><li>Can add report that someone cheating;</li><li>Can sent request to delete account;</li><li>Can edit user info;</li><li>Can change password;</li><li>Can sign out.</li></ul> |
| Admin      |  Superuser that have already authenticated. <ul><li>Can block/unblock users;</li><li> Can see users reports;</li><li>Can reset users statistics;</li><li>Can delete accounts.</li></ul> |

## UML diagrams
**Account management system usecase diagram:**

![Account management system usecase diagram](./src/Account_usecase.png)

**Game management system usecase diagram:**

![Game management system usecase diagram](./src/Game_managements_usecase.png)
