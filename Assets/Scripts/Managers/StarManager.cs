using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Image[] starImages; // ���ǵ�Image�������
    public Sprite[] starSprites; // ���ǵ�Sprite����

    private int completedTasksCount = 0; // ����ɵ���������


    // ������񣬸������ǵ�״̬
    public void CompleteTask(bool isSuccess)
    {
        starImages[completedTasksCount].sprite = isSuccess ? starSprites[1] : starSprites[2]; // ���ݳɹ�������ö�Ӧ��Sprite

        completedTasksCount++; // ��ɵ�����������һ

        // �����ɵ��������������������������ٸ�����ʾ
        if (completedTasksCount >= starImages.Length)
        {
            return;
        }

        // ����ʣ�����ǵ���ʾΪ״̬һ�ľ���
        for (int i = completedTasksCount; i < starImages.Length; i++)
        {
            starImages[i].sprite = starSprites[0]; // ����Ϊ״̬һ��Sprite
        }
    }

    // �������񣬽����ǵ�״̬�ָ�Ϊ��ʼ״̬
    public void ResetTasks()
    {
        completedTasksCount = 0; // ������ɵ���������Ϊ��
        // �������ǵ���ʾΪ״̬һ�ľ���
        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].sprite = starSprites[0]; // ����Ϊ״̬һ��Sprite
        }
    }
}
