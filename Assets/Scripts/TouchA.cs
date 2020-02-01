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
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, originPosition) < checkDistance && isDrag && !isFix){
            GetComponent<Rigidbody>().isKinematic = true;
            isFix = true;
            print("spawn");
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            transform.position = originPosition;
            Instantiate(ObjectA, originPosition, new Quaternion());
        }
    }
    private void OnMouseDrag() {
        Vector3 pos =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        // Debug.Log(Vector2.Distance(new Vector2(pos.x, pos.y), new Vector2(jointPosition.x, jointPosition.y)));
        if(Vector2.Distance(new Vector2(pos.x, pos.y), new Vector2(jointPosition.x, jointPosition.y)) > maxDistance || isFix){
            return;
        }
        // Debug.Log("local" + transform.localPosition.z);
        transform.position = new Vector3(pos.x, pos.y, originPosition.z);

        isDrag = true;
    }
    private void OnMouseUp() {
        isDrag = false;
    }
}
