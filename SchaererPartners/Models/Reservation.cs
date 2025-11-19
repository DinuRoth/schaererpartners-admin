
using xTend;
namespace SchaererPartners
{
    public partial class Reservation : DBO
    {
        public override Permission Permission
        {
            get
            {
                var rights = Permission.None;
				if (Database?.CurrentUser.IsAdmin () == true) rights = Permission.All;
				if (Database?.CurrentUser.IsInGroup (CustomUsergroups.Reservation) == true) rights = Permission.All;
				if (Database?.CurrentUser.IsInGroup (CustomUsergroups.Reservation_Nur_Lesen) == true) rights = Permission.Read;
				return rights;
            }
        }
    }
}