using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screw : MonoBehaviour
{
    bool isDrag;
    float checkDistance;
    bool canUse;
    GameObject firstT, secondT;
    Animator animator;
    GameObject tObject;
    public Sprite tSprite;
    int counter;
    bool [] isChange;
    // Start is called before the first frame update
    void Start()
    {
        checkDistance = 0.5f;
        isDrag = false;
        canUse = true;
        firstT = GameObject.Find("firstTSprite");
        secondT = GameObject.Find("secondTSprite");
        animator = GetComponent<Animator>();
        counter = 0;
        isChange = new bool [2];
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(firstT.transform.position.x, firstT.transform.position.y)) < checkDistance && isDrag && !isChange[0]){
            canUse = false;
            tObject = firstT;
            isChange[0] = true;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = new Vector3(tObject.transform.position.x, tObject.transform.position.y, transform.position.z);
            animator.SetBool("isRotate", true);
        }
        if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(secondT.transform.position.x, secondT.transform.position.y)) < checkDistance && isDrag && !isChange[1]){
            canUse = false;
            tObject = secondT;
            isChange[1] = true;
            GetComponent<Rigidbody>().isKinematic = true;

            transform.position = new Vector3(tObject.transform.position.x, tObject.transform.position.y, transform.position.z);

            animator.SetBool("isRotate", true);
        }
        
    }

    public void ChangeTSprite(){
        tObject.GetComponent<SpriteRenderer>().sprite = tSprite;
    }

    public void AnimationEnd(){
        canUse = true;
        animator.SetBool("isRotate", false);
        counter++;
        if(counter == 2){
            StartGameManager.Singleton.SetHasFixLetter("t");
            Destroy(this.gameObject);
        }
        GetComponent<Rigidbody>().isKinematic = false;

    }
     private void OnMouseDrag() {
        Vector3 pos =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        if(!canUse) return;
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        isDrag = true;
    }
    private void OnMouseUp() {
        isDrag = false;
    }
}
