using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Button ReStartbutton;
    [SerializeField] Button Quitbutton;

    private void OnEnable()
    {
        ReStartbutton.onClick.AddListener(ReStart);
        Quitbutton.onClick.AddListener(Quit);
    }

    private void OnDisable()
    {
        ReStartbutton.onClick.RemoveAllListeners();
        Quitbutton.onClick.RemoveAllListeners();


    }
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
        // application


    }

    public void ReStart()
    {
        Debug.Log("게임 재시작");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);

    }
}
