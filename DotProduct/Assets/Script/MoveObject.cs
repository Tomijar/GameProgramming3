using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public GameObject wall1;
    public GameObject wall2;

    private Vector3 direction;
    private GameObject currentTarget;

    void Start()
    {
        SwitchTarget();
    }

    void Update()
    {

        transform.Translate(direction * speed * Time.deltaTime);

        //checking for a hit on current target using dotProduct
        float dotProduct = Vector3.Dot(direction.normalized, currentTarget.transform.position - transform.position);

        // changing target to next wall after hitting 
        if (dotProduct <= 0) SwitchTarget();
    }
    private void SwitchTarget()
    {
        if (currentTarget == wall1)
        {
            currentTarget = wall2;
        }
        else
        {
            currentTarget = wall1;
        }
        SetDirection();
    }

    void SetDirection()
    {
        direction = currentTarget.transform.position - transform.position;
    }
}
