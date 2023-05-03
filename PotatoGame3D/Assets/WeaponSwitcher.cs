using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int currentWeaponIndex = 0;
    [SerializeField] private StarterAssetsInputs _input;
    [SerializeField] private List<RaycastShooting> weapons;

    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        SelectWeapon(currentWeaponIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (_input == null)
        {
            Debug.LogWarning("StarterAssetsInputs is missing from the root GameObject.");
            return;
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && i < weapons.Count)
            {
                SelectWeapon(i);
                break;
            }
        }
    }

    void SelectWeapon(int index)
    {
        if (index < 0 || index >= weapons.Count)
        {
            Debug.LogWarning("Invalid weapon index.");
            return;
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].isActive = (i == index) && (!weapons[i].isActive); // activate only if not already active
        }

        currentWeaponIndex = index;
        Debug.Log("Selected weapon: " + weapons[index].name);
    }
}
