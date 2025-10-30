#pragma warning disable IDE0051

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerCtrl : MonoBehaviour
{
    Animator anim;
    new Transform transform;
    Vector3 moverDir;

    void Start()
    {
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (moverDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moverDir);
            transform.Translate(Vector3.forward * Time.deltaTime * 4.0f);
        }
    }
    void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>();
        moverDir = new Vector3(dir.x, 0, dir.y);
        anim.SetFloat("Movement", dir.magnitude);
        Debug.Log($"Move = ({dir.x}, {dir.y})");
    }

    void OnAttack()
    {
        Debug.Log("Attack");
        anim.SetTrigger("Attack");
    }
}
