using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideGroup : MonoBehaviour
{
    public List<BrawlerGuide> guides;
    public static List<GuideGroup> guideGroups;
    
	void Awake ()
	{
        if (guideGroups == null)
        {
            guideGroups = new List<GuideGroup>();
        }
        guideGroups.Add(this);
	}

    public BrawlerGuide GetNearestGuide(Vector3 location)
    {
        float placeholder;
        return GetNearestGuide(location, out placeholder);
    }

    public BrawlerGuide GetNearestGuide(Vector3 location, out float shortestDistance)
    {
        BrawlerGuide closest = guides[0];
        shortestDistance = Vector3.Distance(location, closest.transform.position);
        foreach (BrawlerGuide guide in guides)
        {
            float distance = Vector3.Distance(location, guide.transform.position);
            if (distance < shortestDistance)
            {
                closest = guide;
                shortestDistance = distance;
            }
        }
        return closest;
    }

    public static GuideGroup GetNearestGuideGroup(Vector3 location)
    {
        GuideGroup closest = guideGroups[0];
        float shortestDistance = Vector3.Distance(location, closest.transform.position);
        foreach (GuideGroup group in guideGroups)
        {
            float distance;
            group.GetNearestGuide(location, out distance);
            if (distance < shortestDistance)
            {
                closest = group;
                shortestDistance = distance;
            }
        }
        return closest;
    }
}
