using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _victoryObject;


    private void OnTriggerEnter(Collider other)
    {
        _victoryObject.SetActive(true);
    }
}
