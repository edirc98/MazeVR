using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
public class ContiniousMovement : MonoBehaviour
{
    #region public PARAMETERS
    [Header("Input Source")]
    public XRNode inputSource;
    [Header("Parameters")]
    public float movementSpeed = 1.0f;
    public float additionalHeigh = 0.2f;
    #endregion

    #region private PARAMETERS
    private Vector2 _inputAxis;
    private CharacterController _character;
    private XROrigin _rig; 
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<XROrigin>();
        _character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out _inputAxis);
    }
    private void FixedUpdate()
    {
        CapsuleFollowHeadset();
        Quaternion headYaw = Quaternion.Euler(0, _rig.Camera.transform.eulerAngles.y, 0);
        Vector3 dir = headYaw * new Vector3(_inputAxis.x, 0, _inputAxis.y);
        _character.Move(dir * Time.fixedDeltaTime * movementSpeed);
    }

    #region FUNCTIONS

    private void CapsuleFollowHeadset()
    {
        _character.height = _rig.CameraInOriginSpaceHeight + additionalHeigh;
        Vector3 capsuleCenter = transform.InverseTransformPoint(_rig.Camera.transform.position);
        _character.center = new Vector3(capsuleCenter.x, _character.height / 2, capsuleCenter.z);
    }
    #endregion
}
