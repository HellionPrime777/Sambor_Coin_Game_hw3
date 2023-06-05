using UnityEngine;

public class FirstScript : MonoBehaviour
{
    [SerializeField] private int _value;
    
    private void Start()
    {
        print(_value);
    }
    
    private void Update()
    {
        print("Update");
    }
}
