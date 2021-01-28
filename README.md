## Game Programming Patterns
# 01 - Command

Watch the demo - https://www.youtube.com/watch?v=a8mj3A007vk

The aim with the Game Programming Patterns project is for me to put into practice many of the patterns outlined in the Game Programming Patterns book by Robert Nystrom. I had already been using several of these patterns in other projects without knowing, however since I started reading this book I really wanted to get into these patterns and get familiar with implementing them.

**First the command pattern:** One of the examples outlined in the book is the command pattern and how it is used to creatue the undo function in most desktop applications. In these applications each action performed creates an action object which is added to some sort of stack, queue or log. This sequence of commands allows the user to skip forward and backwards in time with ease. This method is also used to record gameplay demos: Users may assume that when they watch gameplay they are watching the frame by frame data being replayed however most often only the user input is recorded and simulated in the engine as though the game is running in real time. 

For my project I have created a chess-style board and given the user two options: place and move. The user can then place or move pieces and have the sequence of moves appear on the left in a list. The user can use conventional undo and redo buttons but they can also click on a move that is displaying in the pannel. Clicking on a move in the past send the board back to that state imediately. Much like conventional undo and redo the user can undo a few times then perform a new action which clears the redo history and allows the user to continue on a different path. 



