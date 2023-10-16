using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using BNG;
using SimpleJSON;
public class MainManager : MonoBehaviour
{
    // Singleton Instance
    public static MainManager Instance;

    // UI and External Components
    public GameObject InputField;
    private VRTextInput vrTextInput;
    public GameObject menuContainer;
    public UnityEngine.UI.Slider slider;
    public Text progressText;

    // Scene and User Data
    private Scene scene;
    private string userID;
    private Dictionary<string, string> dialogueOptions = new Dictionary<string, string>();


    public string task_1_1;
    public string task_1_2;
    public string task_1_3;
    public string task_1_4;
    public string task_1_5;



    public string task_4_1;
    public string task_4_4;
   

    //public GameObject optionsSubMenu;
    public UnityEngine.UI.Button[] levelButtons;

    // Level Loading variables


    #region Singleton
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

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

        // Find the menuContainer GameObject (if it exists in the scene)
        GameObject menuContainerObject = GameObject.FindGameObjectWithTag("WristMenu");

        // Assign the menuContainer variable if the GameObject is found
        if (menuContainerObject != null)
        {
            menuContainer = menuContainerObject;
        }

        // Find the slider and progressText GameObjects (if they exist in the scene)
        GameObject sliderObject = GameObject.FindGameObjectWithTag("LoadingSlider");
        GameObject progressTextObject = GameObject.FindGameObjectWithTag("LoadingProgressText");

