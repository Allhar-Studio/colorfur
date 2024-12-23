using MoreMountains.Feedbacks;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedBacks : MonoBehaviour
{
    [SerializeField] MMF_Player jumpFeedback;
    [SerializeField] MMF_Player doubleJumpFeedback;
    [SerializeField] MMF_Player landFeedback;
    [SerializeField] MMF_Player dashFeedback;
    [SerializeField] MMF_Player reloadFeedback;
    [SerializeField] MMF_Player deathFeedback;
    [SerializeField] MMF_Player walkFeedback;
    [SerializeField] MMF_Player waterFeedback;

    public MMF_Player JumpFeedback { get { return jumpFeedback; } }
    public MMF_Player DoubleJumpFeedback { get { return doubleJumpFeedback; } }
    public MMF_Player LandFeedback { get { return landFeedback; } }
    public MMF_Player DashFeedback { get { return dashFeedback; } }
    public MMF_Player ReloadFeedback { get { return reloadFeedback; } }
    public MMF_Player DeathFeedback { get { return deathFeedback; } }
    public MMF_Player WalkFeedback { get { return walkFeedback; } }
    public MMF_Player WaterFeedback { get { return waterFeedback; } }

    private List<MMF_Player> feedbacksAffectedByDirection;

    private void Start()
    {
        feedbacksAffectedByDirection = new List<MMF_Player>()
        {
            DoubleJumpFeedback
        };
    }

    public void ChangeFeedbackDirection(bool isFacingRight)
    {
        if (isFacingRight)
        {
            foreach (var feedback in feedbacksAffectedByDirection)
            {
                feedback.Direction = MMFeedbacks.Directions.TopToBottom;
            }
        }
        else
        {
            foreach (var feedback in feedbacksAffectedByDirection)
            {
                feedback.Direction = MMFeedbacks.Directions.BottomToTop;
            }
        }
    }
}
