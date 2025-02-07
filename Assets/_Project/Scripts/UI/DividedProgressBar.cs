using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteAlways]
#endif

public class DividedProgressBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> _divides;
    [SerializeField][Range(0, 1)] private float _value;

    public void SetProgress(float value)
    {
        value = Mathf.Clamp01(value);
        _value = value;

        float delta = 1f / _divides.Count;
        int count = Mathf.CeilToInt(value / delta);

        _divides.ForEach(x => x.SetActive(true));

        for (int i = 0; i < _divides.Count; i++)
        {
            if (i < _divides.Count - count)
            {
                _divides[i].SetActive(false);
            }
        }
    }

#if UNITY_EDITOR 
    private void Update()
    {
        SetProgress(_value);
    }
#endif
}
