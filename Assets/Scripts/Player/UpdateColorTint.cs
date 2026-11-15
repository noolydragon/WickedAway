using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public enum GameScene
    {
        MainMenu = 0,
        PuzzlesScene = 1
    }

public class UpdateColorTint : MonoBehaviour
{
    public Material colorTintMaterial;
    
    //Pass the scale in so it flickers with the light
    public GameScene scene;

    // Update is called once per frame
    void Update()
    {
        if (colorTintMaterial == null) return;
        if (Mouse.current == null) return;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == (int)GameScene.PuzzlesScene)
        {
            colorTintMaterial.SetVector("_SpherePosition", transform.position);
        }
        else if (currentSceneIndex == (int)GameScene.MainMenu)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();

            
            colorTintMaterial.SetVector("_SpherePosition", screenPos);

            /*
            Vector2 normalizedPos = new Vector2(screenPos.x / Screen.width, screenPos.y / Screen.height);
            colorTintMaterial.SetVector("_SpherePosition", normalizedPos);
            */
        }
    }
}
