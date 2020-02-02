using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadDesktop() {
        GameObject.Find("sceneObject").SetActive(false);
        StartGameManager.Singleton.lastScene = "desktop";
        UnityEngine.SceneManagement.SceneManager.LoadScene("desktop");
    }
    public void FadeOut(){
        GetComponent<Animator>().SetBool("isFadeOut", true);
    }

    public void FadeIn(){
        GetComponent<Animator>().SetBool("isFadeIn", false);
        GameObject.Find("fadeObject").SetActive(false);
    }
}
