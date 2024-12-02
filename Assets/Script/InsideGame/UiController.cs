using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static GameObject[] mst_gAllPannels;
    public GameObject[] m_gAllPannels;

    public void Start()
    {
        mst_gAllPannels = m_gAllPannels;
    }
    public static void Open(int Name) 
    {
        mst_gAllPannels[Name].SetActive(!mst_gAllPannels[Name].activeSelf);
        if (Name == 0) WalkScript.m_bAvailable = !mst_gAllPannels[Name].activeSelf;
    }
    public void Save()
    {
        SavingWorld.Save();
        PlayerPrefs.SetString("LastGame", World.m_stNameWorld);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainPage");

    }
    public void Pause()
    {
        m_gAllPannels[2].SetActive(!m_gAllPannels[2].activeSelf);
        Time.timeScale = m_gAllPannels[2].activeSelf == true ? 0 : 1;
    }
}
[System.Serializable]
public class s
{
    public int[,] c = new int[1, 2];
}