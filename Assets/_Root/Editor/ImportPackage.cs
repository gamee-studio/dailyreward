using System.IO;
using UnityEditor;

public class ImportPackage
{
    private const string EXAMPLE_PACKAGE_PATH = "Assets/_Root/Packages/ExamplePackage.unitypackage";
    private const string EXAMPLE_PACKAGE_UPM_PATH = "Packages/com.gamee.dailyreward/Packages/ExamplePackage.unitypackage";

    public static void ImportExample()
    {
        string path = EXAMPLE_PACKAGE_PATH;
        if (!File.Exists(path)) path = !File.Exists(Path.GetFullPath(EXAMPLE_PACKAGE_UPM_PATH)) ? EXAMPLE_PACKAGE_PATH : EXAMPLE_PACKAGE_UPM_PATH;
        AssetDatabase.ImportPackage(path, true);
    }
}
