using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Starting position for the parallax game object
    Vector2 startingPosition;

    // Start Z value of the parallax game object
    // Z alue is the distance into the background
    float startingZ;

    // Distance that the camera has moved from the starting position of the parallax game object
    // => means it updates on every frame
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // If the parallax game object is in front of the player, use nearClipPlane, otherwise use farClipPlane
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // The futher the object from the player, the faster the parallax game object will move
    // Drag it's Z value closer to hte target to make it move slower
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        // transform.position is Vector3, but the z-axis will be shaved off automatically
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
