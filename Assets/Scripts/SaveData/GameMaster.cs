using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour
{
    public Text Scoretxt;
    public static UnityAction<int> PointEvent;

    GameData saveData = new GameData();

    void Update()
    {
        //Scoretxt.text = saveData.Score.ToString();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            saveData.IncreaseLevelIndex(1);
            PrintScore();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            saveData.IncreaseLevelIndex(-1);
            PrintScore();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveSystem.instance.SaveGame(saveData);
            Debug.Log("Saved data.");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            saveData = SaveSystem.instance.LoadGame();
            Debug.Log("Loaded data.");
            PrintScore();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //saveData.ResetData();
            PrintScore();
        }
    }

    void PrintScore()
    {
        Debug.Log("The current score is " + saveData.Score);
    }
}
