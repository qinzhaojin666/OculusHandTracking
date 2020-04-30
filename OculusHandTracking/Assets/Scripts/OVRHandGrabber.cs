﻿
/// <summary>
/// This class is responsible for enabling object grab using hands only tracking.
/// </summary>
public class OVRHandGrabber : OVRGrabber
{
    private OVRHand hand;
    public float pinchThreshold = 0.3f;

    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
    }

    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
    }

    private void CheckIndexPinch()
    {
        //float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Middle);       // Trigger grab when middle finger is pinched
        bool isPinching = pinchStrength > pinchThreshold;

        if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0)
        {
            GrabBegin();
        }
        else if (m_grabbedObj && !isPinching)
        {
            GrabEnd();
        }
    }
}
