using System;
using UnityEngine;

[RequireComponent(typeof(DynamicObjectRenderSort))]
public class MovementController : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //Debug.Log("x " + x + "y " + y);
        if (Math.Abs(x) > Math.Abs(y))
        {
            this.transform.position += new Vector3(x * this.speed * Time.deltaTime, 0.0f, 0.0f);

        }else
        {
            this.transform.position += new Vector3(0.0f, y * this.speed * Time.deltaTime, 0.0f);
        }
    }
}
