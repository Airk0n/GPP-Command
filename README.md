## Game Programming Patterns
# 01 - Command

The aim with the Game Programming Patterns project is for me to put into practice many of the patterns outlined in the Game Programming Patterns book by Robert Nystrom. I had already been using several of these patterns in other projects without knowing, however since I started reading this book I really wanted to get into these patterns and get familiar with implementing them.

**First the command pattern:** one of the examples outlined in the book is the undo function in most desktop applications. In these applications each action performed creates an action object which is added to some sort of stack, queue or log. This sequence of commands allows the user to skip forward and backwards in time with ease. This method is also used for recorded demos of gameplay where instead of every frame of data being captured, only the user input is recorded and played back in sequence to emulate real gameplay.

For my project I want to create a chess style board that allows you to place and move a piece. To keep this project brief I am looking at creating a single piece that can be moved, each action is recorded in sequence and can then the user can step forward and backwards.

