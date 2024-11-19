using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(CameraController))]
    public class CameraControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            CameraController controller = (CameraController)target;
            
            // Show xRotation limits only if fancyZoom is true
            if (controller.fancyZoom)
            {
                controller.xRotationLowerLimit = EditorGUILayout.FloatField("X Rotation Lower Limit", controller.xRotationLowerLimit);
                controller.xRotationUpperLimit = EditorGUILayout.FloatField("X Rotation Upper Limit", controller.xRotationUpperLimit);
            }

            // Apply any changes
            if (GUI.changed)
            {
                EditorUtility.SetDirty(controller);
            }
        }
    }
}