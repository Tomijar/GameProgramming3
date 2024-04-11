using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform m_gcPlayer;

    public float m_fVerticalOffset = 15.0f;
    public float m_fForwardOffset = 8.0f;
    public float m_fLerpAbuse = 25.0f;
    
    void Update()
    {
        Vector3 vCurrentPos = transform.position;
        Vector3 vWantedPos = m_gcPlayer.position;

        vWantedPos.y += m_fVerticalOffset;
        vWantedPos += m_gcPlayer.forward * m_fForwardOffset;

        transform.position = Vector3.Lerp(vCurrentPos, vWantedPos, m_fLerpAbuse * Time.deltaTime);
    }
}
