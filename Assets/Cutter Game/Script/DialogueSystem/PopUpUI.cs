using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUI : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLable;
    public Button button;

    [Header("文本文件")]
    public TextAsset textFile;

    public int index;

    public List<string> textList = new List<string>();


    public GameObject popUpArrow;
    public PopUpArrow pUArrow;

    public bool isOtherOperation = true;


    // Start is called before the first frame update
    void Awake()
    {
        GetTextFromFile(textFile);
    }
    private void OnEnable()
    {

        textLable.text = textList[index];
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOtherOperation == true)
        {
            
            if (Input.GetKeyDown(KeyCode.U) && index == textList.Count)
            {
                gameObject.SetActive(false);
                index = 0;
                return;
            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                if (index == 5 || index == 6 || index == 7)
                {
                    if (!isOtherOperation)
                    {
                        return;
                    }
                    else
                    {
                        isOtherOperation = false;
                    }
                }
                popUpArrow.SetActive(true);
                textLable.text = textList[index];
                index++;
            }

            //当index等于某个数，activate gameObject（就是UI），且bool为真（bool为假就不给用户按键翻页，所以bool判断写在外面）


        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }



}
