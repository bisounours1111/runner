using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public GameObject[] childs;
    void Start()
    {
        childs = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            FixedJoint joint = childs[i].GetComponent<FixedJoint>();
            joint.connectedBody = childs[(i + 1) % transform.childCount].GetComponent<Rigidbody>();
            joint.breakForce = 100;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
