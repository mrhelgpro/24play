using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public float HorizontalSpeed = 10f;
    public float VerticalSpeed = 400f;
    public Vector3 StartPosition = new Vector3(0, -150, 120);
    public float EndPosition = -30f;

    public List<GameObject> Sections = new List<GameObject>();

    private bool _haveFirstSection;

    public void NextSection(GameObject section)
    {
        section.SetActive(false);

        // Do not add the first section
        if (_haveFirstSection == false)
        {
            _haveFirstSection = true;
        }
        else
        {
            Sections.Add(section);
        }

        int randomIndex = Random.Range(0, Sections.Count -1);

        startSection(randomIndex);
    }

    private void startSection(int index)
    {
        GameObject currentSection = Sections[index];

        Sections.Remove(currentSection);

        currentSection.transform.position = StartPosition;
        currentSection.SetActive(true);
    }
}