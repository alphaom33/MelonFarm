using System.Collections;
using System.IO;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

[CustomEditor(typeof(IconScript))]
public class Icon : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IconScript script = (IconScript)target;
        if (script.prefab != null)
        {
            Texture2D texture = AssetPreview.GetAssetPreview(script.prefab);
            if (texture != null)
            {
                GUILayout.Label("Prefab Preview:");
                GUILayout.Box(texture);

                Sprite sprite = Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f)
                );

                if (GUILayout.Button("Yep"))
                {
                    byte[] bytes = texture.EncodeToPNG();

                    // Define your path inside the project
                    string localPath = "Assets/Resources/Seeds/Icons/" + script.prefab.name + ".png";

                    // Write the file to disk
                    File.WriteAllBytes("Assets/Resources/Seeds/Icons/" + script.prefab.name + ".png", bytes);

                    // Refresh the AssetDatabase so Unity spots the new file
                    AssetDatabase.Refresh();

                    // Configure the newly created file as a Sprite
                    TextureImporter importer = AssetImporter.GetAtPath(localPath) as TextureImporter;
                    if (importer != null)
                    {
                        importer.textureType = TextureImporterType.Sprite;
                        importer.SaveAndReimport();
                    } 
                    else
                    {
                        Debug.Log("sad");
                    }
                }
            }
        }

    }
}
    