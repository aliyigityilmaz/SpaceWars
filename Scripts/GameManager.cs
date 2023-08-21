using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject RedBase;
    public GameObject BlueBase;
    public float timer;
    public float destoryTime = 0.5f;
    public GameObject BlueWins;
    public GameObject RedWins;
    public AudioSource bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        RedBase.SetActive(true);
        BlueBase.SetActive(true);
        BlueWins.SetActive(false);
        RedWins.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (RedBase == null)
        {
            BlueWins.SetActive(true);
        }
        if (BlueBase == null)
        {
            RedWins.SetActive(true);
        }
    }

}
