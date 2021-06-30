namespace UnityUtils
{
	public class IntToStringConverter : MonoConverter<int, string>
	{
		public override string Inner_Convert(int entry)
		{
			return entry.ToString();
		}
	}
}