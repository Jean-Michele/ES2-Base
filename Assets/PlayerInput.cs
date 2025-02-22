using System.Collections;
using System.Collections.Generic;

using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _mouvement;
    private Rigidbody _sub;
    private Vector3 directionInput;
    private Animator _animator;
    private bool speed = false;

    void Start()
    {
        _sub = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void OnInputDuJoueur(InputValue directionBase)
    {
        Vector2 directionAvecVitesse = directionBase.Get<Vector2>() * _mouvement;
        directionInput = new Vector3(0f, directionAvecVitesse.x, directionAvecVitesse.y);       
        _animator.SetFloat("Haut/Bas", 1f *  directionAvecVitesse.x);
        _animator.SetFloat("Avant/Arriere", 1f * directionAvecVitesse.y);
    }

    
    void FixedUpdate()
    {
        Vector3 mouvement = directionInput.normalized * _mouvement;
        
        if (Keyboard.current.shiftKey.isPressed)
            {
                _mouvement = 8;
            }
        
        else{
            _mouvement = 4;
        }
        _sub.velocity = mouvement;
       
    }
}
