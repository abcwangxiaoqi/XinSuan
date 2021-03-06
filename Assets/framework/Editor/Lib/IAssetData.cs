﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
public interface IAssetData
{
    T Load<T>() where T : Object;
    Object Load();
    void Import();
    void CreatAsset(Object obj);
    string[] GetDependencies();
    string path { get; }
    void ImportAsset();
    void WriteImportSettingsIfDirty();
    void ImportAsset(ImportAssetOptions Options);
    void AddObjectToAsset(Object obj);
    void DeleteAsset();
}
#endif