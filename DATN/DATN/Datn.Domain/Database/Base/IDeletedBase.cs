namespace Datn.Domain.Database.Base
{
	public interface IDeletedBase
	{
		public bool Deleted { get; set; }

		public Guid? DeletedBy { get; set; }

		public DateTimeOffset DeletedTime { get; set; }

	}
}
