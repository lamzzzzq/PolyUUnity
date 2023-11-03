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
    public GameObject[] prePlacedPuzzles;  // Ԥ���õ�ƴͼ

    public GameObject progressBar;  // ������
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

        // ������ʼ������
        GameObject controllerObj = GameObject.FindWithTag("PuzzleController");  // ���� PuzzleController ������һ����Ϊ "PuzzleController" �ı�ǩ
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
            // ���ƴͼ�ѱ���ȷ���ã���ִ���κβ���
            return;
        }

        if (InputBridge.Instance.RightTrigger > 0 && isOccupied)
        {
            if (grabbedPiece == null)
            {
                grabbedPiece = other.gameObject;
            }

            // ��ȡcursor�����ȫ������ϵ�µ��Ϻ��ҷ���
            Vector3 globalUp = grabbedPiece.transform.up;
            Vector3 globalRight = grabbedPiece.transform.right;

            // �����������������ϵ�λ����
            Vector3 offsetUp = Vector3.Project(transform.position - grabbedPiece.transform.position, globalUp);
            Vector3 offsetRight = Vector3.Project(transform.position - grabbedPiece.transform.position, globalRight);

            // �����µ�λ��
            Vector3 newPosition = grabbedPiece.transform.position + offsetUp + offsetRight;

            // ���ñ�ץȡ�������λ��
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
                     piece.isCorrectlyPlaced = true; // ����ƴͼΪ��ȷ����

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
                    piece.isCorrectlyPlaced = true; // ����ƴͼΪ��ȷ����

                    // ���ٻ����ر��϶���ƴͼ
                    grabbedPiece.GetComponent<Image>().sprite = null;
                    Image img = grabbedPiece.GetComponent<Image>();
                    img.color = new Color(img.color.r, img.color.g, img.color.b, 0);

                    // ����Ԥ���õ�ƴͼ
                    int index = piece.index;  // ��ȡ����
                    if (puzzleController != null && puzzleController.prePlacedPuzzles != null && index < puzzleController.prePlacedPuzzles.Length && puzzleController.prePlacedPuzzles[index] != null)
                    {
                        puzzleController.prePlacedPuzzles[index].SetActive(true);
                    }
                    else
                    {
                        Debug.LogError("Failed to activate prePlacedPuzzle. Please check if puzzleController and prePlacedPuzzles are correctly set.");
                    }

                    // ... ��������
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
