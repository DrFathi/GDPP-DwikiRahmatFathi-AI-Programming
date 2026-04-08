using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem.Controls;


public class PickableManager : MonoBehaviour
{
    private List<PickableScript> _coinList = new List<PickableScript>();

    private int _coinCollected = 0;
    private int _totalCoin = 0;

    void Start()
    {
        InitPickableList();
    }
    private void InitPickableList()
    {
        PickableScript[] pickableObjects = GameObject.FindObjectsOfType<PickableScript>();
        for (int i = 0; i < pickableObjects.Length; i++)
        {
            if(pickableObjects[i].pickableType == PickableType.Coin)
            {
                _coinList.Add(pickableObjects[i]);
                pickableObjects[i].OnPicked += OnPickablePickedUp;
            }
            

        }
        _totalCoin = _coinList.Count;
        Debug.Log("Coins: " + _coinCollected +" / " + _totalCoin);
    }

    private void OnPickablePickedUp(PickableScript pickable)
    {

        //Debug.Log("You Picked up : " + _pickableList);


        _coinList.Remove(pickable);
        _coinCollected++;
        Debug.Log("Coins: " + _coinCollected + " / " + _totalCoin);

        if (_coinList.Count == 0)
        {
            Debug.Log("Win!");
        }
    }
}
