using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player")]
    public Animator playerAnimator;
    public Rigidbody playerRigidbody;

    public MeshRenderer m_renderer;

    public Material material1;
    public Material material2;
    
    public void EndOfFaking()
    {
        playerAnimator.SetBool("FinishedFaking", true);
        playerAnimator.SetBool("FakeStart", false);

        RigidbodyConstraints constraints = new RigidbodyConstraints();

        constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        playerRigidbody.constraints = constraints;
    }

    public void AnimationTester(Animation animator)
    {
        
    }

    private void AfterContact()
    {
        playerAnimator.SetBool("IsHit", false);
    }

    public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsTurningLeft", false);
        animator.SetBool("IsTurningRight", false);
    }

    public void SwitchMaterial()
    {
        if (m_renderer.material == material2)
        {
            Debug.Log("ayayayaya");
            m_renderer.materials = null;
            m_renderer.material = material1;
        }
        else if(m_renderer.material == material1)
        {
            Debug.Log("gggtggtt");
            m_renderer.materials = null;
            m_renderer.material = material2;
        }
    }
}
