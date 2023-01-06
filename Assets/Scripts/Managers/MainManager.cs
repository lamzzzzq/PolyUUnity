using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
using BNG;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public GameObject InputField;
    private VRTextInput vrTextInput;

    public string task_4_1;
    public string task_4_4;
    Scene scene;

    private string userID;


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update the scene field with the new scene.
        this.scene = scene;
    }


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        scene = SceneManager.GetActiveScene();

        vrTextInput = InputField.GetComponent<VRTextInput>();
    }

    void Update()
    {
        userID = vrTextInput.userID;
        //Debug.Log(userID + "Here");

        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveString(task_4_1 + "," + task_4_4);
            
        }

        task_4_1 = string.Concat(userID,",","4_1_OPTION IS:", ",", DialogueLua.GetVariable("4_1_OPTION_1").asString, ",", DialogueLua.GetVariable("4_1_OPTION_2").asString, ",", DialogueLua.GetVariable("4_1_OPTION_3").asString) ;
        task_4_4 = string.Concat(userID, " ,", "4_4_OPTION IS:", ",", DialogueLua.GetVariable("4_4_OPTION_1").asString, ",", DialogueLua.GetVariable("4_4_OPTION_2").asString, ",", DialogueLua.GetVariable("4_4_OPTION_3").asString);

    }

    void SaveString(string str)
    {
        //string filePath = Application.persistentDataPath + "/Scene:" +scene.buildIndex + ".txt";
        //print("saving to" + filePath);

        Debug.Log("Scene build index: " + scene.buildIndex);
        Debug.Log("Active scene name: " + scene.name);

        //long time = new System.DateTimeOffset(System.DateTime.Now).ToUnixTimeSeconds();
        //string timeID = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "," + time.ToString() + ",";
        string timeID = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ",";
        Debug.Log(timeID);

        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Scene_" + SceneManager.GetActiveScene().buildIndex + ".csv");
        sw.WriteLine(timeID);
        sw.WriteLine(str);
        sw.Close();

    }

}
