using UnityEngine;

public class AnimationRandomizer : MonoBehaviour
{
    [SerializeField] private string animationName;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        anim.Play(animationName, -1, Random.Range(0.0f, 1.0f));
    }
}