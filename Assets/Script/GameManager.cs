using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int num;
    public static void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width * 0.025f, Screen.height * 0.1f, 150, 30), "ChangeScene: " + num))
        {
            ChangeScene(num);
        }
        if (GUI.Button(new Rect(120, 93, 80, 20), "+"))
        {
            num++;
        }
        if (GUI.Button(new Rect(220, 93, 80, 20), "-"))
        {
            if (num > 0)
                num--;
        }
    }
}
