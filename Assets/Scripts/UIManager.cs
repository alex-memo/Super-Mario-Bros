using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text timerText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    public void UpdateScore(int _score)
    {
        scoreText.text = "Score: " + _score;
    }
    public void UpdateTimer(int _time)
    {
        if (_time < 0)
        {
            _time = 0;
        }
        timerText.text = "" + _time;
    }
}
