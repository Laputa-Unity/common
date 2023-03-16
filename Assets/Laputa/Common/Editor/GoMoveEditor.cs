using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Laputa.CommonScripts.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GoMove))]
    public class GoMoveEditor : UnityEditor.Editor
    {
        private GoMove[] _GoMoves;

        private void OnEnable()
        {
            _GoMoves = targets.Cast<GoMove>().ToArray();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Stop Moving", GUILayout.Height(40)))
            {
                foreach (var goMove in _GoMoves)
                {
                    goMove.StopMoving();
                }
            }
            
            if (GUILayout.Button("Resume Moving", GUILayout.Height(40)))
            {
                foreach (var goMove in _GoMoves)
                {
                    goMove.ResumeMoving();
                }
            }
            
            if (GUILayout.Button("Reverse Moving", GUILayout.Height(40)))
            {
                foreach (var goMove in _GoMoves)
                {
                    goMove.ReverseMoving();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
