using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public float score = 0f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public void AddScore(float _amount)
    {
        score += _amount;
    }
}
