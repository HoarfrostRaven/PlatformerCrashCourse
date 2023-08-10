using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private float _maxHealth = 100;
    public float MaxHealth
    {
        get { return _maxHealth;}
        set { _maxHealth = value; }
    }

    private float _health = 100;
    public float Health
    {
        get { return _health;}
        set 
        { 
            _health = value;

            // If health drops below 0, character is no longer alive
            if(_health < 0)
            {
                IsAlive = false;
            }
        }
    }

    private bool _isAlive = true;
    public bool IsAlive
    {
        get { return _isAlive;}
        set 
        { 
            _isAlive = value;
            animator.SetBool(AnimationStrings.IsAlive, value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
