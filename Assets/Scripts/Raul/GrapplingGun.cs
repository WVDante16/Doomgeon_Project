using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer _LR;
    private Vector3 _GrapplePoint;
    public LayerMask _WhatIsGrappleable;
    public Transform _GunTip, _Camera, _player;
    public float _MaxDistance;
    private SpringJoint _SpringJoint;

    public float _GrappleForce = 35f;

    private void Awake()
    {
        _LR = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        DrawRope();

        if (Input.GetMouseButtonDown(1))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(_Camera.position, _Camera.forward, out hit, _MaxDistance, _WhatIsGrappleable))
        {
            _GrapplePoint = hit.point;
            _SpringJoint = _player.gameObject.AddComponent<SpringJoint>();
            _SpringJoint.autoConfigureConnectedAnchor = false;
            _SpringJoint.connectedAnchor = _GrapplePoint;

            float _DistanceFromPoint = Vector3.Distance(_player.position, _GrapplePoint);

            _SpringJoint.maxDistance = _DistanceFromPoint * 0.8f;
            _SpringJoint.minDistance = _DistanceFromPoint * 0.25f;

            _SpringJoint.spring = 4.5f;
            _SpringJoint.damper = 7f;
            _SpringJoint.massScale = 4.5f;

            _LR.positionCount = 2;
        }
    }

    void StopGrapple()
    {
        _LR.positionCount = 0;
        Destroy(_SpringJoint);
    }

    void DrawRope()
    {
        if (!_SpringJoint) return;

        _LR.SetPosition(0, _GunTip.position);
        _LR.SetPosition(1, _GrapplePoint);

        Vector3 grappleDirection = (_GrapplePoint - _player.position).normalized;
        _player.GetComponent<Rigidbody>().AddForce(grappleDirection * _GrappleForce, ForceMode.Force);
    }

    public bool IsGrappling()
    {
        return _SpringJoint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return _GrapplePoint;
    }
}
