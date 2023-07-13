using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Image[] starImages; // 星星的Image组件数组
    public Sprite[] starSprites; // 星星的Sprite数组

    private int completedTasksCount = 0; // 已完成的任务数量


    // 完成任务，更新星星的状态
    public void CompleteTask(bool isSuccess)
    {
        starImages[completedTasksCount].sprite = isSuccess ? starSprites[1] : starSprites[2]; // 根据成功与否设置对应的Sprite

        completedTasksCount++; // 完成的任务数量加一

        // 如果完成的任务数量超过星星数量，则不再更新显示
        if (completedTasksCount >= starImages.Length)
        {
            return;
        }

        // 更新剩余星星的显示为状态一的精灵
        for (int i = completedTasksCount; i < starImages.Length; i++)
        {
            starImages[i].sprite = starSprites[0]; // 设置为状态一的Sprite
        }
    }

    // 重置任务，将星星的状态恢复为初始状态
    public void ResetTasks()
    {
        completedTasksCount = 0; // 重置完成的任务数量为零
        // 更新星星的显示为状态一的精灵
        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].sprite = starSprites[0]; // 设置为状态一的Sprite
        }
    }
}
