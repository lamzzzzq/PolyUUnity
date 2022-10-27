using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tutorial from :https://www.youtube.com/watch?v=SLAYPZ7lukY&t=669s
public class ManagerIKFather : MonoBehaviour
{

    Animator animator;
    public bool ikActive = false;
    public Transform objTarget;
    public float lookAtWeight;
    public float disireDist;


    //dummy pivot
    GameObject objPivot;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnAnimatorIK()
    {
        if(animator)
        {
            if(ikActive)
            {
                if(objTarget!=null)
                {
                    animator.SetLookAtWeight(lookAtWeight);
                    animator.SetLookAtPosition(objTarget.position);
                }
                else
                {
                    animator.SetLookAtWeight(0);
                }
            }
        }
    }
}
