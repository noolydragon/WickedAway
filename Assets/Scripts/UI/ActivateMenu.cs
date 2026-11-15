using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(gameSceneName);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
