using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEventUI : MonoBehaviour
{
    [Header("NPC UI")]
    public GameObject NPCPanel;
    public Image NPCSprite;
    public TextMeshProUGUI NPCName;
    public TextMeshProUGUI NPCDialogue;

    [Header("GameOver UI")]
    public GameObject gameOverPanel;

    [Header("GameClear UI")]
    public GameObject gameClearPanel;

    private void OnEnable()
    {
        Bus<ICollsionPlayerEvent>.OnEvent += HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent += HandleGameOverUI;
        Bus<IGameClearEvent>.OnEvent += HandleGameClearUI;
    }

    private void OnDisable()
    {
        Bus<ICollsionPlayerEvent>.OnEvent -= HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent -= HandleGameOverUI;
        Bus<IGameClearEvent>.OnEvent -= HandleGameClearUI;

    }

    private void HandleGameClearUI(IGameClearEvent evt)
    {
        gameClearPanel.SetActive(true);
    }

    private void HandleGameOverUI(IGameOverEvent evt)
    {
        Time.timeScale = 0;     // Time.scale을 원상태로 돌려주기
        gameOverPanel.SetActive(true);
    }

    private void Start()
    {
        NPCPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameClearPanel.SetActive(false);
    }

    private void HandleNPCUI(ICollsionPlayerEvent evt)
    {
        NPCPanel.SetActive(true);

        NPCSprite.sprite = evt.NPC.npcInfo.Sprite;
        NPCName.SetText(evt.NPC.npcInfo.NpcName);
        NPCDialogue.SetText(evt.NPC.npcInfo.NPCDialogue);


    }
}
