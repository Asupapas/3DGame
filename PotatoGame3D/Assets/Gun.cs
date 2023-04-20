using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

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
    // Start is called before the first frame update
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_input.shoot)
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
}
