using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class WeaponSwitchingScript : MonoBehaviour
{
    public List<GameObject> weapons;
    private int currentWeaponIndex = 0;

    private void Start()
    {
        SetActiveWeapon(currentWeaponIndex);
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon(0);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon(1);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveWeapon(2);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetActiveWeapon(3);
        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetActiveWeapon(4);
        }
    }

    private void SetActiveWeapon(int index)
    {
        // Disable all weapons
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }

        // Enable the selected weapon
        weapons[index].SetActive(true);

        // Update the current weapon index
        currentWeaponIndex = index;

        // Update the ammo of the selected weapon
        UpdateAmmo();
    }

    private void UpdateAmmo()
    {
        // Update the current ammo of the selected weapon
        foreach (GameObject weapon in weapons)
        {
            if (weapon.activeSelf)
            {
                weapon.GetComponent<RaycastShooting>().isActive = true;
            }
            else
            {
                weapon.GetComponent<RaycastShooting>().isActive = false;
            }
        }
    }
}

