using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _mouvement;
    private Rigidbody _sub;
    private Vector3 directionInput;
    private Animator _animator;

    void Start()
    {
        _sub = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void OnInputDuJoueur(InputValue directionBase)
    {
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _mouvement;
        directionInput = new Vector3(0f, directionAvecVitesse.x, directionAvecVitesse.y);
    }
    void FixedUpdate()
    {
        Vector3 mouvement = directionInput.normalized * _mouvement;
        _sub.velocity = mouvement;
    }
}
