using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] int _crossHairSize = 36;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        float posX = _camera.pixelWidth / 2 - _crossHairSize / 8;
        float posY = _camera.pixelHeight / 2 - _crossHairSize / 4;

        GUI.Label(new Rect(posX, posY, _crossHairSize, _crossHairSize), "+");
    }

    private void Update()
    {
        MakeHit();
    }

    void MakeHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }

    IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
