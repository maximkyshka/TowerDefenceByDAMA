using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Range(0, 500f)] private float _moveSpeed;
    [SerializeField] private XYZEnum.XYZI Axis = XYZEnum.XYZI.None;
    [SerializeField, Range(-1000f, 1000f)] private float _min;
    [SerializeField, Range(-1000f, 1000f)] private float _max;

    [SerializeField] private float _targetOffset = 0f;

    private Vector3 _position;
    private Vector3 _targetPosition;

    private void Start()
    {
        _position = transform.position;
    }

    void Update()
    {
        if (Axis != XYZEnum.XYZI.None)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            if (scrollInput != 0)
            {
                _targetOffset += scrollInput * _moveSpeed;
            }
        }

        _targetOffset = Mathf.Clamp(_targetOffset, _min, _max);

        _targetPosition = _position;

        switch (Axis)
        {
            case XYZEnum.XYZI.X:
                _targetPosition.x = _position.x + _targetOffset;
                break;
            case XYZEnum.XYZI.Y:
                _targetPosition.y = _position.y + _targetOffset;
                break;
            case XYZEnum.XYZI.Z:
                _targetPosition.z = _position.z + _targetOffset;
                break;
            case XYZEnum.XYZI.InvX:
                _targetPosition.x = _position.x - _targetOffset;
                break;
            case XYZEnum.XYZI.InvY:
                _targetPosition.y = _position.y - _targetOffset;
                break;
            case XYZEnum.XYZI.InvZ:
                _targetPosition.z = _position.z - _targetOffset;
                break;
        }

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * 10f);
    }
}

public static class XYZEnum
{
    public enum XYZI
    {
        X,
        Y,
        Z,
        InvX,
        InvY,
        InvZ,
        None
    }
}