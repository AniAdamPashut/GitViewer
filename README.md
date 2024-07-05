# GitViewer 
Rational: I don't wanna push just to see if my `.vs` folder was removed by the gitignore.


Definitions
===
A program that looks into different staging of git and let you view your files in each state

-  Just use the git CLI for it
-  Learn git
-  Track files using git filters
-  For now support only latest commit with no difference between staging

Relevant Git Commands
===
1. `git ls-files` - Get all files tracked in a directory
2. `git checkout <COMMIT-HASH>` - Allows inspecting different commits
3. `git reflog show --pretty="%h~%cn~%ch~%cI~%s"` - Shows commit in a cool parse-able format
