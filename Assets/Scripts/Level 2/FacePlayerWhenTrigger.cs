using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayerWhenTrigger : MonoBehaviour
{
    public float sightRadius;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
    }


    public void FacePlayer()
    {
        if(FoundPlayer())
        {
            Vector3 dir = player.transform.position - transform.position;
            dir = new Vector3(dir.x, 0, dir.z);
            transform.rotation = Quaternion.LookRotation(dir);



        }
    }









    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, sightRadius);

        foreach (var target in colliders)
        {
            if (target.CompareTag("SubPlayer"))
            {
                player = target.gameObject.transform;
                return true;
            }
        }
        player = null;
        return false;
    }
}
