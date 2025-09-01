using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    private int currentCoin;
    // 코인이 변경되엇을때만 실행되도록
    private void OnEnable()
    {
        Bus<IGetCoin>.OnEvent += HandleGetCoin;
    }

    private void OnDisable()
    {
        Bus<IGetCoin>.OnEvent -= HandleGetCoin;
    }
    private void Start()
    {
        currentCoin = 0;        // 
        Bus<IGetCoin>.Raise(new IGetCoin(0));
    }

    private void HandleGetCoin(IGetCoin evt)
    {
        currentCoin += evt.Value;
        coinText.SetText($"Current Coin : {currentCoin}");
    }
}