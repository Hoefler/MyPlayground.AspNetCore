REM ####################################################################################################
REM If you enter "git difftool" on command line, 
REM then TortoiseGitMerge.exe will be displayed for each file. 
REM IMPORTANT: The script works only if you have TortoiseGit in your enviorment variables (path)
REM ####################################################################################################

git config --global diff.tool diffmerge
git config --global difftool.diffmerge.cmd "\"TortoiseGitMerge.exe\" -base:\"$BASE\" -theirs:\"$LOCAL\" -mine:\"$REMOTE\" -merged:\"$MERGED\""