        // Assign the Slider and Text components if the GameObjects are found
        if (sliderObject != null)
        {
            slider = sliderObject.GetComponent<UnityEngine.UI.Slider>();
        }
        if (progressTextObject != null)
        {
            progressText = progressTextObject.GetComponent<UnityEngine.UI.Text>();
        }
    }

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        vrTextInput = InputField.GetComponent<VRTextInput>();
        //userID = vrTextInput.userID;

        // Start the SaveCSVFileCoroutine
        StartCoroutine(SaveCSVFileCoroutine());
    }

    private void Update()
    {
        userID = vrTextInput.userID;

        // Toggle menu when the player presses the key
        if ((Input.GetKeyDown(KeyCode.M)) || (InputBridge.Instance.XButtonDown))
        {
            ToggleMenu();
        }
    }


    void SaveString(string str)
    {
        string filePath = Application.persistentDataPath + "/Scene:" +scene.buildIndex + ".csv";
        print("saving to" + filePath);

        Debug.Log("Scene build index: " + scene.buildIndex);
        Debug.Log("Active scene name: " + scene.name);

        //long time = new System.DateTimeOffset(System.DateTime.Now).ToUnixTimeSeconds();
        //string timeID = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "," + time.ToString() + ",";
        string timeID = System.DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss") + ",";
        Debug.Log(timeID);

        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Scene_" + SceneManager.GetActiveScene().buildIndex +"_" + timeID + ".csv");
        sw.WriteLine(timeID);
        sw.WriteLine(str);
        sw.Close();
    }

    void a() {
        JSONNode json = new JSONArray();
        json["S1"]["Q1"]= 1;

        string filePath = Application.persistentDataPath + "/Scene:" + scene.buildIndex + ".json";
        string timeID = System.DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss") + ",";
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Scene_" + SceneManager.GetActiveScene().buildIndex + "_" + timeID + ".json");
        sw.WriteLine(timeID);
        sw.WriteLine(json.ToString());
        sw.Close();
    }

    void SaveOption()
    {
        // 更新当前场景
        scene = SceneManager.GetActiveScene();

        // 清除以前的内容
        dialogueOptions.Clear();

        // 存储当前场景的任务内容到字典中
        StoreSceneTasksInDictionary();

        // 使用改进的SaveString方法进行保存
        SaveStringToFile();



        //暂时comment
/*        switch (scene.buildIndex)
        {
            case 1:
                task_1_1 = string.Concat(userID, ",", "1_1_OPTION IS:", ",", DialogueLua.GetVariable("1_1_OPTION_1").asString, ",", DialogueLua.GetVariable("1_1_OPTION_2").asString);
                task_1_2 = string.Concat(userID, ",", "1_2_OPTION IS:", ",", DialogueLua.GetVariable("1_2_OPTION_1").asString, ",", DialogueLua.GetVariable("1_2_OPTION_2").asString);
                task_1_3 = string.Concat(userID, ",", "1_3_OPTION IS:", ",", DialogueLua.GetVariable("1_3_OPTION_1").asString, ",", DialogueLua.GetVariable("1_3_OPTION_2").asString);
                task_1_4 = string.Concat(userID, ",", "1_4_OPTION IS:", ",", DialogueLua.GetVariable("1_4_OPTION_1").asString, ",", DialogueLua.GetVariable("1_4_OPTION_2").asString);
                task_1_5 = string.Concat(userID, ",", "1_5_OPTION IS:", ",", DialogueLua.GetVariable("1_5_OPTION_1").asString, ",", DialogueLua.GetVariable("1_5_OPTION_2").asString, ",", DialogueLua.GetVariable("1_5_OPTION_3").asString);
                SaveString(task_1_1 + "," + task_1_2 + "," + task_1_3 + "," + task_1_4 + "," + task_1_5);
                break;
            case 2:
                task_4_4 = "scene2";
                SaveString(task_4_4);
                break;
            case 3:
                task_4_4 = "scene3";
                SaveString(task_4_4);
                break;
            case 4:
                task_4_1 = string.Concat(userID, ",", "4_1_OPTION IS:", ",", DialogueLua.GetVariable("4_1_OPTION_1").asString, ",", DialogueLua.GetVariable("4_1_OPTION_2").asString, ",", DialogueLua.GetVariable("4_1_OPTION_3").asString);
                task_4_4 = string.Concat(userID, ",", "4_4_OPTION IS:", ",", DialogueLua.GetVariable("4_4_OPTION_1").asString, ",", DialogueLua.GetVariable("4_4_OPTION_2").asString, ",", DialogueLua.GetVariable("4_4_OPTION_3").asString);
                SaveString(task_4_1 + "," + task_4_4);
                break;
            case 5:
                task_4_4 = string.Concat(userID, ",", "4_4_OPTION IS:", ",", DialogueLua.GetVariable("4_4_OPTION_1").asString, ",", DialogueLua.GetVariable("4_4_OPTION_2").asString, ",", DialogueLua.GetVariable("4_4_OPTION_3").asString);
                SaveString(task_4_4);
                break;
            // Add more cases for other scenes if needed
            default:
                break;
        } */
    }

    void StoreSceneTasksInDictionary()
    {
        switch (scene.buildIndex)
        {
            case 1:
                AddToDictionary("1_1_OPTION", $"{userID},1_1_OPTION IS:,{DialogueLua.GetVariable("1_1_OPTION_1").asString},{DialogueLua.GetVariable("1_1_OPTION_2").asString}");
                AddToDictionary("1_2_OPTION", $"{userID},1_2_OPTION IS:,{DialogueLua.GetVariable("1_2_OPTION_1").asString},{DialogueLua.GetVariable("1_2_OPTION_2").asString}");
                AddToDictionary("1_3_OPTION", $"{userID},1_3_OPTION IS:,{DialogueLua.GetVariable("1_3_OPTION_1").asString},{DialogueLua.GetVariable("1_3_OPTION_2").asString}");
                AddToDictionary("1_4_OPTION", $"{userID},1_4_OPTION IS:,{DialogueLua.GetVariable("1_4_OPTION_1").asString},{DialogueLua.GetVariable("1_4_OPTION_2").asString}");
                AddToDictionary("1_5_OPTION", $"{userID},1_5_OPTION IS:,{DialogueLua.GetVariable("1_5_OPTION_1").asString},{DialogueLua.GetVariable("1_5_OPTION_2").asString},{DialogueLua.GetVariable("1_5_OPTION_3").asString}");



                // ... 同样的方式添加其他任务内容
                break;
            case 2:
                AddToDictionary("Scene", "scene2");
                break;
            // ... 其他场景的处理
            default:
                break;
        }
    }

    void AddToDictionary(string key, string value)
    {
        dialogueOptions[key] = value;
    }


    void SaveStringToFile()
    {
        string filePath = Application.persistentDataPath + "/Scene:" + scene.buildIndex + ".csv";
        print("saving to" + filePath);

        string timeID = System.DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss") + ",";
        Debug.Log(timeID);

        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/Scene_" + SceneManager.GetActiveScene().buildIndex + userID + "_" + timeID + ".csv");
        sw.WriteLine(timeID);

        foreach (var entry in dialogueOptions)
        {
            sw.WriteLine(entry.Value);
        }

        sw.Close();
    }


    IEnumerator SaveCSVFileCoroutine()
    {
        while (true)
        {
            // Wait for 60 seconds
            yield return new WaitForSeconds(60);

            // Save the CSV file
            SaveOption();

            a();

            if (!string.IsNullOrEmpty(userID))
            {
                Debug.Log(userID);
            }
            else
            {
                Debug.Log("userID 是空的");
            }
        }

    }
    public void ToggleMenu()
    {
        if (menuContainer != null)
        {
            menuContainer.SetActive(!menuContainer.activeSelf);

            LevelButtonHandler levelButtonHandler = menuContainer.GetComponent<LevelButtonHandler>();
            if (levelButtonHandler != null)
            {
                levelButtonHandler.UpdateButtons();
            }
        }
    }



    // Level loading methods

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadLevelAsync(sceneName));
    }

    IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        float progress = 0;

        while (!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);

            if (slider != null)
            {
                slider.value = progress;
            }

            if (progressText != null)
            {
                progressText.text = (progress * 100) + "%";
            }

            if (progress >= 0.9f)
            {
                if (slider != null)
                {
                    slider.value = 1;
                }

                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void OnButtonClick(string scene)
    {
        Debug.Log("Button clicked!");
        LoadLevel(scene);
        // Add your button click logic here
    }


    public void InitializeDialogueOptions()
    {
        //scene 1
        AddToDictionary("1_1_OPTION", $"{userID},1_1_OPTION IS:,1_False,2_False");
        AddToDictionary("1_2_OPTION", $"{userID},1_2_OPTION IS:,1_False,2_False");
        AddToDictionary("1_3_OPTION", $"{userID},1_3_OPTION IS:,1_False,2_False");
        AddToDictionary("1_4_OPTION", $"{userID},1_4_OPTION IS:,1_False,2_False");
        AddToDictionary("1_5_OPTION", $"{userID},1_5_OPTION IS:,1_False,2_False,3_False");


        //scene 2
    }
}
            
