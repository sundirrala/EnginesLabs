using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    float moveSpeed = 1;

    [SerializeField]
    Rigidbody2D rigidBod;

    //[SerializeField]
    //LayerMask grass;
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
        ///*RandomBattleEncounters*/();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(Random.Range(1, 101) <= 20)
        {
            SceneManager.LoadScene("GrassBattle");
        }
    }

    //private void RandomBattleEncounters()
    //{
    //    if(Physics2D.OverlapCircle(transform.position, 0.2f, grass))
    //    {
    //        if (Random.Range(1, 101) <= 50)
    //        {
    //            SceneManager.LoadScene("GrassBattle");
    //        }
    //    }
    //}
}
