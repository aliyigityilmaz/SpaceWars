using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private GameObject parentShip;
    private bool isSelected;
    public float moveSpeed = 5f;
    public float rotationSpeed = 1f;
    public GameObject blueLaser;
    public GameObject redLaser;
    public AudioSource laserSound;
    public LayerMask targetLayer;
    public Transform closestTarget;
    public Transform laserPos;
    public Transform secondLaserPos;
    private float timer;
    private AIMovement moveSpeedAI;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeedAI = FindObjectOfType<AIMovement>();
        parentShip = transform.root.gameObject;
        if (moveSpeedAI == null)
        {
            Debug.Log("Not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        if (closestTarget != null)
        {
            RotateTurret();
        }
        timer += Time.deltaTime;
        isSelected = parentShip.GetComponent<ClickToMove>().selected;
        if (timer > 1)
        {
            if (gameObject.layer == LayerMask.NameToLayer("BlueTeam"))
            {
                if (closestTarget!=null)
                {
                    float dist = Vector3.Distance(closestTarget.position, transform.position);
                    if (dist < 30)
                    {
                        laserPos.transform.rotation = gameObject.transform.rotation;
                        Instantiate(blueLaser, laserPos.position, transform.rotation);
                        laserSound.Play();
                        
                        if (secondLaserPos)
                        {
                            secondLaserPos.transform.rotation = gameObject.transform.rotation;
                            Instantiate(blueLaser, secondLaserPos.position, transform.rotation);
                            laserSound.Play();
                        }
                        LaserScript laserComponent = blueLaser.GetComponent<LaserScript>();

                        timer = 0;
                    }
                }
                
                

            }
            if (gameObject.layer == LayerMask.NameToLayer("RedTeam"))
            {
                
                if (closestTarget != null)
                {
                    float dist = Vector3.Distance(closestTarget.position, transform.position);
                    if (dist < 30)
                    {
                        
                        laserPos.transform.rotation = gameObject.transform.rotation;
                        Instantiate(redLaser, laserPos.position, transform.rotation);
                        laserSound.Play();
                        if (secondLaserPos)
                        {
                            secondLaserPos.transform.rotation = gameObject.transform.rotation;
                            Instantiate(redLaser, secondLaserPos.position, transform.rotation);
                            laserSound.Play();
                        }
                        
                        
                        LaserScript laserComponent = redLaser.GetComponent<LaserScript>();

                        
                        timer = 0;
                    }
                    if (dist < 15)
                    {
                        moveSpeedAI.speed = 0f;
                    }
                }
                else
                {
                    if (moveSpeedAI.gameObject.tag == "Cruiser_Red")
                    {
                        moveSpeedAI.speed = 3f;
                    }
                    if (moveSpeedAI.gameObject.tag == "Fighter_Red")
                    {
                        moveSpeedAI.speed = 5f;
                    }
                    if (moveSpeedAI.gameObject.tag == "BattleShip_Red")
                    {
                        moveSpeedAI.speed = 2f;
                    }
                }

            }

        }
    }

    
    public void FindClosestTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll((Vector2)transform.position, 10f, targetLayer);

        float shortestDistance = Mathf.Infinity;
        Transform newClosestTarget = null;

        foreach (Collider2D target in targets)
        {
            float distanceToTarget = Vector2.Distance((Vector2)transform.position, target.transform.position);
            if (distanceToTarget < shortestDistance)
            {
                shortestDistance = distanceToTarget;
                newClosestTarget = target.transform;
            }
        }
        closestTarget = newClosestTarget;
    }
    private void RotateTurret()
    {
        float dist = Vector3.Distance(closestTarget.position, transform.position);
        if (dist < 30)
        {
            Vector2 targetDirection = closestTarget.position - transform.position;
            float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle - 90f));
            transform.rotation = targetRotation; // Set the rotation directly
        }
    }

}
