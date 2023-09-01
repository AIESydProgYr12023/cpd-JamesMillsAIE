namespace AIE07_ProgrammingPatterns
{
	public interface IInitializer
	{
		public bool Initialized { get; }

		public void Initialize(params object[] _params);
	}
}