namespace niscolas.UnityUtils.Core
{
	public class IntToStringConverter : BaseConverter<int, string>
	{
		public override string Inner_Convert(int entry)
		{
			return entry.ToString();
		}
	}
}