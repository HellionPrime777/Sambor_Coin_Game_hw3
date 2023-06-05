using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _grounded;

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseY = Input.GetAxis("Mouse X");

        transform.Rotate(0f, mouseY, 0f);

        var horizonatlSpeed = horizontal * _speed * Time.deltaTime;
        var verticalSpeed = vertical * _speed * Time.deltaTime;

        _rigidbody.AddRelativeForce(horizonatlSpeed , 0f, verticalSpeed, ForceMode.Impulse);

        //var keyDown  = Input.GetKeyDown(KeyCode.Space) && _grounded;
        if(Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rigidbody.AddRelativeForce( 0f, _jumpForce, 0f, ForceMode.Force);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Wall1 wall1)) {
            _grounded= true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall1 wall1)) {
            _grounded = false;
        }
    }

    



    //private void OnCollisionEnter(Collision collision)
    //{
    //    //print(collision.gameObject.name);
    //    //if(collision.gameObject.name == "111" || collision.gameObject.CompareTag("Player"))
    //    //{
    //    //    print(1);
    //    //}
    //    if (collision.gameObject.TryGetComponent(out Wall wall))
    //    {
    //        print(11111);

    //        transform.localScale = new Vector3(1f, 1f, 0.1f);
    //        wall.gameObject.SetActive(false);

    //    }

    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.TryGetComponent(out Wall wall))
    //    {
    //        print(11111);

    //        transform.localScale = new Vector3(1f, 1f, 1f);
    //    }
    //}
}
