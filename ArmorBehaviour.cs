using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArmorBehaviour : MonoBehaviour
{
    
    public   int _ArmorValue;

    

    private Health Picker;
    private HealthP2 Picker2;
    private bool _PickedUp = false;
    private int maxArmor = 50;

    private int waitTime = 10;

    private IEnumerator coroutine;
    private GameObject  PickUp;
    private SpriteRenderer sprt;
    private CircleCollider2D col;

    private void Start()
    {
        col = GetComponent<CircleCollider2D>();
        sprt = GetComponent<SpriteRenderer>();
        PickUp = gameObject;
        Picker = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Picker = collision.GetComponent<Health>();
        Picker2 = collision.GetComponent<HealthP2>();
        //if (collision.tag == "Armor" && _Armor != 150)
        //{
        //    _Armor += _ArmorValue;
        //}
        if (collision.GetComponent<Health>() != null && Picker._armor != maxArmor)
        {
            Picker._armor += _ArmorValue;
            
            Debug.Log(_PickedUp);
            Picked();
            InitRespawn();


        }
        if (collision.GetComponent<HealthP2>() != null && Picker2._armor != maxArmor)
        {
            Picker2._armor += _ArmorValue;

            Debug.Log(_PickedUp);
            Picked();
            InitRespawn();


        }
    }
    private void Update()
    {
        

       


    }
    private void InitRespawn()
    {
        StartCoroutine(Respawner(PickUp, waitTime));
    }
    private void Picked()
    {   if(_PickedUp == false)
        {
            _PickedUp = true;
            sprt.enabled = false;
            col.enabled = false;
        }
       
        
    }

    private IEnumerator Respawner(GameObject gameObject,float waitTime)
    {
        while (_PickedUp == true)
        {
            yield return new WaitForSeconds(waitTime);
            sprt.enabled = true;
            col.enabled = true;
            _PickedUp = false;
        }
        
           

        
          
       
    }
    // Start is called before the first frame update

}
