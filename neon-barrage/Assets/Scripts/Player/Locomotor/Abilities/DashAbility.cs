using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
public class DashAbility
{
    private readonly DashAbilityData data;
    private readonly WaitForSeconds waitDash;

    private float lastDashRequestTime = 0;
    private Vector3? dashVelocity = null;
    private float cooldownEndTime = 0;

    public DashAbility(DashAbilityData data)
    {
        this.data = data;
        waitDash = new WaitForSeconds(data.DashDuration);
    }

    public void Enable()
    {
        data.DashInput.action.Enable();
        data.DashInput.action.performed += OnDashTriggered;
    }

    public void Disble()
    {
        data.DashInput.action.performed -= OnDashTriggered;
        data.DashInput.action.Disable();
    }

    private void OnDashTriggered(InputAction.CallbackContext obj)
    {
        lastDashRequestTime = Time.time;
    }

    public void Apply(ref Vector3 velocity, MonoBehaviour mb)
    {
        bool canDash = (Time.time - lastDashRequestTime) < data.DashInputBufferTime;
        bool isOnCooldown = Time.time < cooldownEndTime;

        if (velocity.sqrMagnitude > 0 && canDash && !dashVelocity.HasValue && !isOnCooldown)
        {
            dashVelocity = velocity.normalized * data.DashSpeed;
            lastDashRequestTime = -Mathf.Infinity;
            mb.StartCoroutine(Dash());
        }
        
        if (dashVelocity.HasValue) velocity = dashVelocity.Value;
    }

    private IEnumerator Dash()
    {
        yield return waitDash;
        cooldownEndTime = Time.time + data.DashCooldown;
        dashVelocity = null;
    }
}
