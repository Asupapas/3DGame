using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilScript : MonoBehaviour
{
    public GameObject Gun;
    private Animator gunAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component of the gun GameObject
        gunAnimator = Gun.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartRecoil());
        }
    }

    IEnumerator StartRecoil()
    {
        // Set the "Recoil" trigger parameter to true
        gunAnimator.SetTrigger("Recoil");

        // Wait for the "Recoil" animation state to finish playing
        while (gunAnimator.GetCurrentAnimatorStateInfo(0).IsName("Recoil"))
        {
            yield return null;
        }

        // Set the "Recoil" trigger parameter to false to return to the default animation state
        gunAnimator.SetTrigger("Recoil");
    }
}
