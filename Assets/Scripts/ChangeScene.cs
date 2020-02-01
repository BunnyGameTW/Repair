using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change(string name){
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
    
    public void GetSLetter(){
        StartGameManager.Singleton.SetHasLetter("s");
        StartGameManager.Singleton.SetHasLetter("r");
    }

    public void GetTLetter(){
         StartGameManager.Singleton.SetHasLetter("t");

    }
}
