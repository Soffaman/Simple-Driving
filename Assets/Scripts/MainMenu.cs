using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _energyText;

    [SerializeField] private AndroidNotificationHandler _androidNotificationHandler;
    [SerializeField] private IOSNotificationHandler _iOSNotificationHandler;

    [SerializeField] private int _maxEnergy;
    [SerializeField] private int _energyRechargeDuration;

    private int _energy;

    private const string _energyKey = "Energy";
    private const string _energyRedyKey = "EnergyReady";

    

    private void Start()
    {
        int highScore  = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        _highScoreText.text = $"HighScore: {highScore}";

        _energy = PlayerPrefs.GetInt(_energyKey, _maxEnergy);

        if(_energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(_energyRedyKey, string.Empty);

            if(energyReadyString == string.Empty)
            {
                return;
            }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if(DateTime.Now > energyReady)
            {
                _energy = _maxEnergy;
                PlayerPrefs.SetInt(_energyKey, _energy);
            }
        }

        _energyText.text = $"Play({_energy})";
    }

    public void Play()
    {
        if(_energy < 1)
        {
            return;
        }

        _energy--;
        PlayerPrefs.SetInt(_energyKey, _energy);

        if (_energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(_energyRechargeDuration);
            PlayerPrefs.SetString(_energyRedyKey, energyReady.ToString());

#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReady);

#elif UNITY_IOS
            _iOSNotificationHandler.ScheduleNotification(_energyRechargeDuration);
#endif 
        }

        SceneManager.LoadScene(1);

    }
}
