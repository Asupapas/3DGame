using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int maxAmmo = 30;
    public int currentAmmo;
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    public float bulletSpeed = 600;
    public bool isActive = false; // new variable to indicate if the weapon is active

    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        // only update the gun if it is active
        if (isActive)
        {
            if (_input.shoot && currentAmmo >= 1)
            {
                Shoot();
                _input.shoot = false;
                currentAmmo--;
            }
            if (_input.reload)
            {
                Reload();
                _input.reload = false;
            }
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot!");
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bullet, 1);
    }

    void Reload()
    {
        currentAmmo = maxAmmo;
    }
}
