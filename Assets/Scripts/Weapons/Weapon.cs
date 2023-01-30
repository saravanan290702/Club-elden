using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator anim;
    private GameObject baseGameObject;

    private void Awake()
    {
        baseGameObject = transform.Find("Base").gameObject;
        anim = baseGameObject.GetComponent<Animator>();
    }
    public void Enter()
    {
        anim.SetBool("active", true);
        //Debug Statement
        print($"{transform.name} enter");
    }
}
