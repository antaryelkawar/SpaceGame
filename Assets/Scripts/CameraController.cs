using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        float player_x = player.transform.position.x;
        float player_y = player.transform.position.y;

        float rounded_x = RoundToNearestPixel(player_x);
        float rounded_y = RoundToNearestPixel(player_y);
        Vector3 new_pos = new Vector3(rounded_x, rounded_y, -10.0f);
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

    public float pixelToUnits = 40f;

    public float RoundToNearestPixel(float unityUnits)
    {
        float valueInPixels = unityUnits * pixelToUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float roundedUnityUnits = valueInPixels * (1 / pixelToUnits);
        return roundedUnityUnits;
    }
}
