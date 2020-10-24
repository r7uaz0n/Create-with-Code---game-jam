﻿using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject pickPowerUp = default;
    [SerializeField] private GameObject pick = default;

    private float speed = 5.0f;
    private Animator pickSwingAnimator = default;

    private void Start()
    {
        pickSwingAnimator = pick.GetComponent<Animator>();
    }

    void Update()
    {
        UpdateMovement();
        SwingPick();
    }

    private void UpdateMovement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float deltaX = inputX * Time.deltaTime * speed;
        float deltaZ = inputZ * Time.deltaTime * speed;

        Vector3 movement = new Vector3(deltaX, 0.0f, deltaZ);
        transform.Translate(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == pickPowerUp.gameObject.name)
        {
            pick.SetActive(true);
            Destroy(other.gameObject);
        }

    }

    void SwingPick()
    {
        pickSwingAnimator.enabled = Input.GetKey(KeyCode.Space);
    }

}

////References
//https://answers.unity.com/questions/1086481/how-do-you-write-a-script-for-swinging-a-sword-or.html