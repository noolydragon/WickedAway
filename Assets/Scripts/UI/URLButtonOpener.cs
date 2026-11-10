using UnityEngine;

public class URLButtonOpener : MonoBehaviour
{
    [SerializeField] private string websiteURL;

    public void OpenWebPage()
    {
        if (!string.IsNullOrEmpty(websiteURL))
        {
            Application.OpenURL(websiteURL);
        }
        else
        {
            Debug.LogWarning("URL is empty! Assign a link to the URL field...");
        }
    }
}
