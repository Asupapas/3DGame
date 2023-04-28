using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class AutomaticGun : MonoBehaviour
{
    public Transform spawnPoint;
    public float distance = 15f;

    public GameObject muzzle;
    public GameObject impact;

    Camera camera;
    bool isFiring;

    float shootCounter;
    public float rateOfFire = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //shoot input
        if (Input.GetButtonDown("Fire1"))
            isFiring = true;
        else if (Input.GetButtonUp("Fire1"))
            isFiring= false;

        if (isFiring )
        {
            shootCounter = Time.time;

            if (shootCounter > 0)
            {
                shootCounter = rateOfFire;
                Shoot();
            }
            else
                shootCounter = Time.deltaTime;
        }
    }
    // method to shoot
    private void Shoot()
    {
        RaycastHit hit;

        GameObject muzzleInst = Instantiate(muzzle, spawnPoint.position, spawnPoint.rotation);
        muzzleInst.transform.parent = spawnPoint;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }
        else
            Debug.Log("Not hit");
    }
}