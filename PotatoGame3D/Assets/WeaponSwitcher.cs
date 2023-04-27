using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public int activeWeaponIndex = 0;
    private Gun[] weapons;


    // Start is called before the first frame update
    void Start()
    {
        // get all the Gun scripts on child objects
        weapons = GetComponentsInChildren<Gun>();

        // disable all weapons except the first one
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == 0)
            {
                weapons[i].isActive = true;
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].isActive = false;
                weapons[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // switch to the next weapon when the 1 or 2 key is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }

        // show the weapon switch menu when the keys are held down
        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha2))
        {
            ShowWeaponMenu();
        }
    }

    void SwitchWeapon(int index)
    {
        // disable the current weapon model and enable the new one
        weapons[activeWeaponIndex].gameObject.SetActive(false);
        weapons[activeWeaponIndex].isActive = false;
        weapons[index].gameObject.SetActive(true);
        weapons[index].isActive = true;
        activeWeaponIndex = index;
    }

    void ShowWeaponMenu()
    {
        // show the weapon switch menu here
    }
}