using UnityEngine;

namespace AIE07_ProgrammingPatterns.Samples
{
	public class GameManager : Singleton<GameManager>
	{
		[SerializeField] private Factory cubeFactory;
		[SerializeField, Range(1, 100)] private int cubeCount = 50;

		protected override void OnAwake()
		{
			base.OnAwake();
			
			cubeFactory.Initialize();

			for(int i = 0; i < cubeCount; i++)
			{
				Cube cube = cubeFactory.Create<Cube>("cube");
				Debug.Assert(cube != null, "Spawned cube was null!", gameObject);
				cube.Initialize(Random.ColorHSV(0, 1, 1, 1, 1, 1), Random.insideUnitSphere * 5, transform);
			}
		}

		public void DestroyCube(Cube _cube) => Destroy(_cube.gameObject);
	}
}