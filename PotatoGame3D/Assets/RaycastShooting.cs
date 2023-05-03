using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class RaycastShooting : MonoBehaviour
{
    public int maxAmmo = 30;
    public int currentAmmo;
    private StarterAssetsInputs _input;
    public bool isActive = false;

    private void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        gameObject.SetActive(isActive); // enable or disable the weapon game object based on isActive
    }

    void Update()
    {
        gameObject.SetActive(isActive); // enable or disable the weapon game object based on isActive

        RaycastHit hit;
        if (_input.shoot && currentAmmo >= 1)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                _input.shoot = false;
                currentAmmo--;
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                }
            }
        }
        if (_input.reload)
        {
            Reload();
            _input.reload = false;
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            string tag = hit.collider.gameObject.tag;
            if (tag == "Tagged")
            {
                Debug.DrawRay(transform.position, transform.forward, Color.green);
                Debug.Log("Hit object with tag: " + tag);
            }
        }
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
    }
}

