using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public enum GameState { StartScreen, GamePlay, Failed, Complete,Win }

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
}
