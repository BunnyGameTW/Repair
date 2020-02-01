using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    private static StartGameManager s_Instance;
    int letterNumber;
    bool canStartGame;
    int TOTAL_LETTER = 5;
    public Transform letterObject;
    public Transform [] letterPosition;
    public GameObject ObjectA;

    //TODO 紀錄現在的狀態 那些有得到 那些沒得到
    //TODO 是否有螺絲起子
    //TODO 是否修復標題
    //獲得字母狀態[S,T,A,R,T]
    //TODO 是否有
    bool [] hasLetter = new bool [5];
    bool [] hasFixLetter = new bool [5];
    private static StartGameManager singleton = null;
   
   public static StartGameManager Singleton
   {
      get
      {
         if (singleton == null)
         {
            singleton = new StartGameManager();
         }
         
         return singleton;
      }
   }
   
   private void Awake()
   {
      if (singleton != null)
      {
         Debug.LogErrorFormat(this.gameObject, "Multiple instances of {0} is not allow", GetType().Name);
         return;
      }
      
      singleton = this;
      GameObject.DontDestroyOnLoad(this.gameObject);
   }

    // Start is called before the first frame update
    void Start()
    {
        letterNumber = 0;
        canStartGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetButtonLetter(){
        letterNumber++;
        if(letterNumber == TOTAL_LETTER){
            canStartGame = true;//TODO 把按鈕設定成可以按
        }
    }
    public void SpawnLetter(string str, Vector3 pos){
        switch (str)
        {
            case "a":
                GameObject letterA = Instantiate(ObjectA, pos, new Quaternion(), letterObject);
                letterA.GetComponent<StartButtonLetter>().target = letterPosition[2];
            break;
        }
    }

    //設定得到哪個文字
    public void SetHasLetter(string letter){
        switch (letter)
        {
            case "s":
                hasLetter[0] = true;
                break;
            case "t":
                hasLetter[1] = true;
                hasLetter[4] = true;
                break;
            case "a":
                hasLetter[2] = true;
                break;
            case "r":
                hasLetter[3] = true;
                break;
            default:
                Debug.Log("ERROR: 要傳入得到哪個字母 s,t,a,r");
                break;
        }
    }
    public bool GetHasLetter(string letter){
        switch (letter)
        {
            case "s":
                return hasLetter[0];
            case "t":
                return hasLetter[1];
            case "a":
                return hasLetter[2];
            case "r":
                return hasLetter[3];
            default:
                Debug.Log("ERROR: 要傳入得到哪個字母的狀態 s,t,a,r");
                return false;
        }
    }

    public void SetHasFixLetter(string letter){
        switch (letter){
            case "s":
                hasFixLetter[0] = true;
                break;
            case "t":
                hasFixLetter[1] = true;
                hasFixLetter[4] = true;
                break;
            case "a":
                hasFixLetter[2] = true;
                break;
            case "r":
                hasFixLetter[3] = true;
                break;
            default:
                Debug.Log("ERROR: 要傳入得到哪個字母 s,t,a,r");
                break;
        }
    }
    public bool GetHasFixLetter(string letter){
        switch (letter)
        {
            case "s":
                return hasFixLetter[0];
            case "t":
                return hasFixLetter[1];
            case "a":
                return hasFixLetter[2];
            case "r":
                return hasFixLetter[3];
            default:
                Debug.Log("ERROR: 要傳入得到哪個字母的狀態 s,t,a,r");
                return false;
        }
    }



    public void CheckMainGame(){
        //TODO 檢查以獲得的文字
        // if(hasLetter[0]){
        //     if(hasFixLetter[0]){

        //     }else{

        //     }
        // }

        for(int i = 0; i < 5; i++){
            print("hasLetter[" + i + "]: " + hasLetter[i]);
            print("hasFixLetter[" + i + "]: " + hasFixLetter[i]);
        }
        //TODO 檢查已修復的文字
    }
  
}
