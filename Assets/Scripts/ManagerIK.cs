using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerIK : MonoBehaviour
{

    Animator animator;
    public bool ikActive = false;
    public Transform objTarget;
    public float lookAtWeight;

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
        objPivot.transform.LookAt(objTarget);
        float pivotRotY = objPivot.transform.localRotation.y;
        //Debug.Log(pivotRotY);
        if((-0.07f > pivotRotY && pivotRotY > -0.859f) || (pivotRotY>0.866f && pivotRotY < 0.993f))
        {
            lookAtWeight = Mathf.Lerp(lookAtWeight, 1, Time.deltaTime);


        }
        else
        {
            lookAtWeight = 0f;
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
