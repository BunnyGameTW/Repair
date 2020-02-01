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
}
