using UnityEngine;

namespace AIE07_ProgrammingPatterns.Samples
{
	public class Cube : InitializeBehaviour
	{
		[SerializeField] private new MeshRenderer renderer;
		
		protected override void OnInit(params object[] _params)
		{
			renderer.material.color = (Color) _params[0];
			transform.localPosition = (Vector3) _params[1];
			transform.parent = (Transform) _params[2];
		}

		private void OnMouseUpAsButton()
		{
			if(GameManager.IsValid())
				GameManager.Instance.DestroyCube(this);
		}
	}
}