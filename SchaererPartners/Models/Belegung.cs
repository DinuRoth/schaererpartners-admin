
using xTend;
namespace SchaererPartners {
    public partial class Belegung: DBO {
        public override Permission Permission
        {
            get
            {
                var rights = Permission.None;
				if (Database?.CurrentUser.IsAdmin () == true) rights = Permission.All;
				if (Database?.CurrentUser.IsInGroup (CustomUsergroups.Belegung) == true) rights = Permission.All;
				return rights;
            }
        }
    }
}