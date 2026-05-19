using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathState : PlayerState
{

    public override void EnterState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        Debug.Log("Estado de Death");
        playerInfo.playerController.playerSpriteRenderer.color = Color.orange;
    }

    public override void ExitState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {

    }

    public override void UpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public override void FixedUpdateState(PlayerStateManager playerManager, PlayerInfo playerInfo)
    {

    }

    public override void OnTriggerEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collider2D collider)
    {

    }

    public override void OnCollisionEnter2D(PlayerStateManager playerManager, PlayerInfo playerInfo, Collision2D collision)
    {

    }
}
