using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    public Camera mFollowCamera;
    public Transform mLookTarget;

    public float mFollowDistance;
    public Vector2 mMinMaxFollowDistance;

    public LayerMask mCheckLayers;

    private float mVerticalAngle;
    private float mHitUpAngle;
    private float mLastDistance;
   // public float mHorizontalAngle;
    private Vector3 mHorizontalVector;
    
    // Start is called before the first frame update
    void Start()
    {
        mHorizontalVector = transform.forward;
        mLastDistance = 0.0f;

       // Physics.OverlapBox
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        UpdateCamera();
    }

    void MoveCharacter()
    {
        float fX = Input.GetAxis("Horizontal");
        float fY = Input.GetAxis("Vertical");
        Vector3 vMove = Vector3.zero;
        if(fY != 0)
        {
            transform.forward = mHorizontalVector;

            vMove = transform.forward * fY;
        }
        if(fX != 0)
        {
            vMove += transform.right * fX;
        }

        vMove = vMove * 10.0f * Time.deltaTime;

        transform.position += vMove;
    }

    void UpdateCamera()
    {
        float fHorizontal = Input.GetAxis("Mouse X");
        float fVertical = Input.GetAxis("Mouse Y");
        mVerticalAngle += fVertical;
        float CurrentVerical = mVerticalAngle;

        if (CurrentVerical > 45.0f)
        {
            CurrentVerical = 45.0f;
        } else if(CurrentVerical < -80.0f)
        {
            CurrentVerical = -80.0f;
        }
        mHorizontalVector = Quaternion.AngleAxis(fHorizontal, Vector3.up) * mHorizontalVector;
        mHorizontalVector.Normalize();
        Vector3 vRight = Vector3.Cross(Vector3.up, mHorizontalVector);
        Vector3 vLookForward = Quaternion.AngleAxis(-CurrentVerical, vRight) * mHorizontalVector;
        vLookForward.Normalize();

        Vector3 vFollowPos = mLookTarget.position;
        RaycastHit rh;

       // Physics.SphereCast()
        //if(Physics.BoxCast(mLookTarget.position, new Vector3(0.5f, 0.5f, 0.5f), -vLookForward,  out rh, Quaternion.identity, mFollowDistance, mCheckLayers)
        //{
        //    Vector3 vDir = rh.point - mLookTarget.position;
        // float dist2 = vDir.magnitude; 
        //}
        if (Physics.Raycast(mLookTarget.position, -vLookForward, out rh, mFollowDistance, mCheckLayers))
        {
            Vector3 vDir = rh.point - mLookTarget.position;
            float fDist = vDir.magnitude;
            vDir.y = 0.0f;
            Vector3 vNewPos = rh.point + vLookForward * 0.05f; ;
            if (fDist < mMinMaxFollowDistance.x)
            {
                float fMaxUpDist = Mathf.Sqrt(mMinMaxFollowDistance.x * mMinMaxFollowDistance.x - fDist * fDist);
                vFollowPos = vNewPos + Vector3.up * fMaxUpDist;
            }
            else
            {
                vFollowPos = vNewPos;
            }
            vLookForward = mLookTarget.position - vFollowPos;
        } else
        {
            mHitUpAngle = 0.0f;
            vFollowPos = mLookTarget.position - vLookForward * mFollowDistance;
        }

        
        mFollowCamera.transform.forward = vLookForward;
        mFollowCamera.transform.position = vFollowPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2.0f);
    }
}
