using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Healthy))]
    public class HealthyInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Healthy healthy = (Healthy)target;

            if (GUILayout.Button("Add Health"))
            {
                healthy.AddHealth(1);
            }

            if (GUILayout.Button("Do Damage"))
            {
                healthy.DoDamage(1);
            }
        }
    }
}