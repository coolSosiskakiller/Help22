using Unity.VisualScripting;
using UnityEngine;
#if UNITY_EDITOR
[ExecuteAlways]
#endif

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject _bar;
    [SerializeField][Range(0, 1)] private float _value;

    public void SetProgress(float value)
    {
        _value = value;
        if ( _bar != null )
        {
            _bar.transform.localScale = new Vector3 ( 1, _value, 1 );
        }
    }

#if UNITY_EDITOR
    private void Update()
    {
        SetProgress(_value );
    }
#endif
}
