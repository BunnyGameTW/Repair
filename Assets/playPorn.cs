using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playPorn : MonoBehaviour
{
    public GameObject R18;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowR18()
    {
        R18.GetComponent<Animation>().Play("Popup");
        StartGameManager.Singleton.SetHasLetter("r");
        StartCoroutine(hide());
    }

    IEnumerator hide()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel("desktop");
    }
}
