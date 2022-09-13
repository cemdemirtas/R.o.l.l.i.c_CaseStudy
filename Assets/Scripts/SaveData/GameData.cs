using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameData
{
    private int _score = 0;
    public int _levelIndex = 0;
    public static GameData instance;
    //CarSelection carSelection=new CarSelection();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    public int Score { get => _score; set => _score = value; }
    public int LevelIndex { get => _levelIndex; set => _levelIndex = value; }

    private void OnEnable()
    {

    }
    public void IncreaseLevelIndex(int points)
    {

        _levelIndex += points;    
        
    }


    
}
