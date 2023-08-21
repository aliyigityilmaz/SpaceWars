using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public Material defaultColor;
    public Material RedTeamColor;
    public Material BlueTeamColor;
    public bool RedWinning;
    public bool BlueWinning;
    [SerializeField]
    private int Redcount;
    [SerializeField]
    private int Bluecount;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material = this.defaultColor;
        Redcount = 0;
        Bluecount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log(gameObject.name);
            Redcount++;
            if (Redcount > Bluecount)
            {
                this.gameObject.GetComponent<Renderer>().material = RedTeamColor;
                RedWinning = true;
                BlueWinning = false;
            }
        }
        if (collision.gameObject.layer == 6)
        {
            Bluecount++;
            if (Bluecount > Redcount)
            {
                this.gameObject.GetComponent<Renderer>().material = BlueTeamColor;
                BlueWinning = true;
                RedWinning = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Redcount--;
        }
        if (collision.gameObject.layer == 6)
        {
            Bluecount--;
        }
    }
}
