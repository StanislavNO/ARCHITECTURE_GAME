using UnityEngine;

namespace Assets.Scripts.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 Axis = GetSimpleInputAxis();

                if (Axis == Vector2.zero)
                {
                    Axis = GetStandaloneInputAxis();
                }

                return Axis;
            }
        }

        private static Vector2 GetStandaloneInputAxis()
        {
            Vector2 Axis = new Vector2(
                UnityEngine.Input.GetAxis(Horizontal),
                UnityEngine.Input.GetAxis(Vertical));

            return Axis;
        }
    }
}