using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [Header("Obstacle Fields")]
    [SerializeField] protected bool _isActivated = true;
    [SerializeField] protected float _speed = 5f;
}
