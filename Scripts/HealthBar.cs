using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;

    private void Start()
    {
        camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        healthSlider.transform.rotation = camera.transform.rotation;
        healthSlider.transform.position = target.position + offset;
    }
    public void UpdateHealth(float health, float maxHealth)
    {
        healthSlider.value = health / maxHealth;
        if (health >= maxHealth)
        {
            healthSlider.gameObject.SetActive(false);
        }
        else
        {
            healthSlider.gameObject.SetActive(true);
        }

    }
}
