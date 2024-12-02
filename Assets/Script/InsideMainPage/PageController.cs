using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class PageController : MonoBehaviour
{
    [SerializeField] private Button[] m_btAllButtons;
    public void Start()
    {
        Action[] AllFunction =
        {
            NewGame,
            Continue,
            Settings
        };
        for (int i = 0; i < m_btAllButtons.Length; i++)
        {
            int c = i;
            m_btAllButtons[c].onClick.AddListener(() => AllFunction[c]());
        }
        if (!JakePhLib.SaveAndLoad<CurWorld>.CheckSave(PlayerPrefs.GetString("LastGame"), Application.persistentDataPath + "/Worlds")) m_btAllButtons[1].interactable = false;

    }
    private void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
    private  void Continue()
    {
        World.m_stNameWorld = PlayerPrefs.GetString("LastGame");
        Debug.Log(PlayerPrefs.GetString("LastGame"));
        SceneManager.LoadScene("Game");
    }
    private  void Settings()
    {
        
    }
}
