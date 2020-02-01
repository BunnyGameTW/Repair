using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TouchA : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 jointPosition, originPosition;
    public GameObject ObjectA;
    public float maxDistance = 5;
    public float checkDistance = 0.1f;
    bool isDrag = false;
    bool isFix = false;
    
    void Start()
    {
        jointPosition =  GetComponent<CharacterJoint>().connectedAnchor;
        originPosition = transform.position;
        //TODO
        if(StartGameManager.Singleton.GetHasLetter("a")){
            isFix = true;
            if(StartGameManager.Singleton.GetHasFixLetter("a")){
                
            }
            //TODO 把LOGO A正常位置

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, originPosition) < checkDistance && isDrag && !isFix){
            GetComponent<Rigidbody>().isKinematic = true;
            isFix = true;
            print("spawn A");
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            transform.position = originPosition;
            originPosition.z += -1.0f;
            StartGameManager.Singleton.SetHasLetter("a");
            StartGameManager.Singleton.SpawnLetter("a", originPosition);
        }
    }
    private void OnMouseDrag() {
        Vector3 pos =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if(Vector2.Distance(new Vector2(pos.x, pos.y), new Vector2(jointPosition.x, jointPosition.y)) > maxDistance || isFix){
            return;
        }
        transform.position = new Vector3(pos.x, pos.y, originPosition.z);
        isDrag = true;
    }
    private void OnMouseUp() {
        isDrag = false;
    }

}
