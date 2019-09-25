using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController m_cControl;
    // Start is called before the first frame update
    void Start()
    {
        m_cControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        print(SaveLoadWrapper.getError());
        Vector3 move = new Vector3();
        move.z = Input.GetAxis("Vertical");
        move.x = Input.GetAxis("Horizontal");
        move.Normalize();
        move *= Time.deltaTime * 8.0f;
        m_cControl.Move(move);
    }
}
