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


    private void OnEnable()
    {
        Bus<ICollsionPlayerEvent>.OnEvent += HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent += NPCOver;
    }

    private void OnDisable()
    {
        Bus<ICollsionPlayerEvent>.OnEvent -= HandleNPCUI;
        Bus<IGameOverEvent>.OnEvent -= NPCOver;

    }

    private void NPCOver(IGameOverEvent evt)
    {
        
    }

    

    private void Start()
    {
        NPCPanel.SetActive(false);
    }
    private void HandleNPCUI(ICollsionPlayerEvent evt)
    {
        NPCPanel.SetActive(true);

        NPCSprite.sprite = evt.NPC.npcInfo.Sprite;
        NPCName.SetText(evt.NPC.npcInfo.NpcName);
        NPCDialogue.SetText(evt.NPC.npcInfo.NPCDialogue);


    }
}
