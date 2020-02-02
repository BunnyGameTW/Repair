using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIsmoveAndPlayAnim : MonoBehaviour
{
    public void changeIsmove()
    {
        gameObject.SetActive(false);
        //GetComponent<Animator>().SetBool("isMove", false);
    }
}
