using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLight : MonoBehaviour
{
    public GameObject flashlight; //宣告物件，名稱platform1
    public bool isFlashLightExist = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void CreateFlashLight()
    {
        if (isFlashLightExist == false)
        {
            isFlashLightExist = true;
            Vector3 pos = new Vector3(0f, -7f, -60);
            Instantiate(flashlight, pos, transform.rotation);
            Debug.Log("456");
        }

    }


}

