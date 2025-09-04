using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] Button RestartButton;
    [SerializeField] Button NextStageButton;



    private void OnEnable()
    {
        RestartButton.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        
    }

    public void Restart()
    {

    }

    public void NextStage()
    {

    }
}
