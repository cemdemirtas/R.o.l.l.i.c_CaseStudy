using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    private int levelNumber;

    public static SaveAndLoadManager saveAndLoadManager;
    private void Awake()
    {
        if (saveAndLoadManager == null)
        {
            saveAndLoadManager = this;
        }
    }
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }
    public void ResetGame()
    {
        PlayerPrefs.SetInt("levelNumber", 0);
        Debug.LogWarning("The game is resetted");
    }
#endif
    public void SaveGame(int levelNumber)
    {
        PlayerPrefs.SetInt("levelNumber", levelNumber);
    }

    public int GetLevelNumber()
    {
        return (PlayerPrefs.GetInt("levelNumber"));
    }
}
