using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// this portal script will allow any traveler to touch it, then it will send them to a specified location in a specified scene.
public class PortalTravel : MonoBehaviour
{

    // ------ this portal leads to the scene with the same name as its tag, to a portal with the same tag as this one. ------- //
    // target scene
    // target location within scene
    // who can travel?

    //[SerializeField]
    //string targetScene;

    public string targetPortal = "";

    public Animator musicAnim;
    public Animator sceneTransition;
    public float waitTime;
    public float crossfadeTime;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.
        Traveller trav = collision.GetComponent<Traveller>();
        if(trav != null)
        {
            Debug.Log("Portal Warping: " + trav.gameObject.name);
            trav.SetSpawn(targetPortal);
            StartCoroutine(ChangesScenesMusicTransition());
            StartCoroutine(ChangeScenesCrossFade());
            //SceneManager.LoadScene(tag, LoadSceneMode.Single);
        }    
    }
    IEnumerator ChangesScenesMusicTransition()
    {
        musicAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(waitTime);
        //SceneManager.LoadScene(tag, LoadSceneMode.Single);
    }

    IEnumerator ChangeScenesCrossFade()
    {
        sceneTransition.SetTrigger("Start");
        yield return new WaitForSeconds(crossfadeTime);
        SceneManager.LoadScene(tag, LoadSceneMode.Single);
    }


}
