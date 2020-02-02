using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject screwdriver;
    public GameObject aa;
    public bool isFollow = false;
    public bool isShowScrew = false;
    public bool isGetKeyT = StartGameManager.Singleton.GetHasLetter("t");


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollow)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 60));
            gameObject.transform.position = pos;
            if (Mathf.Abs(pos.x + 43) < 10 && Mathf.Abs(pos.y + 34) < 10 && isGetKeyT == false)
            {
                screwdriver.SetActive(true);
                isShowScrew = true;
                StartGameManager.Singleton.SetHasLetter("t");
            }
            if (isShowScrew)
            {
                StartCoroutine(hide());
                float step = 50 * Time.deltaTime;
                screwdriver.transform.localPosition = Vector3.MoveTowards(screwdriver.transform.localPosition, new Vector3(198, 441, 50), step);
            }
        }
    }
    public void follow()
    {
        isFollow = true;
    }
    IEnumerator hide()
    {
        yield return new WaitForSeconds(1.2f);
        screwdriver.SetActive(false);
    }
}
