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
    private void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }
    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (_input.shoot && currentAmmo >= 1)
            {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if(Physics.Raycast(ray, out hit))
            {
                _input.shoot = false;
                currentAmmo--;
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    //DO DAMAGE
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                }

            }

        }
        if (_input.reload)
        {
            Reload();
            _input.reload = false;
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit)) { if (hit.collider.gameObject.tag == "Tagged") { Debug.DrawRay(transform.position, transform.forward, Color.green); print("Hit"); } }
    }
    void Reload()
    {
        currentAmmo = maxAmmo;
    }
}
