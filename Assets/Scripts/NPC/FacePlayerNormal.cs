using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for normal NPC without cutscene required, will need to modify in the future, the same as FacePlayer.cs
public class FacePlayerNormal : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // learnt from https://blog.csdn.net/Vitens/article/details/104597757?spm=1001.2101.3001.6650.10&utm_medium=distribute.pc_relevant.none-task-blog-2%7Edefault%7ECTRLIST%7ERate-10-104597757-blog-78895703.pc_relevant_aa_2&depth_1-utm_source=distribute.pc_relevant.none-task-blog-2%7Edefault%7ECTRLIST%7ERate-10-104597757-blog-78895703.pc_relevant_aa_2&utm_relevant_index=11
        Vector3 dir = player.transform.position - transform.position;
        dir = new Vector3(dir.x, 0, dir.z);
        transform.rotation = Quaternion.LookRotation(dir);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }
}
