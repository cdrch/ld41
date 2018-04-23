using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlerMoveForward : MonoBehaviour
{
    public float speed;
    public Queue<BrawlerGuide> guides;
    private Vector3 targetPoint;

	// Use this for initialization
	void Start ()
	{
        guides = new Queue<BrawlerGuide>();
        GuideGroup firstGroup = GuideGroup.GetNearestGuideGroup(transform.position);        
        for (int i = 0; i < firstGroup.guides.Count; i++)
        {
            guides.Enqueue(firstGroup.guides[i]);
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
        transform.LookAt(targetPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BrawlerGuide"))
        {
            targetPoint = GetNextGuidePoint();
        }
    }

    private Vector3 GetNextGuidePoint()
    {
        BrawlerGuide next = guides.Dequeue();
        return next.transform.position;
    }
}
