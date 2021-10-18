using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("Ship 2D Speed")]
    [Tooltip("ms-1")][SerializeField] float ControlSpeed = 50f;
    [SerializeField] GameObject[] beams;

    [Header("WindowClamp")]
    [Tooltip("m")] [SerializeField] float xClampRange = 10f;
    [Tooltip("m")] [SerializeField] float yClampRange = 5f;

    [Header("Pitch, Yaw & Roll")]
    [SerializeField] float pitchClampRange = -3f;
    [SerializeField] float yawClampRange = 2.2f;
    [SerializeField] float pitchThrow = -30f;
    [SerializeField] float rollThrow = -30f;

    float xThrow, yThrow;
    bool isdead = false;
    
   

    // Start is called before the first frame update
    void Start()
    {
                
    }

    

    // Update is called once per frame
    void Update()
    {
        ShipControls();

    }

    public void DeathSequence() // called by CollisionHandler script
    {
        isdead = true;

    }

    private void ShipControls()
    {
        if (!isdead)
        {
            ProcessTranslation();
            ProcessRotation();
            shooting();
        }
        else
            return;
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xFrame = xThrow * ControlSpeed * Time.deltaTime;
        float xraw = xFrame + transform.localPosition.x;

        float xFinal = Mathf.Clamp(xraw, -xClampRange, xClampRange);


        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yFrame = yThrow * ControlSpeed * Time.deltaTime;
        float yraw = yFrame + transform.localPosition.y;

        float yFinal = Mathf.Clamp(yraw, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(xFinal, yFinal, transform.localPosition.z);
    }
    private void ProcessRotation()
    {

        float pitchduetoposition = pitchClampRange * transform.localPosition.y;
        float pitchduetothrow = yThrow * pitchThrow;



         float pitch = pitchduetoposition + pitchduetothrow;
        float yaw = yawClampRange * transform.localPosition.x;
        
        //control the change in direction so that it doesn't jerk from one side to the other
        float roll = xThrow * pitchThrow;
        


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);








    }
    private void shooting()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            foreach (GameObject beam in beams)
                beam.SetActive(true);
        }
        else
            foreach (GameObject beam in beams) 
        beam.SetActive(false);

        
    }

    
}
