using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonLetter : MonoBehaviour
{
    public Transform target;
    public float checkDistance;
    bool isFix = false;
    // Start is called before the first frame update
    void Start()
    {
        checkDistance = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Vector3.Distance(transform.position, target.position));
        if(Vector3.Distance(transform.position, target.position) < checkDistance && !isFix) {
            StartGameManager.Singleton.GetButtonLetter();
            isFix = true;
            print("letter fix");
            GetComponent<Rigidbody>().isKinematic = true;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            transform.position = target.position;
        }
    }
    private void OnMouseDrag() {
        Vector3 pos =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if(isFix){
            return;
        }
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
