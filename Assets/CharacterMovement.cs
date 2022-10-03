using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    float moveSpeed = 1;

    [SerializeField]
    Rigidbody2D rigidBod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 currentPosition = transform.position;

        rigidBod.MovePosition(currentPosition + new Vector3(inputX, inputY, 0) * moveSpeed * Time.deltaTime);

        // everything in c# is a reference

        // transform.position = currentPosition + new Vector3(inputX, inputY, 0) * moveSpeed * Time.deltaTime; //

        // no such thing as namespaces in c#, just put things in classes
    }
}
