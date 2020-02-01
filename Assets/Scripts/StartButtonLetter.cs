using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonLetter : MonoBehaviour
{
    public Transform target;
    public float checkDistance;
    string letter;
    public Sprite [] sprites;
    bool isFix = false;
    // Start is called before the first frame update
    void Start()
    {
        checkDistance = 0.5f;
        if(StartGameManager.Singleton.GetHasFixLetter(letter)){
            //移動到位置上
            fixLetter();
        }
    }

    void fixLetter()
    {
        isFix = true;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        transform.position = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) < checkDistance && !isFix) {
            StartGameManager.Singleton.SetHasFixLetter(letter);
            fixLetter();
        }
    }
    private void OnMouseDrag() {
        Vector3 pos =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if(isFix){
            return;
        }
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }

    public void SetLetter(string str){
        letter = str;
        switch (str)
        {
            case "s":
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case "a":
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case "r":
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
        }
    }
}
