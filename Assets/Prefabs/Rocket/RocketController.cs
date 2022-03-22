using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] private float vForce = 20;
    [SerializeField] private float hForce = 20;

    private List<GameObject> _gravitySources;
    private Rigidbody _rocketBody;

    private bool _isUpForce;

    private bool _isRightForce;

    private bool _isLeftForce;

    // Start is called before the first frame update
    void Start()
    {
        _rocketBody = GetComponent<Rigidbody>();
        FindGravitySource();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    // 找到所有引力源
    private void FindGravitySource()
    {
        var gravitySourceArray = GameObject.FindGameObjectsWithTag("GravitySource");
        if (gravitySourceArray != null)
        {
            _gravitySources = new List<GameObject>(gravitySourceArray);
        }

        // 如果有引力源，就关闭引擎的引力系统
        if (_rocketBody)
        {
            _rocketBody.useGravity = false;
        }
    }

    private void AddGravityForce()
    {
        if (_gravitySources == null || _rocketBody == null) return;

        foreach (var gravitySource in _gravitySources)
        {
            var gravityDirection = (gravitySource.transform.position - transform.position).normalized;
            _rocketBody.AddForce(gravityDirection * 10, ForceMode.Force);
        }
    }

    private void FixedUpdate()
    {
        AddGravityForce();

        if (_isUpForce)
        {
            VerticalForce();
        }

        if (_isLeftForce)
        {
            HorizontalForce(false);
        }

        if (_isRightForce)
        {
            HorizontalForce(true);
        }
    }

    private void ProcessInput()
    {
        _isUpForce = Input.GetKey(KeyCode.Space);
        _isRightForce = Input.GetKey(KeyCode.RightArrow);
        _isLeftForce = Input.GetKey(KeyCode.LeftArrow);
    }

    private void VerticalForce()
    {
        var bottomEngine = transform.Find("BottomEngine");

        if (bottomEngine == null) return;
        var force = bottomEngine.up * vForce;
        AddForceToRocket(force, bottomEngine.position);
    }

    private void HorizontalForce(bool isRight)
    {
        Transform hEngine;
        Vector3 force;

        if (isRight)
        {
            force = transform.right * -1 * hForce;
            hEngine = transform.Find("RightEngine");
        }
        else
        {
            force = transform.right * hForce;
            hEngine = transform.Find("LeftEngine");
        }

        if (hEngine == null) return;
        AddForceToRocket(force, hEngine.position);
    }

    private void AddForceToRocket(Vector3 force, Vector3 position)
    {
        if (_rocketBody == null) return;
        _rocketBody.AddForceAtPosition(force, position, ForceMode.Force);

        var end = position + force * 10;
        Debug.DrawLine(position, end, Color.red);
        Debug.Log(force);
    }
}