using UnityEngine;

public class LandRotate : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 3.0f;

    void Start()
    {
        
    }

    void Update()
    {
        RotateFunction();
    }

    private void RotateFunction() 
    {
        this.gameObject.transform.Rotate(new Vector3(0, MoveSpeed * Time.deltaTime, 0), Space.Self);
    }
}
