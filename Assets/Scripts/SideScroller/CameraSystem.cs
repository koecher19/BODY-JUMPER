using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    /*
     * camera moves with the player
     * also has parameters to limit the camera movement
     */
    private GameObject player;
    public bool moveWithPlayer;

    // following variables clamp camera into position: camera cant move outside of these parameters
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame (at the end of the update cycle)
    void LateUpdate()
    {
        if (this.moveWithPlayer)
        {
            this.moveCamWithPlayer();
        }

    }

    void moveCamWithPlayer()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
