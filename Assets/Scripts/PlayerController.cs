using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber = 1;
    public float moveSpeed = 10f;

    private string m_HorizontalAxisName = "";
    private string m_VerticalAxisName = "";

    private float m_HorizontalInput = 0;
    private float m_VerticalInput = 0;

    private Rigidbody m_Rigidbody;

    private MeshRenderer m_hat;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        m_HorizontalAxisName = "Horizontal_" + playerNumber;
        m_VerticalAxisName = "Vertical_" + playerNumber;
        m_hat = transform.Find("Hat").GetComponent<MeshRenderer>();

        if(playerNumber == 2)
        {
            Material hatMat = m_hat.material;
            hatMat.color = Color.green;
            m_hat.material = hatMat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_HorizontalInput = Input.GetAxis(m_HorizontalAxisName);
        m_VerticalInput = Input.GetAxis(m_VerticalAxisName);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDir = new Vector3(m_HorizontalInput, 0, m_VerticalInput) * moveSpeed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + moveDir);
    }
}
