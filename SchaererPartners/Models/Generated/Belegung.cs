
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;


namespace SchaererPartners {
    public partial class Belegung: DBO {
        public Belegung () : base() { }
        public Belegung (IUserDB db) : base (db) { }

		private System.DateTime _StartDatumZeit;
		private System.String _Belegung_Bez;
		private System.String? _Bemerkung;
		private System.DateTime _EndDatumZeit;


        [Column]
        [Key]
		public Int32 Belegung_ID { get; set; }
        public override Int32 Id {
            get { return Belegung_ID; }
        }

		[Column]
		[GUIType(GUIType.Enum.DateTime)]
		public System.DateTime StartDatumZeit {
            get { return _StartDatumZeit; }
            set {
                if (value != _StartDatumZeit) {
                    var oldVal = _StartDatumZeit;
                    _StartDatumZeit = value;
                    OnFieldChanged(nameof(StartDatumZeit), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String Belegung_Bez {
            get { return _Belegung_Bez; }
            set {
                if (value != _Belegung_Bez) {
                    var oldVal = _Belegung_Bez;
                    _Belegung_Bez = value;
                    OnFieldChanged(nameof(Belegung_Bez), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Bemerkung {
            get { return _Bemerkung; }
            set {
                if (value != _Bemerkung) {
                    var oldVal = _Bemerkung;
                    _Bemerkung = value;
                    OnFieldChanged(nameof(Bemerkung), oldVal, value);

                }
            }
        }
		[Column]
		[GUIType(GUIType.Enum.DateTime)]
		public System.DateTime EndDatumZeit {
            get { return _EndDatumZeit; }
            set {
                if (value != _EndDatumZeit) {
                    var oldVal = _EndDatumZeit;
                    _EndDatumZeit = value;
                    OnFieldChanged(nameof(EndDatumZeit), oldVal, value);

                }
            }
        }




        public override void SetData(SqlDataReader reader, string prefix="") {
    
			Belegung_ID = (int)reader[prefix + nameof (Belegung_ID)];
			_StartDatumZeit = (System.DateTime) reader[prefix + nameof(StartDatumZeit)];
			_Belegung_Bez = (System.String) reader[prefix + nameof(Belegung_Bez)];
			_Bemerkung = reader.ToNullableString (prefix + nameof(Bemerkung));
			_EndDatumZeit = (System.DateTime) reader[prefix + nameof(EndDatumZeit)];

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
