using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject ballPrefab;

    public void Spawner() {
        Instantiate(ballPrefab, transform.position, transform.rotation);
    }
}
