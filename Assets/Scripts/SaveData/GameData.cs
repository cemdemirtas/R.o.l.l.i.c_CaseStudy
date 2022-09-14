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
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    public int Score { get => _score; set => _score = value; }
    public int LevelIndex { get => _levelIndex; set => _levelIndex = value; }


    
}
