using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    #region physics_vars
    Rigidbody2D plat;
    #endregion

    #region movment_vars
    [SerializeField]
    private float distance;
    [SerializeField]
    private float speed;
    private Vector3 myTargetPosition;
    private float Timeelapsed;
    #endregion

    #region booleans
    [SerializeField]
    private bool has_H_move;
    private bool is_returning;
    private bool is_moving;
    [SerializeField]
    private bool rigidbod;
    #endregion

    #region Unity_functions
    private void Start()
    {
        if (rigidbod)
        {
            plat = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        move();
    }
    #endregion

    #region movment_funct
    private void move()
    {
        if (is_returning)
        {
            StartCoroutine(returning());
        }
        else
        {
            StartCoroutine(reaching());
        }
    }

    IEnumerator returning()
    {
        Timeelapsed = 0f;
        if (has_H_move) {
            myTargetPosition = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);
        }
        else
        {
            myTargetPosition = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
        }
        while (transform.position != myTargetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, myTargetPosition, Timeelapsed / speed);
            Timeelapsed += Time.deltaTime;
            Debug.Log(myTargetPosition.x);
            Debug.Log(transform.position.x);
            yield return null;
        }
        is_returning = false;
    }


    IEnumerator reaching()
    {
        Timeelapsed = 0f;
        if (has_H_move)
        {
           myTargetPosition = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }
        else
        {
           myTargetPosition = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
        }
        while (transform.position != myTargetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, myTargetPosition, Timeelapsed / speed);
            Timeelapsed += Time.deltaTime;
            Debug.Log(myTargetPosition.x);
            Debug.Log(transform.position.x);
            yield return null;
        }
        is_returning = true;
    }

    #endregion

}
