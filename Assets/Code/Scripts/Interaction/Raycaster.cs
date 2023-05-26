using UnityEngine;
using UnityEngine.InputSystem;

public class Raycaster : MonoBehaviour
{
    private RaycastHit _hit;
    public RaycastHit Hit { get => _hit; set => _hit = value; }

    void Update()
    {
        CameraRaycast(out _hit);
        // if (_hit.transform != null)
        //     Debug.Log(_hit.transform.name);
    }

    bool CameraRaycast(out RaycastHit hit)
    {
        Vector3 origin = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        Vector3 direction = Camera.main.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, 5000));

        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(origin, direction, Color.blue);
        return Physics.Raycast(ray, out hit);
    }
}
