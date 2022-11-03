using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tutorial from :https://www.youtube.com/watch?v=SLAYPZ7lukY&t=669s
public class ManagerIK : MonoBehaviour
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

        //Dummy pivot
        objPivot = new GameObject("DummyPivot");
        objPivot.transform.parent = transform.parent;
        objPivot.transform.localPosition = new Vector3(0, 1.458f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // target position 1
        objPivot.transform.LookAt(objTarget);
        float pivotRotY = objPivot.transform.localRotation.y;
        //Debug.Log(pivotRotY);

        float dist = Vector3.Distance(objPivot.transform.position, objTarget.position);
        //Debug.Log(dist);

        if(((-0.2f > pivotRotY && pivotRotY > -0.860f) || (pivotRotY>0.866f && pivotRotY < 0.95f)) && dist<disireDist)
        {
            lookAtWeight = Mathf.Lerp(lookAtWeight, 1, Time.deltaTime*2.5f);


        }
        else
        {
            lookAtWeight = Mathf.Lerp(lookAtWeight, 0, Time.deltaTime * 2.5f);
        }

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
