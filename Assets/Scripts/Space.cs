using System;
using UnityEngine;

public class Space : MonoBehaviour
{
    public static bool isPlayerOne = true;

    public GameObject circle;
    public GameObject cross;


    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == _collider)
            {
                GameObject obj = isPlayerOne ? cross : circle;
                isPlayerOne = !isPlayerOne;
                Instantiate(obj, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}