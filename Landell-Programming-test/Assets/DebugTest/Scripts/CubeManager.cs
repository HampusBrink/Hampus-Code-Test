using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject Cube;

    private void Update()
    {
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        Instantiate(Cube, new Vector3(new Random().Next(0,500),new Random().Next(0,500),new Random().Next(0,500)),Quaternion.identity);

        yield return new WaitForFixedUpdate();
    }
}
