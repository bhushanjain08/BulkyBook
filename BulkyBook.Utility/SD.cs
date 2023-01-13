namespace BulkyBook.Utility
{
	//SD for static details
	public static class SD
	{
		//user roles
		public const string Role_User_Indi = "Individual";
		public const string Role_User_Comp = "Company";
		public const string Role_Admin = "Admin";
		public const string Role_Employee = "Employee";

		//order detail
		public const string StatusPending = "Pending";
		public const string StatusApproved = "Approved";
		public const string StatusInProgress = "Processing";
		public const string StatusShipped = "Shipped";
		public const string StatusCancelled = "Cancelled";
		public const string StatusRefunded = "Refunded";

		public const string PaymentStatusPending = "Pending";
		public const string PaymentStatusApproved = "Approved";
		public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
		public const string PaymentStatusRejected = "Rejected";
	}
}
