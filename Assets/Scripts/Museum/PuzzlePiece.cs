using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Transform SnapPoint;
    public bool isCorrectlyPlaced = false; // 这个值将被用来确定拼图是否已被正确放置
    public int index; // 新增这一行
}