using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;
    public float targetZoom;
    private float ZoomFactor = 3f;
    private float zoomLerpSpeed = 10f;
    private int pos = 66;
    public GameObject frameToScale;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = new Vector3(-66, -66, 0);
        transform.position = startPos;
        targetZoom = virtualCamera.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float scroolData;
        scroolData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scroolData * ZoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 4f, 15f);
        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);

        CameraMovement();
        CheckBorders();
        frameToScale.transform.localScale = new Vector3(targetZoom, targetZoom, targetZoom);

    }
    private void CameraMovement()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1f;
        }

        float moveSpeed = 20f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
    private void CheckBorders()
    {
        if (this.gameObject.transform.position.x <= -pos)
        {
            transform.position = new Vector2(-pos, transform.position.y);
        }
        if (this.gameObject.transform.position.y <= -pos)
        {
            transform.position = new Vector2(transform.position.x, -pos);
        }
        if (this.gameObject.transform.position.x >= pos)
        {
            transform.position = new Vector2(pos, transform.position.y);
        }
        if (this.gameObject.transform.position.y >= pos)
        {
            transform.position = new Vector2(transform.position.x, pos);
        }
    }

}
