using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera mainCamera;
    [HideInInspector]Vector3 mainCameraInitialPosititon;
    [HideInInspector]bool destroyTimerActive = false;
    public float TimeToDespawnArrow;
    // Start is called before the first frame update
    void Start()
    {
        mainCameraInitialPosititon = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = this.transform.position;
        currentPosition.z = mainCameraInitialPosititon.z;
        mainCamera.transform.position = currentPosition;
        this.transform.rotation = LookAtTarget(this.transform.position);

        if (destroyTimerActive)
        {
            TimeToDespawnArrow -= Time.deltaTime;

            if(TimeToDespawnArrow < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    private void OnDestroy()
    {
        mainCamera.transform.position = mainCameraInitialPosititon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this will make the object freeze, start countdown from now on (cca 3s) and then destroy the arrow
        destroyTimerActive = true;
    }
}
