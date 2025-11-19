
using System.Reflection;
using xTend;
namespace SchaererPartners {
    public partial class Event: DBO {
        public override Permission Permission
        {
            get
            {
                var rights = Permission.None;
                if (Database?.CurrentUser.IsAdmin() == true) rights = Permission.All;
				if (Database?.CurrentUser.IsInGroup(CustomUsergroups.Reservation) == true) rights = Permission.Read;
				if (Database?.CurrentUser.IsInGroup (CustomUsergroups.Reservation_Nur_Lesen) == true) rights = Permission.Read;

				return rights;
            }
        }

        public override void OnCreated() {
            base.OnCreated ();
            Seats = 55;
        }

        public override void TreatFile(string physicalFilename, PropertyInfo property) {
            ImageHelper.Scale (575, 387, ImageHelper.ScaleMode.Cover, physicalFilename, physicalFilename);
        }
    }
}