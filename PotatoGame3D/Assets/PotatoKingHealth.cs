using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotatoKingHealth : MonoBehaviour
{
    public int maxHp = 10;
    public int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Defeated();
        }
    }

    private void Defeated()
    {
        SceneManager.LoadScene("Ending");
    }

    
}
