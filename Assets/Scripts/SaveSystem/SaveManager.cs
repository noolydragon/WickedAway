using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private string m_saveFilePath;
    public GameSaveData CurrentSaveData { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            m_saveFilePath = Path.Combine(Application.persistentDataPath, "gamesave.json");
            LoadGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SaveGame()
    {
        try
        {
            CurrentSaveData.savedObjects.Clear();

            UnfreezeManager[] sceneObjects = Object.FindObjectsByType<UnfreezeManager>(FindObjectsSortMode.None);

            foreach (UnfreezeManager obj in sceneObjects)
            {
                if (string.IsNullOrEmpty(obj.objectID))
                {
                    continue;
                }
                CurrentSaveData.savedObjects.Add(obj.CaptureState());
            }
            string json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(m_saveFilePath, json);
            Debug.Log($"Game Saved Successfully to: {m_saveFilePath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to save game: {e.Message}");
        }

    }

    public void LoadGame()
    {
        if (File.Exists(m_saveFilePath))
        {
            try
            {
                string json = File.ReadAllText(m_saveFilePath);
                CurrentSaveData = JsonUtility.FromJson<GameSaveData>(json);
                UnfreezeManager[] sceneObjects = Object.FindObjectsByType<UnfreezeManager>(FindObjectsSortMode.None);

                foreach (UnfreezeManager obj in sceneObjects)
                {
                    ObjectSaveData matchedData = CurrentSaveData.savedObjects.Find(d => d.objectID == obj.objectID);
                    if (matchedData != null)
                    {
                        obj.LoadState(matchedData);
                    }
                }
                Debug.Log("Game Loaded Successfully.");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Save file corrupted or unreadable type: {e.Message}");
                CreateNewSave();
            }
        }
        else
        {
            Debug.Log("No save file found. Making new save profile");
            CreateNewSave();
        }
    }

    public void DeleteSaveFile()
    {
        if (File.Exists(m_saveFilePath))
        {
            File.Delete(m_saveFilePath);
            CreateNewSave();
        }
    }

    private void CreateNewSave()
    {
        CurrentSaveData = new GameSaveData();
    }
}
