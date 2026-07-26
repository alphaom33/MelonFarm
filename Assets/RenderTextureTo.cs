using UnityEngine;
using System.IO;

public class RenderTextureTo : MonoBehaviour
{
    public RenderTexture renderTexture;
    public string fileName = "SavedRenderTexture";

    [ContextMenu("Export to PNG")]
    public void ExportPNG()
    {
        if (renderTexture == null)
        {
            Debug.LogError("Please assign a RenderTexture first!");
            return;
        }

        // 1. Save the currently active render texture to restore it later
        RenderTexture previousActive = RenderTexture.active;

        // 2. Set your source RenderTexture as the active target for the GPU
        RenderTexture.active = renderTexture;

        // 3. Create a new Texture2D matching the dimensions
        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);

        // 4. Read the active RenderTexture pixels into the Texture2D
        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();

        // 5. Restore the previous active render texture
        RenderTexture.active = previousActive;

        // 6. Encode the Texture2D data into a PNG byte array
        byte[] bytes = tex.EncodeToPNG();

        // 7. Clean up the temporary Texture2D to prevent memory leaks
        DestroyImmediate(tex);

        // 8. Define your file path and save the file to disk
        string filePath = Path.Combine(Application.dataPath, fileName + ".png");
        File.WriteAllBytes(filePath, bytes);

        Debug.Log($"PNG successfully saved to: {filePath}");

#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}