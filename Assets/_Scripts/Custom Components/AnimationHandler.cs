using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    private List<string> animatorParameters;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animatorParameters = animator.parameters.Where(p => p.type == AnimatorControllerParameterType.Bool)
                                                .Select(p => p.name).ToList();
    }

    public void SetAnimationState(string newState)
    {
        if (animator.GetBool(newState))
            return;

        var paramsToDisable = animatorParameters.Where(a => a != newState);

        animator.SetBool(newState, true);

        foreach (var parameter in paramsToDisable)
        {
            animator.SetBool(parameter, false);
        }
    }
}
