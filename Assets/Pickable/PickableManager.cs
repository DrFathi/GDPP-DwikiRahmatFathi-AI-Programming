using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;


public class PickableManager : MonoBehaviour
{
    private List<PickableScript> _pickableList = new List<PickableScript>();

    private int _coinCollected = 0;
    private int _totalCoin = 0;
    
    [SerializeField]
    public ScoreManager _scoreManager;
    [SerializeField]
    private PlayerScript _player;

    void Start()
    {
        InitCoinList();
    }
    private void InitCoinList()
    {
        PickableScript[] pickableObjects = GameObject.FindObjectsOfType<PickableScript>();
        for (int i = 0; i < pickableObjects.Length; i++)
        {
            if(pickableObjects[i].pickableType == PickableType.Coin)
                {
                    _pickableList.Add(pickableObjects[i]);
                    _totalCoin = _pickableList.Count;
                    pickableObjects[i].OnPicked += OnPickablePickedUp;
                }

            else
            {
                pickableObjects[i].OnPicked += OnPickablePickedUp;
            }
                
   
        }
        _scoreManager.SetMaxScore(_totalCoin);
        
        Debug.Log("Coins: " + _coinCollected +" / " + _totalCoin);
    }

    private void OnPickablePickedUp(PickableScript pickable)
    {

        if(pickable.pickableType == PickableType.Coin)
        {
            _pickableList.Remove(pickable);
            _coinCollected++;
            Debug.Log("Coins: " + _coinCollected + " / " + _totalCoin);

            if(_scoreManager != null)
            {
                _scoreManager.AddScore(1);
            }

            if (_pickableList.Count == 0)
            {
                SceneManager.LoadScene("WinScreen");
                Debug.Log("Win!");
            }
        }
        else if(pickable.pickableType == PickableType.PowerUp)
        {
            _player?.PickPowerUp();
        }





    }
}
