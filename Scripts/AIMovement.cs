using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 2f;
    public float rotateSpeed = 0.5f;
    public Vector3 originalTarget;
    private bool inCombat = false;
    private Transform target;
    public bool targetReached;
    private Transform previosTarget;

    public void SetTarget(Vector3 targetPosition)
    {
        if (target != null)
        {
            previosTarget = target;
        }
        GameObject newTargetObject = new GameObject();
        newTargetObject.transform.position = targetPosition;
        target = newTargetObject.transform;
        //target = new GameObject().transform;
        //target.position = targetPosition;
        //previosTarget = target;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalTarget = target.position;
        if (gameObject.tag == "Cruiser_Red")
        {
            speed = 3f;
        }
        if (gameObject.tag == "Fighter_Red")
        {
            speed = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target != null)
        {
            Vector3 rotation = target.position - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if (gameObject.tag == "BattleShip_Red")
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rotZ - 90), rotateSpeed * Time.deltaTime);
            }
            if (gameObject.tag == "Cruiser_Red")
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rotZ - 90), rotateSpeed * Time.deltaTime * 2f);
            }
            if (gameObject.tag == "Fighter_Red")
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rotZ - 90), rotateSpeed * Time.deltaTime * 10f);
            }
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                previosTarget = target;
                Destroy(previosTarget.gameObject);
                targetReached = true;
            }
            
        }
    }
    public bool InCombat
    {
        get { return inCombat; }
        set
        { 
            inCombat = value;
            if (!inCombat)
            {
                SetTarget(originalTarget);
            }
        }
    }


}
