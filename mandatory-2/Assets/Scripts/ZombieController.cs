using System;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("Ball"))
        {
            _animator.SetBool("isDead", true);
        }
    }
}
