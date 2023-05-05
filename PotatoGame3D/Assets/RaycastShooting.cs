using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class RaycastShooting : MonoBehaviour
{
    public int maxAmmo = 30;
    public int currentAmmo;
    public StarterAssetsInputs _input;
    public bool isActive = false;
    private GunModifier gunModifier;

    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        gameObject.SetActive(isActive); // enable or disable the weapon game object based on isActive
        gunModifier = GetComponent<GunModifier>();
    }

    void Update()
    {
        gameObject.SetActive(isActive); // enable or disable the weapon game object based on isActive

        RaycastHit hit;
        gameObject.SetActive(isActive); // enable or disable the weapon game object based on isActive

        if (_input.shoot)
        {
            gunModifier.Shoot();
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
        gunModifier.Reload();
    }
}

