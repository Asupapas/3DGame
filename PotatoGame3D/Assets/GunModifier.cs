using UnityEngine;

public class GunModifier : MonoBehaviour
{
    public float shootDelay = 0.2f; // the time delay between shots
    private float shootTimer = 0f; // the time remaining until the next shot can be fired
    private RaycastShooting gunScript; // reference to the RaycastShooting script on the gun

    private void Start()
    {
        gunScript = GetComponent<RaycastShooting>();
    }

    private void Update()
    {
        if (shootTimer > 0f)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (gunScript.currentAmmo >= 1 && shootTimer <= 0f)
        {
            gunScript.currentAmmo--;
            gunScript._input.shoot = false;

            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
                }
            }

            shootTimer = shootDelay;
        }
    }
}
