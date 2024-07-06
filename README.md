GitViewer 
===
`I don't wanna push just to see if my `.vs` folder was removed by the gitignore.`

Todo
===
- Change the json format (it doesn't look good)
- The commit format is kinda konky. it works it isn't that good
- UI

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
2. `git log --pretty="%h~%cn~%ch~%s~%cI"~%D##` - Shows commit in a cool parse-able format
