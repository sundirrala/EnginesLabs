using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traveller : MonoBehaviour
{
    private string lastSpawn = "";
    public void SetSpawn(string spawn)
    {
        lastSpawn = spawn;
    }
    private void Start()
    {
#if UNITY_EDITOR // this is a convenience function only to be used while we keep Player Characters in all the scenes
        EditorKillClones();
#endif

        DontDestroyOnLoad(this); // this tells unity that this gameobject should not be cleaned up with all the others when changing scenes

        SceneManager.sceneLoaded += OnSceneLoadedAction;

        void OnSceneLoadedAction(Scene scene, LoadSceneMode loadMode)
        {
            if(lastSpawn != "")
            {
                bool transportSuccessful = false;
                // -- go through all the spawn locations to find the one given
                PlayerSpawn[] spawnPoints = FindObjectsOfType<PlayerSpawn>(); // will return an array
                foreach(PlayerSpawn spawn in spawnPoints)
                {
                    if(spawn.name == lastSpawn)
                    {
                        // go to that spawn point
                        transform.position = spawn.transform.position;
                        transportSuccessful = true;
                        break;
                    }
                }

                if(!transportSuccessful)
                {
                    throw new System.Exception("Cound not find spawn point" + lastSpawn);
                }
            }
        }
    }

    private void EditorKillClones()
    {
        if (PlayerSpawn.Player != GetComponent<CharacterMovement>())
        {
            // ---- not original, d i e c l o n e s !
            Destroy(this);
        }

    }
}
