using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject MiniGameBtn;
    public GameObject PornBtn;
    void Start()
    {

    }
    void Update()
    {
        if (StartGameManager.Singleton.GetHasLetter("s") == true)
        {
            MiniGameBtn.SetActive(false);
        }
        if (StartGameManager.Singleton.GetHasLetter("r"))
        {
            PornBtn.SetActive(false);
        }
    }
    public void switchLobby()
    {
        Application.LoadLevel("mainscene");
    }

    public void switchMiniGame()
    {
        Application.LoadLevel("MiniGame");
    }
    public void switchPornHub()
    {
        Application.LoadLevel("PornHub");
    }
}
