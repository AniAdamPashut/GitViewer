GitViewer 
===
`I don't wanna push just to see if my `.vs` folder was removed by the gitignore.`

Todo
===
- Change the json format (it doesn't look good)

Definitions
===
A program that looks into different staging of git and let you view your files in each state

-  Just use the git CLI for it
-  Learn git
-  Track files using git filters
-  For now support only latest commit with no difference between staging

Relevant Git Commands
===
1. `git ls-tree -r --name-only <COMMIT-HEAD>` - Shows all files in a specific commit 
2. `git log --pretty="%h~%cn~%ch~%cI~%s"` - Shows commit in a cool parse-able format
