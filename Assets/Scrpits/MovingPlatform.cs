using UnityEngine;
using System.Collections;



public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint1;
    public Transform endPoint2;
    public UseCase useCase = UseCase.Manual;
    [SerializeField]
    private float _moveSpeed = 1;
    public bool _return;
    [SerializeField]
    private bool _switch = true;
    private Rigidbody _platformRigidBody = null;
    public Transform _platform;
    public bool playerDetect = false;

    public Torch torch;
    public Material purpleMaterial;
    public Material orangeMaterial;

    public void Start()
    {
        _platformRigidBody = _platform.transform.GetComponent<Rigidbody>();
        _platformRigidBody.mass = 200;
    }

    public void SetState(bool state)
    {
        _switch = state;
        state = !state;
    }

    public void FixedUpdate()
    {
        if (useCase == UseCase.Orange)
        {
            _platform.GetComponent<Renderer>().material = orangeMaterial;
            if (_platform.position == endPoint1.position)
            {
                _return = true;
            }
            else if (_platform.position == startPoint.position)
            {
                _return = false;
            }

            if (_return && !playerDetect) _platform.position = Vector3.MoveTowards(_platform.position, startPoint.position, _moveSpeed * Time.fixedDeltaTime);
            if (!_return && playerDetect) _platform.position = Vector3.MoveTowards(_platform.position, endPoint1.position, _moveSpeed * Time.fixedDeltaTime);
        }

        if (useCase == UseCase.Purple)
        {
            _platform.GetComponent<Renderer>().material = purpleMaterial;
            if (_platform.position == endPoint2.position)
            {
                _return = true;
            }
            else if (_platform.position == startPoint.position)
            {
                _return = false;
            }

            if (_return && !playerDetect) _platform.position = Vector3.MoveTowards(_platform.position, startPoint.position, _moveSpeed * Time.fixedDeltaTime);
            if (!_return && playerDetect) _platform.position = Vector3.MoveTowards(_platform.position, endPoint2.position, _moveSpeed * Time.fixedDeltaTime);
        }
        if (useCase == UseCase.Manual)
        {
            if (_switch) _platform.position = Vector3.MoveTowards(_platform.position, startPoint.position, _moveSpeed * Time.fixedDeltaTime);
            if (!_switch) _platform.position = Vector3.MoveTowards(_platform.position, endPoint2.position, _moveSpeed * Time.fixedDeltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Player" && torch.itsLit)
         {
            playerDetect = (playerDetect == false) ? true : false;
         }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startPoint.position, transform.localScale);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endPoint1.position, transform.localScale);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endPoint2.position, transform.localScale);
    }
}


