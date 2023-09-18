using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _highScoreText;

    private void Start()
    {
        int highScore  = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        _highScoreText.text = $"HighScore: {highScore}";
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
