using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPositionScript : MonoBehaviour
{
    public GameObject player;
    public float playerXpos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.playerXpos = this.player.gameObject.transform.position.x;
        this.gameObject.transform.position = new Vector3(this.playerXpos, this.transform.position.y, 0.0f);
    }
}
