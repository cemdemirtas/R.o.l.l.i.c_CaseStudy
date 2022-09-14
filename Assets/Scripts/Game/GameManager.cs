using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas canvas;
    GameData saveData = new GameData();

    public enum GameState { StartScreen, GamePlay, Failed, Complete, Win }

    public static Action OnLevelCompleted;
    public static Action OnLevelStarted;
    public static Action OnLevelRestart;
    public static Action OnLevelNext;
    public static Action OnContinueLevel;

    [SerializeField] public static GameState gameState;

    private void OnEnable()
    {
        OnLevelStarted += StartLevel;
        OnLevelNext += NextLevel;
        OnLevelCompleted += CompleteLevel;
        OnContinueLevel += ContinueLevel;
        OnLevelRestart += FailedLevel;
        saveData = SaveSystem.instance.LoadGame();
        //SceneManager.LoadScene(saveData.LevelIndex);



        Debug.Log("LEVEL START"+ saveData._levelIndex);
    }
    public void gamestartbutton()
    {
        SceneManager.LoadScene(saveData.LevelIndex);

    }
    private void Awake()
    {

        //SceneManager.LoadScene(asynSceneIndex);
        //DontDestroyOnLoad(this);
        //DontDestroyOnLoad(canvas);
        //asynSceneIndex = SaveAndLoadManager.saveAndLoadManager.GetLevelNumber();
    }
    void Update()
    {

    }

    private void OnDisable()
    {

        OnLevelStarted -= StartLevel;
        OnLevelCompleted -= CompleteLevel;
        OnContinueLevel -= ContinueLevel;
        OnLevelRestart -= FailedLevel;
        OnLevelNext -= NextLevel;

    }

    private void StartLevel()
    {

        gameState = GameState.GamePlay;


    }

    private void FailedLevel()
    {
        gameState = GameState.Failed;
    }

    private void NextLevel()
    {
        gameState = GameState.Win;
    }


    private void ContinueLevel()
    {
        gameState = GameState.GamePlay;

    }
    private void CompleteLevel()
    {
        gameState = GameState.Complete;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(saveData._levelIndex);
    }
    public void NextLevelButton() //When the game finished, we get loop each levels to infinity
    {
        saveData._levelIndex += 1;


        if (saveData._levelIndex > 3)
        {
            saveData._levelIndex = 0;
        }

        SaveSystem.instance.SaveGame(saveData);

        SceneManager.LoadScene(saveData._levelIndex, LoadSceneMode.Single);

        Debug.Log("INCREASED LEVEL:" + saveData._levelIndex);
        gameState = GameState.StartScreen;
    }


}
