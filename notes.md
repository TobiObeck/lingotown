### Setup for VS Code

.vscode workspace settings exlude some files from file view

Had to install .NET SDK 4.7.1 not 4.6 (probably becasue I have the newest Unity version 2021.1.21f1 or sth instead of 2019 in the VS code docs)
for intellisense autocompletion. And C# Extension for C# erros. And referenceing `Microsoft.Unity.Analyzers.` in `omnisharp.json file` to enable Unity specific & C# warnings.

### activating git LFS, adding .gitignore and .gitattributes with good defaults

```ps
git lfs install
git lfs track "*.lolsomefunnyfile"
```


### Don't version control visual studio solution files (.sln)

From my personal experience, I noticed it is better to exclude *.csproj and *.sln from source control: Unity generates these files each time you open a project or add/delete source files anyway, so you won't miss them. You can also do it manually via "Sync MonoDevelop Project" menu item.

It is especially useful to exclude them if there is more than one developer on the project, because the auto-generated content of these files can be different for each user (that depends on Unity installation path and probably some other factors), which may cause a lot of unnecessary file changes committed to the repository.

From: https://gamedev.stackexchange.com/a/50188/91762

### configuring Unity merge tool

Not needed this time, since I am working by myself