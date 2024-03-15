using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRController : MonoBehaviour
{
    public XRNode inputSource;
    private XROrigin rig;

    private Vector2 inputAxis;
    private CharacterController character;

    public float speed = 1;
    public float gravity = 9.81f;
    private float fallingSpeed;
    public float addHeight = 0.2f;
    LayerMask groundLayer;
    float rayLength;
        
  
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<XROrigin>();
        character = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        
    }

    private void FixedUpdate()
    {
        CapsuleFollow();
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(speed * Time.fixedDeltaTime * direction);
        //Gravity Stuff
    }
}
