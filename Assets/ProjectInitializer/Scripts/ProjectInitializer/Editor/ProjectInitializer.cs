using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;

public class ProjectInitializer  {

    [MenuItem("Edit/ProjectInitializer/Initialize")]
    public static void ProjectInitialize()
    {
        var appName = Application.productName;
        var appAssetsRootPath = Application.dataPath;
        var appRootPath = Directory.GetParent(appAssetsRootPath);


        CheckAndCreateDirectory(ChainPath(appAssetsRootPath, "CGINC"));
        CheckAndCreateDirectory(ChainPath(appAssetsRootPath, "Plugins"));
        CheckAndCreateDirectory(ChainPath(appAssetsRootPath, "Externals"));
        CheckAndCreateDirectory(ChainPath(appAssetsRootPath, "Models"));
        CheckAndCreateDirectory(ChainPath(appAssetsRootPath, "Texture"));
        CheckAndCreateDirectory(ChainPath(appAssetsRootPath, "StreamingAssets"));

        var appNamespaceRootPath = ChainPath(appAssetsRootPath, appName);
        var fileDirectoryPath = ChainPath(appAssetsRootPath, "File");

        CheckAndCopyFile(
            fileDirectoryPath + "/" + "gitignore",
            appRootPath       + "/" + ".gitignore"
        );

        CheckAndCreateDirectory(appNamespaceRootPath);
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Shaders"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Shaders", "Object"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Shaders", "2D"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Shaders", "UI"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Shaders", "Particle"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Shaders", "Effect"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Shaders", "Compute"));

        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Materials"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Materials", "Object"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Materials", "2D"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Materials", "UI"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Materials", "Particle"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Materials", "Effect"));

        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Scripts"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Scripts", appName));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Scripts", appName, "Editor"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Scripts", appName, "Behavior"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Scripts", appName, "Library"));

        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Scene"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Scene", "Test"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Scene", "Game"));

        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Prefabs"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Prefabs", "Resources"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Prefabs", "Object"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Prefabs", "Particle"));
        CheckAndCreateDirectory(ChainPath(appNamespaceRootPath, "Prefabs", "Etc"));

        AssetDatabase.Refresh();

        Debug.Log("Initialized");
    }

    private static void CheckAndCreateDirectory(string path)
    {
        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }else
        {
            Debug.Log(path + " is exists.");
        }
    }
    private static void CheckAndCopyFile(string srcPath, string destPath)
    {
        if (!File.Exists(destPath))
        {
            File.Copy(srcPath, destPath);
        }
    }
    private static string ChainPath(params string[] pathArray)
    {
        var ret = string.Empty;
        for(var i=0; i<pathArray.Length; i++)
        {
            if (!(i == (pathArray.Length - 1)))
            {
                ret += pathArray[i] + "/";
            }else
            {
                ret += pathArray[i];
            }
        }
        return ret;
    }

}
