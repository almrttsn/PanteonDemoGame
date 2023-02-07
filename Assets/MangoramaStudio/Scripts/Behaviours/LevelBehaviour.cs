using MangoramaStudio.Scripts.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBehaviour : MonoBehaviour
{
    public float WinPanelDelayTime => _winPanelDelayTime;
    public float LosePanelDelayTime => _losePanelDelayTime;

    [SerializeField] private float _winPanelDelayTime;
    [SerializeField] private float _losePanelDelayTime;
    [SerializeField] private Text _moneyTextPanel;

    private GameManager _gameManager;

    private bool _isLevelEnded;

    public void Initialize(GameManager gameManager, bool isRestart = false)
    {
        _gameManager = gameManager;

        if (!isRestart)
        {
            _gameManager.EventManager.StartLevel();
        }
    }

    private void Start()
    {
        PlayerData.PlayerMoney = 1000;
        _moneyTextPanel.text = "Your money is: " + PlayerData.PlayerMoney.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            LevelCompleted();
        }

        if (Input.GetKeyDown("f"))
        {
            LevelFailed();
        }
        _moneyTextPanel.text = "Your money is: " + PlayerData.PlayerMoney.ToString();
    }

    private void OnDestroy()
    {
        
    }

    private void LevelCompleted()
    {
        if (_isLevelEnded) return;

        _gameManager.EventManager.LevelCompleted();
        InputController.IsInputDeactivated = true;
        _isLevelEnded = true;
    }

    private void LevelFailed()
    {
        if (_isLevelEnded) return;

        _gameManager.EventManager.LevelFailed();
        InputController.IsInputDeactivated = true;
        _isLevelEnded = true;
    }
}
