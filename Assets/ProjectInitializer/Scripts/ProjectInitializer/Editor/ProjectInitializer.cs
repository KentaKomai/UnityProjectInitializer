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
        var appRootPath = Application.dataPath;

        CheckAndCreate(ChainPath(appRootPath, "CGINC"));
        CheckAndCreate(ChainPath(appRootPath, "Plugins"));
        CheckAndCreate(ChainPath(appRootPath, "Externals"));
        CheckAndCreate(ChainPath(appRootPath, "Models"));
        CheckAndCreate(ChainPath(appRootPath, "Texture"));

        var appNamespaceRootPath = ChainPath(appRootPath, appName);
        CheckAndCreate(appNamespaceRootPath);
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Shaders"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Shaders", "Object"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Shaders", "2D"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Shaders", "UI"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Shaders", "Particle"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Shaders", "Effect"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Shaders", "Compute"));

        CheckAndCreate(ChainPath(appNamespaceRootPath, "Materials"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Materials", "Object"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Materials", "2D"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Materials", "UI"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Materials", "Particle"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Materials", "Effect"));

        CheckAndCreate(ChainPath(appNamespaceRootPath, "Scripts"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Scripts", appName));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Scripts", appName, "Editor"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Scripts", appName, "Behavior"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Scripts", appName, "Library"));

        CheckAndCreate(ChainPath(appNamespaceRootPath, "Scene"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Scene", "Test"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Scene", "Game"));

        CheckAndCreate(ChainPath(appNamespaceRootPath, "Prefabs"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Prefabs", "Resources"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Prefabs", "Object"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Prefabs", "Particle"));
        CheckAndCreate(ChainPath(appNamespaceRootPath, "Prefabs", "Etc"));

        AssetDatabase.Refresh();

        Debug.Log("Initialized");
    }

    private static void CheckAndCreate(string path)
    {
        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }else
        {
            Debug.Log(path + " is exists.");
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
