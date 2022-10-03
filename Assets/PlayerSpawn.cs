using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    private static CharacterMovement player = null;
    public static CharacterMovement Player
    {
        get { return player; }
        private set { }
    }

    void Awake()
    {
        if(player == null)
                {
            GameObject newObject = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player = newObject.GetComponent<CharacterMovement>();
        }
    }
}
