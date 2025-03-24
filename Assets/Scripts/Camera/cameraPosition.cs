using UnityEngine;

public class cameraPosition : MonoBehaviour
{
    public Transform cameraPos;

    // Update is called once per frame
    void Update()
    {
        //keeps camera on the player
        transform.position = cameraPos.position;
    }
}
