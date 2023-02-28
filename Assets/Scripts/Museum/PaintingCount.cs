using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingCount : MonoBehaviour
{
    // Start is called before the first frame update
    int paintingCount = 0;
    int puzzleSolvingCount = 0;

    public Text painting;
    public Text puzzleSolving;


    private void Update()
    {
        painting.text = paintingCount.ToString();
        puzzleSolving.text = puzzleSolvingCount.ToString();
    }

    public void AddPaintingCount()
    {
        paintingCount++;
    }

    public void AddPuzzleSolvingCount()
    {
        puzzleSolvingCount++;
    }
}
