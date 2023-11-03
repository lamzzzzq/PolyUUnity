using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using UnityEngine.UI;

public class UIMove : MonoBehaviour
{
    public bool moveXY = true;
    public bool isOccupied;

    private GameObject grabbedPiece;
    public int correctPiecesCount = 0;
    public int solvedJigsawCount = 0;
    public GameObject starPrefab;
    public Transform starContainer;


    public AudioClip snapSound;
    public AudioClip solveJigsaw;
    private AudioSource audioSource;

    public GameObject[] logoPieces;
    public GameObject[] prePlacedPuzzles;  // 预放置的拼图

    public GameObject progressBar;  // 进度条
    public UnityEngine.UI.Slider slider;

    private PuzzleController puzzleController;


    private void StartNewGame()
    {
        correctPiecesCount = 0;
        // Perform any additional reset or initialization steps for the new game
    }


    private void Start()
    {
        logoPieces = new GameObject[5];
        progressBar = GameObject.Find("StatusBar");
        if (progressBar != null)
        {
            slider = progressBar.GetComponent<UnityEngine.UI.Slider>();
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 其他初始化代码
        GameObject controllerObj = GameObject.FindWithTag("PuzzleController");  // 假设 PuzzleController 对象有一个名为 "PuzzleController" 的标签
        if (controllerObj != null)
        {
            Debug.Log("load conotroller");
            puzzleController = controllerObj.GetComponent<PuzzleController>();
        }

        if (controllerObj != null)
        {
            Debug.Log("Found PuzzleController object.");
            puzzleController = controllerObj.GetComponent<PuzzleController>();
            if (puzzleController == null)
            {
                Debug.LogError("PuzzleController script not found on the object.");
            }
        }
        else
        {
            Debug.LogError("PuzzleController object not found.");
        }

        moveXY = true;
        slider.maxValue = 5;
        slider.value = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PuzzlePiece")
        {
            isOccupied = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PuzzlePiece piece = other.GetComponent<PuzzlePiece>();
        if (piece != null && piece.isCorrectlyPlaced)
        {
            // 如果拼图已被正确放置，不执行任何操作
            return;
        }

        if (InputBridge.Instance.RightTrigger > 0 && isOccupied)
        {
            if (grabbedPiece == null)
            {
                grabbedPiece = other.gameObject;
            }

            // 获取cursor物体的全局坐标系下的上和右方向
            Vector3 globalUp = grabbedPiece.transform.up;
            Vector3 globalRight = grabbedPiece.transform.right;

            // 计算在这两个方向上的位移量
            Vector3 offsetUp = Vector3.Project(transform.position - grabbedPiece.transform.position, globalUp);
            Vector3 offsetRight = Vector3.Project(transform.position - grabbedPiece.transform.position, globalRight);

            // 计算新的位置
            Vector3 newPosition = grabbedPiece.transform.position + offsetUp + offsetRight;

            // 设置被抓取物体的新位置
            grabbedPiece.transform.position = newPosition;
        }
        else
        {
            grabbedPiece = null;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PuzzlePiece")
        {
            isOccupied = false;
            if (grabbedPiece == other.gameObject)
            {
                grabbedPiece = null;
            }
        }
    }

    /* private void Update()
     {
         if (grabbedPiece != null && InputBridge.Instance.RightTrigger <= 0)
         {
             PuzzlePiece piece = grabbedPiece.GetComponent<PuzzlePiece>();
             if (piece != null)
             {
                 float distanceToSnapPoint = Vector3.Distance(grabbedPiece.transform.position, piece.SnapPoint.position);
                 float snapThreshold = 0.5f;

                 if(distanceToSnapPoint <= snapThreshold)
                 {
                     grabbedPiece.transform.position = piece.SnapPoint.position;
                     piece.isCorrectlyPlaced = true; // 设置拼图为正确放置

                     // Play snap sound
                     if (snapSound != null)
                     {
                         audioSource.PlayOneShot(snapSound);
                     }

                     correctPiecesCount++;

                     if(correctPiecesCount == 3)
                     {
                         if (solveJigsaw != null)
                         {
                             audioSource.PlayOneShot(solveJigsaw);
                         }

                         if (solvedJigsawCount < 5)
                         {
                             if (solvedJigsawCount >= 0 && solvedJigsawCount < logoPieces.Length)
                             {
                                 //logoPieces[solvedJigsawCount].SetActive(true);
                             }
                             else
                             {
                                 Debug.LogError($"solvedJigsawCount value ({solvedJigsawCount}) is out of bounds!");
                             }
                         }

                         solvedJigsawCount++;

                         slider.value = solvedJigsawCount;

                         //GameObject star = Instantiate(starPrefab, starContainer);
                         Debug.Log(solvedJigsawCount);

                         correctPiecesCount = 0;

                         if (solvedJigsawCount == 5)
                         {
                             // All jigsaws have been solved
                             // Perform any additional actions or display a completion message
                         }
                     }
                 }
             }
             grabbedPiece = null;
         }
     }*/

    private void Update()
    {
        //Debug.Log("Distance to Snap Point: " + distanceToSnapPoint);
        Debug.Log("Correct Pieces Count: " + correctPiecesCount);
        Debug.Log("Solved Jigsaw Count: " + solvedJigsawCount);

        if (grabbedPiece != null && InputBridge.Instance.RightTrigger <= 0)
        {
            PuzzlePiece piece = grabbedPiece.GetComponent<PuzzlePiece>();
            if (piece != null)
            {
                float distanceToSnapPoint = Vector3.Distance(grabbedPiece.transform.position, piece.SnapPoint.position);
                float snapThreshold = 0.5f;

                if (distanceToSnapPoint <= snapThreshold)
                {
                    grabbedPiece.transform.position = piece.SnapPoint.position;
                    piece.isCorrectlyPlaced = true; // 设置拼图为正确放置

                    // 销毁或隐藏被拖动的拼图
                    grabbedPiece.GetComponent<Image>().sprite = null;
                    Image img = grabbedPiece.GetComponent<Image>();
                    img.color = new Color(img.color.r, img.color.g, img.color.b, 0);

                    // 激活预放置的拼图
                    int index = piece.index;  // 获取索引
                    if (puzzleController != null && puzzleController.prePlacedPuzzles != null && index < puzzleController.prePlacedPuzzles.Length && puzzleController.prePlacedPuzzles[index] != null)
                    {
                        puzzleController.prePlacedPuzzles[index].SetActive(true);
                    }
                    else
                    {
                        Debug.LogError("Failed to activate prePlacedPuzzle. Please check if puzzleController and prePlacedPuzzles are correctly set.");
                    }

                    // ... 其他代码
                    // Play snap sound
                    if (snapSound != null)
                    {
                        audioSource.PlayOneShot(snapSound);
                    }

                    correctPiecesCount++;

                    if (correctPiecesCount == 3)
                    {
                        if (solveJigsaw != null)
                        {
                            audioSource.PlayOneShot(solveJigsaw);
                        }

                        if (solvedJigsawCount < 5)
                        {
                            if (solvedJigsawCount >= 0 && solvedJigsawCount < logoPieces.Length)
                            {
                                //logoPieces[solvedJigsawCount].SetActive(true);
                            }
                            else
                            {
                                Debug.LogError($"solvedJigsawCount value ({solvedJigsawCount}) is out of bounds!");
                            }
                        }

                        solvedJigsawCount++;

                        slider.value = solvedJigsawCount;

                        //GameObject star = Instantiate(starPrefab, starContainer);
                        Debug.Log(solvedJigsawCount);

                        correctPiecesCount = 0;

                        if (solvedJigsawCount == 5)
                        {
                            // All jigsaws have been solved
                            // Perform any additional actions or display a completion message
                        }
                    }
                }
            }
            grabbedPiece = null;
        }
    }

}
