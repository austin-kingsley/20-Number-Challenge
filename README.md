# 20 Number Challenge
The 20 Number Challenge, created and popularised by Nick Vogel [1], is a single-player game in which the objective is to fill up a board of 20 spaces with numbers 1 to 999 in ascending order.

The game starts with an empty grid of 20 spaces. On each turn, the player must randomly generate a number 1 to 999 and select the position that they think is most appropriate for the newly generated number. This is repeated until all positions on the board are filled, or there is a clash with previously places numbers.

# An Example
Consider an empty grid.

If we generate the random number 500, a rational player would place it on position 10.

Say the next number we generate is 999, we should place it in position 20.

The next number is 12? Then we place it at 1.

If the next number is 510 we should probably put it at position 11.

But then if the following number is 505, the game is over and we lose.

# This Project
This project demonstrates the inherent unlikelihood of a successful game by allowing one to simulate millions of runs (using an optimal assignment algorithm) of the game in just a few seconds. It is shown that it would take, in expectation, around 18,000 games for 1 success.

Upon sharing our findings with Nick, who is currently on day 99 of attempting the challenge every day, it was great to see that he was not demoralised by the fact that he most likely won't live long enough to see the day he beats the game.


#
[1] https://www.tiktok.com/@_nickvogel
