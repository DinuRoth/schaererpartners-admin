
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace SchaererPartners {
    public partial class xtUseroption: DBO {
        public xtUseroption () : base() { }
        public xtUseroption (IUserDB db) : base (db) { }

		private System.Int32 _xtUser_FK;
		private System.String _xtUseroption_Bez;
		private System.String? _Setting;


        [Column]
        [Key]
		public Int32 xtUseroption_ID { get; set; }
        public override Int32 Id {
            get { return xtUseroption_ID; }
        }

		[Column]
		[ForeignKey ("xtUser")]
		public System.Int32 xtUser_FK {
            get { return _xtUser_FK; }
            set { 
                if (value != _xtUser_FK) {
                    var oldVal = _xtUser_FK;
                    _xtUser_FK = value;
                    OnFieldChanged(nameof(xtUser_FK), oldVal, value);

                } 
            }
        }
		[Column]
		[StringLength(50)]
		public System.String xtUseroption_Bez {
            get { return _xtUseroption_Bez; }
            set { 
                if (value != _xtUseroption_Bez) {
                    var oldVal = _xtUseroption_Bez;
                    _xtUseroption_Bez = value;
                    OnFieldChanged(nameof(xtUseroption_Bez), oldVal, value);

                } 
            }
        }
		[Column]
		[StringLength(2147483647)]
		public System.String? Setting {
            get { return _Setting; }
            set { 
                if (value != _Setting) {
                    var oldVal = _Setting;
                    _Setting = value;
                    OnFieldChanged(nameof(Setting), oldVal, value);

                } 
            }
        }

		public xtUser? _xtUser;
       [GUIType(GUIType.Enum.Hidden)]
        public xtUser? xtUser { 
            get {
                if (_xtUser == null) {
                    _xtUser = Database.Read<xtUser> (xtUser_FK);
                }
                return _xtUser;
            }
            set {
                _xtUser = value;
            }
        }



        public override void SetData(SqlDataReader reader, string prefix="") {
			xtUseroption_ID = (int)reader[prefix + nameof (xtUseroption_ID)];
			_xtUser_FK = (System.Int32) reader[prefix + nameof(xtUser_FK)];
			_xtUseroption_Bez = (System.String) reader[prefix + nameof(xtUseroption_Bez)];
			_Setting = reader.ToNullableString (prefix + nameof(Setting));

        }
    }
}