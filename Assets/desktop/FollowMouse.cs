using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool isFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollow == true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 60));
        }

    }
    public void follow()
    {
        isFollow = true;

    }
}
