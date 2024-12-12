using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionManager : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    private Transform mouseTransform;
    // Start is called before the first frame update
    void Start()
    {
        mouseTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseTransform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(rotZ - 90, Vector3.forward);

        mouseTransform.rotation = rotation;
    }
}
