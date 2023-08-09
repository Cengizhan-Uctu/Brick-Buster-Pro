using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private int lastCompletedLevel;
    [SerializeField] Button playBtn;
    private void Start()
    {
        playBtn.onClick.AddListener(StartBtn);

    }

    void SaveLastCompletedLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("LastCompletedLevel", levelIndex);
        PlayerPrefs.Save();
    }

    public int LoadLastCompletedLevel()
    {
        return lastCompletedLevel;
    }
    public void StartBtn()
    {
        if (PlayerPrefs.GetInt("LastCompletedLevel", 0) <= 0)
        {
            SaveLastCompletedLevel(1);
        }
        lastCompletedLevel = PlayerPrefs.GetInt("LastCompletedLevel", 0);
        SceneManager.LoadScene(lastCompletedLevel);
    }
}
