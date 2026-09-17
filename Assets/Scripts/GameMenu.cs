using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Credits()
    {
        GameObject creditsPanel = GameObject.Find("CreditsPanel");
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("CreditsPanel not found in the scene.");
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
