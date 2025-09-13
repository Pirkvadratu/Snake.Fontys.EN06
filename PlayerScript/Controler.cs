using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeHeadController : MonoBehaviour
{
    Collider m_ObjectCollider;

    [Header("Movement Settings")]
    public float MoveSpeed = 15f;
    public float SteerSpeed = 180f;

    [Header("Body Settings")]
    public int Gap = 1;
    public float BodySpeed = 5f;
    public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    private bool createNodeTail = false; // Trigger to grow snake

    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
        m_ObjectCollider.isTrigger = true;
        GrowSnake();
    }

    void Update()
    {
        // Move the snake head forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer the snake
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Record current position for body movement
        PositionsHistory.Insert(0, transform.position);

        // Move each body segment
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }

        // Grow snake if triggered
        if (createNodeTail)
        {
            GrowSnake();
            createNodeTail = false;
        }
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    private void OnTriggerEnter(Collider target)
    {
        Debug.Log("Triggered by: " + target.name);
        if (target.CompareTag("Food"))
        {
            target.gameObject.SetActive(false);
            createNodeTail = true; // Trigger body growth
        }
        else if (target.CompareTag("Wall") || target.CompareTag("Boomb"))
        {
            Debug.Log("Touched Wall or Boomb");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart scene
        }
    }
}