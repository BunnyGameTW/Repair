using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    private static StartGameManager s_Instance;
    public Transform letterObject;
    public Transform [] letterPosition;
    public GameObject ObjectA;
    public GameObject screwObject;
    bool [] hasLetter = new bool [5];
    bool [] hasFixLetter = new bool [5];
    private static StartGameManager singleton = null;
    public Sprite tSprite;
   
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
        //  Debug.LogErrorFormat(this.gameObject, "Multiple instances of {0} is not allow", GetType().Name);
         return;
      }
      
      singleton = this;
      GameObject.DontDestroyOnLoad(this.gameObject);
   }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLetter(string str, Vector3 pos){
        int index = 0;
        switch (str)
        {
            case "s":
                index = 0;
                break;
            case "a":
                index = 2;
                break;
             case "r":
                index = 3;
                break;
        }

        if(str != "t"){
            GameObject letterA = Instantiate(ObjectA, pos, new Quaternion(), letterObject);
            letterA.GetComponent<StartButtonLetter>().target = letterPosition[index];
            letterA.GetComponent<StartButtonLetter>().SetLetter(str);
        }
        else{

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
        checkPassGame();
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
        print("CheckMainGame");
    
        //重新尋找場景中的物件
        letterObject = GameObject.Find("startButtonObject").transform;
        letterPosition = new Transform[5];
        letterPosition[0] = GameObject.Find("letterSPosition").transform;
        letterPosition[1] = GameObject.Find("firstTSprite").transform;
        letterPosition[2] = GameObject.Find("letterAPosition").transform;
        letterPosition[3] = GameObject.Find("letterRPosition").transform;
        letterPosition[4] = GameObject.Find("secondTSprite").transform;

        for(int i = 0; i < 5; i++){
            print("hasLetter[" + i + "]: " + hasLetter[i]);
            print("hasFixLetter[" + i + "]: " + hasFixLetter[i]);
        }


        checkLetters();
        checkPassGame();

    }
    void checkLetters(){
         if(GetHasLetter("t")){
            if(GetHasFixLetter("t")){
                GameObject.Find("firstTSprite").GetComponent<SpriteRenderer>().sprite = tSprite;
                GameObject.Find("secondTSprite").GetComponent<SpriteRenderer>().sprite = tSprite;

            }
            else{
                Instantiate(screwObject);//TODO 調整位置
            }
        }

        if(GetHasLetter("s")){
            SpawnLetter("s", GameObject.Find("letterSOriginPosition").transform.position);
        }

        if(GetHasLetter("r")){
            SpawnLetter("r", GameObject.Find("letterROriginPosition").transform.position);
        }       
    }
    void checkPassGame(){
         bool isPass = true;
        for(int i = 0; i < 5; i++){
            if(!hasFixLetter[i]) isPass = false;
        }
        if(isPass){
            GameObject.Find("startButtonUI").GetComponent<UnityEngine.UI.Button>().enabled = true;
            GameObject.Find("startButtonUI").GetComponent<UnityEngine.UI.Image>().enabled = true;

            GameObject.Find("startButton").SetActive(false);
            GameObject.Find("startButtonObject").SetActive(false);

        }
    }
}
