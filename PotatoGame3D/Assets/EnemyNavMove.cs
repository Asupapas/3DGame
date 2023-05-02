using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMove : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.position;
    }
}
