using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{

    public static List<ClickToMove> moveableObject = new List<ClickToMove>();
    public float speed =2f;
    public float rotateSpeed = 0.5f;
    private Vector3 target;
    public bool selected;
    private bool canRotate;
    public GameObject selectedCircle;
    private Vector3 mousePressPos;
    private Vector3 mouseCurrentPos;

    private bool isSelecting = false;
    // Start is called before the first frame update
    void Start()
    {
        selectedCircle.SetActive(false);
        selected = false;
        moveableObject.Add(this);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveControls();
        if (Input.GetMouseButtonDown(0))
        {
            mousePressPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePressPos.z = 0;

            isSelecting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
            CheckSelection();
        }
        if (isSelecting)
        {
            mouseCurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseCurrentPos.z = 0;
        }



        if (selected)
        {
            selectedCircle.SetActive(true);
        }
        else
        {
            selectedCircle.SetActive(false);
        }

    }
    private void CheckSelection()
    {
        Vector3 mouseReleasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseReleasePos.z = 0;

        float minX = Mathf.Min(mousePressPos.x, mouseReleasePos.x);
        float maxX = Mathf.Max(mousePressPos.x, mouseReleasePos.x);
        float minY = Mathf.Min(mousePressPos.y, mouseReleasePos.y);
        float maxY = Mathf.Max(mousePressPos.y, mouseReleasePos.y);

        foreach (ClickToMove obj in moveableObject)
        {
            Vector3 objPos = obj.transform.position;

            if (objPos.x > minX && objPos.x < maxX && objPos.y > minY && objPos.y < maxY)
            {
                obj.selected = true;
            }
            
        }
    }

    private void OnMouseDown()
    {
        selected = true;
        foreach (ClickToMove obj in moveableObject)
        {
            if (!Input.GetKey(KeyCode.LeftControl))
            {
                if (obj != this)
                {
                    obj.selected = false;
                }
            }
        }
    }


    private void MoveControls()
    {
        if (gameObject.layer == 6)
        {
            if (Input.GetMouseButtonDown(1) && selected)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                canRotate = true;
                target.z = transform.position.z;
            }
            if (canRotate)
            {
                Vector3 rotation = target - transform.position;
                float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
                if (gameObject.tag == "Battleship")
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rotZ - 90), rotateSpeed * Time.deltaTime);
                }
                if (gameObject.tag == "Cruiser")
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rotZ - 90), rotateSpeed * Time.deltaTime * 2f);
                }
                if (gameObject.tag == "Fighter")
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rotZ - 90), rotateSpeed * Time.deltaTime * 10f);
                }
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
            }
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (this.transform.position == target)
            {
                canRotate = false;
            }
        }

    }
}
