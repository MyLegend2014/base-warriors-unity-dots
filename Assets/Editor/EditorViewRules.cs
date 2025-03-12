public class EditorViewRules
{
    [VFolders.Rule]
    static void FoldersColorRules(VFolders.Folder folder)
    {
        if (folder.name == "Scripts")
            folder.color = 1;
        
        if (folder.name == "Game")
            folder.color = 2;
        
        if (folder.name == "Modules")
            folder.color = 5;
        
        if (folder.name == "Tests")
            folder.color = 8;
    }
}