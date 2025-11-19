using xTend;

namespace SchaererPartners {
	public static class CustomUsergroups {
		public static bool IsInGroup(this xtIUser? user, int groupID) {
			if (user == null) return false;
			if (user.Usergroups == null) return false;
			return user.Usergroups.FirstOrDefault (x => x.xtUsergroup_ID == groupID) != null;
		}

		public static int Reservation = 9;
		public static int Belegung = 10;
		public static int Reservation_Nur_Lesen = 11;
		public static int Newsletter = 12;
	}
}
