using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject MiniGameBtn;
    public bool  isGetKeyS = StartGameManager.Singleton.GetHasFixLetter("s");
    void Start()
    {

    }
    void Update()
    {
        if (isGetKeyS == true)
        {
            MiniGameBtn.SetActive(false);
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

}
