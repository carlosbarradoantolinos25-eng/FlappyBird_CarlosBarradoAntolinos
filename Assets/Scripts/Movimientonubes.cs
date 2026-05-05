using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimientonubes : MonoBehaviour
{
    private Transform nubes;
    public float VelocNubes = 0.5f;
    public PipeController pipe;
    public float DashForce = 6f;
    public bool canDash = true;
    public float DashCD = 2f;
    void Start()
    {
        nubes = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0) nubes.Translate((Vector3.left * VelocNubes), Space.World);

        if (nubes.transform.position.x <= -110f)
        {
            nubes.transform.position = new Vector3(115, nubes.transform.position.y, nubes.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        Dash();
    }
    public IEnumerator Dash()
    {     
        canDash = false;
        float dashTime = 0.3f;
        while (dashTime > 0)
        {
            nubes.Translate(Vector3.left * DashForce * Time.deltaTime, Space.World);
            dashTime -= Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(DashCD);
        canDash = true;
        
    }
}
