using UnityEngine;

namespace FPController
{
    [RequireComponent(typeof(CharacterController))]
    // ReSharper disable once InconsistentNaming
    public class FPRotation : MonoBehaviour
    {
        private Camera _cam;
        private Vector2 _mouseSensitivity;
        private Vector2 _pitchMinMax;
        private float _yaw;
        private float _pitch;

        private void Awake()
        {
            _cam = GetComponentInChildren<Camera>();
            _mouseSensitivity = new Vector2(5f, 5f);
            _pitchMinMax = new Vector2(-90f, 90f);
        }

        private void Update()
        {
            _yaw += Input.GetAxisRaw("Mouse X") * _mouseSensitivity.x;
            _pitch -= Input.GetAxisRaw("Mouse Y") * _mouseSensitivity.y;

            _pitch = Mathf.Clamp(_pitch, _pitchMinMax.x, _pitchMinMax.y);

            transform.eulerAngles = Vector3.up * _yaw;
            _cam.transform.localEulerAngles = Vector3.right * _pitch;
        }
    }
}
